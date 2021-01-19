using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text;

namespace SubnetPing
{
    public delegate void ClientCallback(string ip, bool online);
    
    public class SubnetClientV4 : IDisposable
    {

        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        public static extern int SendARP(int DestIP, int SrcIP, byte[] pMacAddr, ref uint PhyAddrLen);

        public string _ipAddressV4interface;
        public string _ipAddressV4;
        public long _ipAddressV4Long;
        public ScanProperties _scanProperties = new ScanProperties();
        public ScanCompleted _scanCompleted = new ScanCompleted();
        public List<ScanPort> _ports = new List<ScanPort>();
        public string _snmp = "-";
        public string _macAddress = "-";
        public string _hostname = "-";
        public string _hops = "-";
        public string _ms = "-";
        public string _device = "-";
        public int _displayLine = -1;
        public long _pingCount = 0;
        public long _tryCount = 0;
        public int _timeout = 1000;
        public int _packetSize = 64;
        public int _ttl = 64;
        public int[] packets = new int[8] { 1, 1, 1, 1, 1, 1, 1, 1 };

        public long[] histroy = new long[64];

        public bool _external = false;

        public bool _isOnline = false;
        public DateTime _lastHeartbeat;
        public ScanMode _scanmode = ScanMode.AUTO;
        public Stopwatch _clock = new Stopwatch();
        public ClientCallback _clientCallback;
        public static ManualResetEvent GetHostEntryFinished = new ManualResetEvent(false);
        public static ManualResetEvent PortConnectFinished = new ManualResetEvent(false);
        public static ManualResetEvent RawFinished = new ManualResetEvent(false);
        public long Roundtrip = 0;

        public Int32 start = 0;

        public SubnetClientV4(string ip)
        {
            _ipAddressV4 = ip;
            _ipAddressV4Long = IP2Long(ip);
            _scanCompleted = new ScanCompleted();
            _scanmode = ScanMode.AUTO;
            portlist();
        }

        public decimal packetloss() {
            int s = 0;
            if (_tryCount < 8)
            {
                for (int i = 0; i < _tryCount; i++)
                {
                    s += packets[i];
                }
                return decimal.Parse(Math.Round((decimal)100 - (((decimal)s / (decimal)_tryCount) * 100), 0).ToString());
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    s += packets[i];
                }
                return decimal.Parse(Math.Round((decimal)100 - (((decimal)s / (decimal)8) * 100), 0).ToString());
            }
        }

        public void addResult(int res) {
            Array.Copy(packets, 0, packets, 1, packets.Length - 1);
            packets[0] = res;
        }

        public void addPing(long res)
        {
            Array.Copy(histroy, 0, histroy, 1, histroy.Length - 1);
            histroy[0] = res;
        }

        public void Refresh(ScanProperties sp, ScanMode sm)
        {
            _clock.Reset();
            _clock.Start();
            _scanProperties = sp;
            if (sm != ScanMode.AUTO)
            {
                _scanmode = sm;
            }

            if (_external == true)
            {
                _scanProperties.ARP = false;
                _scanProperties.DNS = false;
            }

            if (_tryCount % 30 == 0)
            {
                if (_macAddress == "-")
                {
                    _scanCompleted.ARP = false;
                }
                if (_hostname == "-")
                {
                    _scanCompleted.DNS = false;
                }
            }

            if (_scanmode == ScanMode.AUTO)
            {
                PingAsync();
                if (_scanProperties.PING == true && _scanCompleted.PING == false)
                {
                    _scanmode = ScanMode.PING;
                }
                else if (_scanProperties.ARP == true && _scanCompleted.ARP == false)
                {
                    _scanmode = ScanMode.ARP;
                }
                else if (_scanProperties.DNS == true && _scanCompleted.DNS == false)
                {
                    _scanmode = ScanMode.DNS;
                }
                else if (_scanProperties.TRACE == true && _scanCompleted.TRACE == false)
                {
                    _scanmode = ScanMode.TRACE;
                }
                else if (_scanProperties.PORT == true && _scanCompleted.PORT == false)
                {
                    _scanmode = ScanMode.PORT;
                }
                else if (_scanProperties.RAW == true && _scanCompleted.RAW == false)
                {
                    _scanmode = ScanMode.RAW;
                }
                else
                {
                    _scanmode = ScanMode.AUTO;
                }
            }
            else if (_scanmode == ScanMode.PING && _scanProperties.PING == true && _scanCompleted.PING == false)
            {
                PingSync();
                if (_scanProperties.ARP == true)
                {
                    _scanmode = ScanMode.ARP;
                }
                else if (_scanProperties.DNS == true)
                {
                    _scanmode = ScanMode.DNS;
                }
                else if (_scanProperties.TRACE == true)
                {
                    _scanmode = ScanMode.TRACE;
                }
                else if (_scanProperties.PORT == true)
                {
                    _scanmode = ScanMode.PORT;
                }
                else if (_scanProperties.RAW == true)
                {
                    _scanmode = ScanMode.RAW;
                }
                else
                {
                    _scanmode = ScanMode.AUTO;
                }
            }
            else if (_scanmode == ScanMode.ARP && _scanProperties.ARP == true && _scanCompleted.ARP == false)
            {
                Arp();
                if (_scanProperties.DNS == true)
                {
                    _scanmode = ScanMode.DNS;
                }
                else if (_scanProperties.TRACE == true)
                {
                    _scanmode = ScanMode.TRACE;
                }
                else if (_scanProperties.PORT == true)
                {
                    _scanmode = ScanMode.PORT;
                }
                else if (_scanProperties.RAW == true)
                {
                    _scanmode = ScanMode.RAW;
                }
                else
                {
                    _scanmode = ScanMode.AUTO;
                }
            }
            else if (_scanmode == ScanMode.DNS && _scanProperties.DNS == true && _scanCompleted.DNS == false)
            {
                ResolveAsync();
                if (_scanProperties.TRACE == true)
                {
                    _scanmode = ScanMode.TRACE;
                }
                else if (_scanProperties.PORT == true)
                {
                    _scanmode = ScanMode.PORT;
                }
                else if (_scanProperties.RAW == true)
                {
                    _scanmode = ScanMode.RAW;
                }
                else
                {
                    _scanmode = ScanMode.AUTO;
                }
            }
            else if (_scanmode == ScanMode.TRACE && _scanProperties.TRACE == true && _scanCompleted.TRACE == false)
            {
                Trace();
                if (_scanProperties.PORT == true)
                {
                    _scanmode = ScanMode.PORT;
                }
                else if (_scanProperties.RAW == true)
                {
                    _scanmode = ScanMode.RAW;
                }
                else
                {
                    _scanmode = ScanMode.AUTO;
                }
            }
            else if (_scanmode == ScanMode.PORT && _scanProperties.PORT == true && _scanCompleted.PORT == false)
            {
                PortAsync();
                if (_scanProperties.RAW == true)
                {
                    _scanmode = ScanMode.RAW;
                }
                else
                {
                    _scanmode = ScanMode.AUTO;
                }
            }
            else if (_scanmode == ScanMode.RAW && _scanProperties.RAW == true && _scanCompleted.RAW == false)
            {
                RawAsync();
                _scanmode = ScanMode.AUTO;
            }
            else
            {
                PingAsync();
                _scanmode = ScanMode.AUTO;
            }

            _clock.Stop();
            Roundtrip = _clock.ElapsedMilliseconds;
            Application.DoEvents();
        }

        private void Arp()
        {
            if (_macAddress == "-")
            {
                _macAddress = "?";
            }
            try
            {
                IPAddress Destination = IPAddress.Parse(_ipAddressV4);
                byte[] macAddr = new byte[6];
                uint macAddrLen = (uint)macAddr.Length;
                int intAddress = BitConverter.ToInt32(Destination.GetAddressBytes(), 0);
                if (SendARP(intAddress, 0, macAddr, ref macAddrLen) == 0)
                {
                    _macAddress = BitConverter.ToString(macAddr).ToLower();
                    _isOnline = true;
                    //_pingCount++;
                    _lastHeartbeat = DateTime.Now;
                    _clientCallback?.Invoke(_ipAddressV4, true);
                }
                _scanCompleted.ARP = true;
            }
            catch (Exception e)
            {
                //Console.WriteLine("Arp: " + e.Message);
                _macAddress = "-";
                _scanCompleted.ARP = false;
            }
        }

        private void ResolveSync()
        {
            if (_hostname == "-")
            {
                _hostname = "?";
            }
            try
            {
                IPHostEntry host = Dns.GetHostEntry(_ipAddressV4);
                _hostname = host.HostName.ToString();
                _lastHeartbeat = DateTime.Now;
                _scanCompleted.DNS = true;
                _clientCallback?.Invoke(_ipAddressV4, true);
            }
            catch (Exception e)
            {
                _hostname = "-";
                _scanCompleted.DNS = true;
            }
        }

        private void ResolveAsync()
        {
            if (_hostname == "-")
            {
                _hostname = "?";
            }
            try
            {
                GetHostEntryFinished.Reset();
                ResolveState ioContext = new ResolveState(_ipAddressV4);
                Dns.BeginGetHostEntry(_ipAddressV4, new AsyncCallback(ResolveCompletedCallback), ioContext);
                GetHostEntryFinished.WaitOne(_timeout);
            }
            catch (Exception)
            {
                _hostname = "-";
                _scanCompleted.DNS = true;
            }
        }

        private void ResolveCompletedCallback(IAsyncResult ar)
        {
            try
            {
                ResolveState ioContext = (ResolveState)ar.AsyncState;
                ioContext.IPs = Dns.EndGetHostEntry(ar);
                GetHostEntryFinished.Set();
                _hostname = ioContext.IPs.HostName;
                _lastHeartbeat = DateTime.Now;
                _scanCompleted.DNS = true;
                _clientCallback?.Invoke(_ipAddressV4, true);
            }
            catch (Exception e)
            {
                //Console.WriteLine("ResolveCompletedCallback: " + e.Message);
                _hostname = "-";
                _scanCompleted.DNS = true;
            }
        }

        private void PingSync()
        {
            if (_ms == "-")
            {
                _ms = "?";
            }
            if (_hops == "-")
            {
                _hops = "?";
            }
            try
            {
                _tryCount++;
                Ping pingSender = new Ping();
                PingReply prResult = pingSender.Send(_ipAddressV4, _timeout, new byte[_packetSize], new PingOptions(_ttl, true));
                if (prResult.Status == IPStatus.Success)
                {
                    _ms = prResult.RoundtripTime.ToString();
                    addPing(prResult.RoundtripTime);
                    _pingCount++;
                    if (prResult.Options.Ttl > 128)
                    {
                        _hops = (255 - prResult.Options.Ttl).ToString();
                    }
                    else if (prResult.Options.Ttl > 64)
                    {
                        _hops = (128 - prResult.Options.Ttl).ToString();
                    }
                    else if (prResult.Options.Ttl > 32)
                    {
                        _hops = (64 - prResult.Options.Ttl).ToString();
                    }
                    else if (prResult.Options.Ttl > 0)
                    {
                        _hops = (32 - prResult.Options.Ttl).ToString();
                    }
                    _isOnline = true;
                    addResult(1);
                    _lastHeartbeat = DateTime.Now;
                    _scanCompleted.PING = true;
                    _clientCallback?.Invoke(_ipAddressV4, true);
                }
                else if (prResult.Status == IPStatus.TimedOut)
                {
                    _isOnline = false;
                    addResult(0);
                    _scanCompleted.PING = true;
                    _ms = "-";
                    addPing(_timeout);
                    _hops = "-";
                    _clientCallback?.Invoke(_ipAddressV4, false);
                }
                else
                {
                    _isOnline = false;
                    addResult(0);
                    _scanCompleted.PING = true;
                    _ms = "-";
                    addPing(_timeout);
                    _hops = "-";
                    _clientCallback?.Invoke(_ipAddressV4, false);
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("PingSync: " + e.Message);
                _ms = "-";
                addPing(_timeout);
                _hops = "-";
                _isOnline = false;
                addResult(0);
                _scanCompleted.PING = true;
                _clientCallback?.Invoke(_ipAddressV4, false);
            }
        }

        private void PingAsync()
        {
            if (_ms == "-")
            {
                _ms = "?";
            }
            if (_hops == "-")
            {
                _hops = "?";
            }
            try
            {
                _tryCount++;
                AutoResetEvent waiter = new AutoResetEvent(false);
                using (Ping pingSender = new Ping())
                {
                    pingSender.PingCompleted += new PingCompletedEventHandler(PingCompletedCallback);
                    PingOptions options = new PingOptions(_ttl, true);
                    byte[] buffer = new byte[_packetSize];
                    pingSender.SendAsync(_ipAddressV4, _timeout, buffer, options, waiter);
                    waiter.WaitOne();
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("PingAsync: " + e.Message);
                _ms = "-";
                _hops = "-";
                _isOnline = false;
                addResult(0);
                _clientCallback?.Invoke(_ipAddressV4, false);
            }
        }

        private void PingCompletedCallback(object sender, PingCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled == false && e.Error == null)
                {
                    PingReply reply = e.Reply;
                    if (reply.Status == IPStatus.Success)
                    {
                        _ms = reply.RoundtripTime.ToString();
                        addPing(reply.RoundtripTime);
                        if (reply.Options.Ttl > 128)
                        {
                            _hops = (255 - reply.Options.Ttl).ToString();
                        }
                        else if (reply.Options.Ttl > 64)
                        {
                            _hops = (128 - reply.Options.Ttl).ToString();
                        }
                        else if (reply.Options.Ttl > 32)
                        {
                            _hops = (64 - reply.Options.Ttl).ToString();
                        }
                        else if (reply.Options.Ttl > 0)
                        {
                            _hops = (32 - reply.Options.Ttl).ToString();
                        }
                        else
                        {
                            _hops = "?";
                        }
                        _pingCount++;
                        _isOnline = true;
                        addResult(1);
                        _lastHeartbeat = DateTime.Now;
                        _scanCompleted.PING = true;
                        _clientCallback?.Invoke(_ipAddressV4, true);
                    }
                    else
                    {
                        _ms = "-";
                        addPing(_timeout);
                        _hops = "-";
                        _isOnline = false;
                        addResult(0);
                        _scanCompleted.PING = true;
                        _clientCallback?.Invoke(_ipAddressV4, false);
                    }
                }
                else
                {
                    _ms = "-";
                    addPing(_timeout);
                    _hops = "-";
                    _isOnline = false;
                    addResult(0);
                    _scanCompleted.PING = true;
                    _clientCallback?.Invoke(_ipAddressV4, false);
                }
                ((AutoResetEvent)e.UserState).Set();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("PingCompletedCallback: " + ex.Message);
                _ms = "-";
                addPing(_timeout);
                _hops = "-";
                _isOnline = false;
                addResult(0);
                _scanCompleted.PING = true;
                _clientCallback?.Invoke(_ipAddressV4, false);
            }
        }

        private void PortAsync()
        {
            try
            {
                ParallelOptions p = new ParallelOptions();
                p.CancellationToken = new CancellationToken();
                p.MaxDegreeOfParallelism = 16;
                Parallel.ForEach(_ports, p, _Port =>
                   {
                       try
                       {
                           ScanPort(_Port.Port);
                       }
                       catch (Exception ex)
                       {
                           //Console.WriteLine("PortAsync P: " + ex.Message);
                       }
                   });
                //_pingCount++;
                _scanCompleted.PORT = true;
            }
            catch (Exception e)
            {
                //Console.WriteLine("PortAsync: " +e.Message);
                _scanCompleted.PORT = true;
            }
        }

        private void Trace()
        {
            _hops = "?";
            try
            {
                System.Collections.ArrayList arlPingReply = new System.Collections.ArrayList();
                Ping myPing = new Ping();
                PingReply prResult;
                int iHopcount = 16;
                int hops = 0;
                for (int iC1 = 1; iC1 < iHopcount; iC1++)
                {
                    prResult = myPing.Send(_ipAddressV4, _timeout, new byte[10], new PingOptions(iC1, false));
                    if (prResult.Status == IPStatus.Success)
                    {
                        iC1 = iHopcount;
                        hops++;
                    }
                    arlPingReply.Add(prResult);
                }
                _hops = arlPingReply.Count.ToString();
                // _pingCount++;
                _lastHeartbeat = DateTime.Now;
                _scanCompleted.TRACE = true;
                _clientCallback?.Invoke(_ipAddressV4, true);
            }
            catch (Exception e)
            {
                //Console.WriteLine("Trace: " + e.Message);
                _hops = "-";
            }
        }

        private void RawAsync()
        {
            if (_device == "-")
            {
                _device = "?";
            }
            try
            {
                RawFinished.Reset();
                byte[] buffer = new byte[_packetSize];
                using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp))
                {
                    s.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, _timeout);
                    s.Bind(new IPEndPoint(IPAddress.Parse(_ipAddressV4interface), 0));
                    s.Blocking = false;
                    s.Ttl = short.Parse(_ttl.ToString());
                    s.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.HeaderIncluded, 1);
                    byte[] inBytes = new byte[] { 1, 0, 0, 0 };
                    byte[] outBytes = new byte[] { 0, 0, 0, 0 };
                    s.IOControl(IOControlCode.ReceiveAll, inBytes, outBytes);
                    ReceiveState so = new ReceiveState(s, buffer);
                    start = Environment.TickCount;
                    s.BeginReceive(buffer, 0, _packetSize, SocketFlags.None, RawCompletedCallback, so);
                    RawFinished.WaitOne();
                    if (s.IsBound == true)
                    {
                        s.Close();
                    }
                }
                _scanCompleted.RAW = true;
            }
            catch (SocketException e)
            {
                //Console.WriteLine("RawAsync: " + e.Message);
                _ms = "?";
                _scanCompleted.RAW = true;
            }
        }

        private void RawCompletedCallback(IAsyncResult ar)
        {
            try
            {
                ReceiveState ioContext = (ReceiveState)ar.AsyncState;
                Socket s = (Socket)ioContext.client;
                byte[] buffer = (byte[])ioContext.buffer;
                _device = "";
                //_pingCount++;
                _lastHeartbeat = DateTime.Now;
                _scanCompleted.RAW = true;
                _ms = (Environment.TickCount - start).ToString();
                _clientCallback?.Invoke(_ipAddressV4, true);
            }
            catch (Exception e)
            {
                //Console.WriteLine("RawCompletedCallback: " + e.Message);
                _device = "*";
                _ms = "?";
                _scanCompleted.RAW = true;
                _clientCallback?.Invoke(_ipAddressV4, false);
            }
        }

        private void PortConnectCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndConnect(ar);
                PortConnectFinished.Set();
                IPEndPoint ep = (IPEndPoint)client.RemoteEndPoint;
                ScanPort _p = _ports.Find(p => p.Port == ep.Port);
                _p.Open = true;
            }
            catch (Exception e)
            {
                //Console.WriteLine("PortConnectCallback: " + e.Message);
            }
        }

        private void ScanPort(int port)
        {
            IPAddress ipo = IPAddress.Parse(_ipAddressV4);
            IPEndPoint remoteEP = new IPEndPoint(ipo, port);
            try
            {
                ManualResetEvent PortConnectFinishedP = new ManualResetEvent(false);
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.Ttl = (short)_ttl;
                sock.BeginConnect(remoteEP, new AsyncCallback(PortConnectCallback), sock);
                bool success = PortConnectFinishedP.WaitOne(_timeout, true);
                /*
                if (!success)
                {
                    sock.Close();
                }
                else
                {
             
                }
                */
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
            }
            catch (Exception)
            {

            }
        }

        public void portlist()
        {
            _ports.Add(new ScanPort("FTP(21)", 21));
            _ports.Add(new ScanPort("SSH(22)", 22));
            _ports.Add(new ScanPort("TELNET(23)", 23));
            _ports.Add(new ScanPort("SMTP(25)", 25));
            _ports.Add(new ScanPort("TIME(37)", 37));
            _ports.Add(new ScanPort("DNS(53)", 53));
            _ports.Add(new ScanPort("DHCP(67)", 67));
            _ports.Add(new ScanPort("TFTP(69)", 69));
            _ports.Add(new ScanPort("HTTP(80)", 80));
            _ports.Add(new ScanPort("POP3(110)", 110));
            _ports.Add(new ScanPort("IMAP(143)", 143));
            _ports.Add(new ScanPort("HTTPS(443)", 443));
            _ports.Add(new ScanPort("TLS(465)", 465));
            _ports.Add(new ScanPort("RTSP(554)", 554));
            _ports.Add(new ScanPort("STMPS(587)", 587));
            _ports.Add(new ScanPort("FTPTLS(990)", 990));
            _ports.Add(new ScanPort("TELNETTLS(992)", 992));
            _ports.Add(new ScanPort("IMAPS(993)", 993));
            _ports.Add(new ScanPort("POP3S(995)", 995));
            _ports.Add(new ScanPort("SOCKS(1080)", 1080));
            _ports.Add(new ScanPort("MYSQL(3306)", 3306));
            _ports.Add(new ScanPort("Port(8080)", 8080));
            _ports.Add(new ScanPort("Port(8081)", 8081));
        }

        public static string LongToIP(long longIP)
        {
            string ip = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                int num = (int)(longIP / Math.Pow(256, (3 - i)));
                longIP = longIP - (long)(num * Math.Pow(256, (3 - i)));
                if (i == 0)
                    ip = num.ToString();
                else
                    ip = ip + "." + num.ToString();
            }
            return ip;
        }

        public static long IP2Long(string ip)
        {
            string[] ipBytes;
            double num = 0;
            if (!string.IsNullOrEmpty(ip))
            {
                ipBytes = ip.Split('.');
                for (int i = ipBytes.Length - 1; i >= 0; i--)
                {
                    num += ((int.Parse(ipBytes[i]) % 256) * Math.Pow(256, (3 - i)));
                }
            }
            return (long)num;
        }

        public void ResolveDNS()
        {
            ResolveState ioContext = new ResolveState(_ipAddressV4);
            var result = Dns.BeginGetHostEntry(_ipAddressV4, new AsyncCallback(ResolveCompletedCallback), ioContext);
            var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(_timeout), true);
            if (!success)
            {
                ioContext.Result = ResolveType.Timeout;
            }
            else
            {
                try
                {
                    var ipList = Dns.EndGetHostEntry(result);
                    if (ipList == null || ipList.AddressList == null || ipList.AddressList.Length == 0)
                        ioContext.Result = ResolveType.InvalidHost;
                    else
                        ioContext.Result = ResolveType.Completed;
                }
                catch
                {
                    ioContext.Result = ResolveType.InvalidHost;
                }
            }
            //return ioContext.Result == ResolveType.Completed;
        }

        public void Dispose()
        {

        }

        ~SubnetClientV4()
        {

        }

    }

}


