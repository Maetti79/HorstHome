using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using HorstHome;

namespace SubnetPing
{

    public class SubnetV4
    {

        public byte[] _SubnetOctets = new byte[4];
        public string _ipAddressV4 = "";

        public int _SubnetBase = 1;
        public int _SubnetStart = 1;
        public int _SubnetEnd = 255;
        public int _SubnetStartA = 1;
        public int _SubnetEndA = 255;
        public int _SubnetStartB = 1;
        public int _SubnetEndB = 255;
        public int _SubnetStartC = 1;
        public int _SubnetEndC = 255;

        public SubnetClassV4 _SubnetClassV4 = SubnetClassV4.C;
        public CancellationTokenSource _abort = new CancellationTokenSource();
        public List<SubnetClientV4> _SubnetClients = new List<SubnetClientV4>();

        public bool _enabled = true;
        public bool _scanned = false;
        public int iteration = 0;
        public int maxThreads = 8;
        public int _packetSize = 32;
        public int _ttl = 64;
        public int _timeout = 500;
        public bool _interface = true;
        public string _Gateway = "";
        public ScanProperties _ScanProperties = new ScanProperties();
        public ScanCompleted _ScanCompleted = new ScanCompleted();

        public List<SubnetClientV4> _SubnetClientsOnline = new List<SubnetClientV4>();
        public List<SubnetClientV4> _SubnetClientsOffline = new List<SubnetClientV4>();

        public NetworkCallback _subnetClientCallback;
        public ScanMode _scanmode = ScanMode.AUTO;
        public Stopwatch _clock = new Stopwatch();
        public long Roundtrip = 0;

        public SubnetV4(string ip, int packetSize, int ttl, int timeout)
        {

            string IpV4 = "";
            IPAddress ipAddress;
            IPHostEntry host = Dns.GetHostByName(ip.Replace("http://", "").Replace("https://", "").Replace("/", ""));
            if (IPAddress.TryParse(ip, out ipAddress))
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    IpV4 = ip;
                }
            }
            else if (host.AddressList.Length > 0)
            {
                foreach (IPAddress hostV4 in host.AddressList)
                {
                    if (hostV4.AddressFamily == AddressFamily.InterNetwork)
                    {
                        IpV4 = hostV4.ToString();
                        break;
                    }
                }
            }
            if (IpV4 != "")
            {
                _ipAddressV4 = IpV4;
                _SubnetOctets = IPAddress.Parse(IpV4).GetAddressBytes();
                _SubnetClassV4 = SubnetClassV4.C;
                _scanmode = ScanMode.AUTO;
                _enabled = true;
                _packetSize = packetSize;
                _timeout = timeout;
                _ttl = ttl;
                //_Gateway = GetDefaultGateway().ToString();
                clientList();
            }
        }

        public SubnetV4(string ip, SubnetClassV4 netclass, int packetSize, int ttl, int timeout)
        {
            _ipAddressV4 = ip;
            _SubnetOctets = IPAddress.Parse(ip).GetAddressBytes();
            _SubnetClassV4 = netclass;
            _scanmode = ScanMode.AUTO;
            _enabled = true;
            _packetSize = packetSize;
            _ttl = ttl;
            _timeout = timeout;
            clientList();
        }

        public void clientList()
        {
            _SubnetClients.Clear();
            _SubnetBase = _SubnetOctets[0];
            if (_SubnetClassV4 == SubnetClassV4.A)
            {
                _SubnetStartA = _SubnetStart;
                _SubnetEndA = _SubnetEnd;
                _SubnetStartB = _SubnetStart;
                _SubnetEndB = _SubnetEnd;
                _SubnetStartC = _SubnetStart;
                _SubnetEndC = _SubnetEnd;
            }
            if (_SubnetClassV4 == SubnetClassV4.B)
            {
                _SubnetStartA = _SubnetOctets[1];
                _SubnetEndA = _SubnetOctets[1];
                _SubnetStartB = _SubnetStart;
                _SubnetEndB = _SubnetEnd;
                _SubnetStartC = _SubnetStart;
                _SubnetEndC = _SubnetEnd;
            }
            if (_SubnetClassV4 == SubnetClassV4.C)
            {
                _SubnetStartA = _SubnetOctets[1];
                _SubnetEndA = _SubnetOctets[1];
                _SubnetStartB = _SubnetOctets[2];
                _SubnetEndB = _SubnetOctets[2];
                _SubnetStartC = _SubnetStart;
                _SubnetEndC = _SubnetEnd;
            }

            for (int octetA = _SubnetStartA; octetA <= _SubnetEndA; octetA++)
            {
                for (int octetB = _SubnetStartB; octetB <= _SubnetEndB; octetB++)
                {
                    for (int octetC = _SubnetStartC; octetC <= _SubnetEndC; octetC++)
                    {
                        string _ClientIP = _SubnetBase.ToString() + "." + octetA.ToString() + "." + octetB.ToString() + "." + octetC.ToString();
                        SubnetClientV4 _SubnetClient = new SubnetClientV4(_ClientIP.ToString());
                        _SubnetClient._ttl = _ttl;
                        _SubnetClient._packetSize = _packetSize;
                        _SubnetClient._timeout = _timeout;
                        _SubnetClient._clientCallback = SubnetClientCallback;
                        _SubnetClient._scanProperties = _ScanProperties;
                        if (_interface == true)
                        {
                            _SubnetClient._external = false;
                        }
                        else
                        {
                            _SubnetClient._external = true;
                        }
                        _SubnetClient._ipAddressV4interface = _ipAddressV4;
                        _SubnetClients.Add(_SubnetClient);
                    }
                }
            }

            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = "arp";
            process.StartInfo.Arguments = "-a -N " + _ipAddressV4.ToString();

            process.Start();
            String output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            String[] result = output.Split('\n');
            foreach (String line in result)
            {
                String ipv4tmp = _SubnetOctets[0] + "." + _SubnetOctets[1] + "." + _SubnetOctets[2];
                if (line.TrimStart().StartsWith(ipv4tmp) == true)
                {
                    String ipv4 = line.TrimStart().Substring(0, line.TrimStart().IndexOf(" "));
                    String mac = line.Substring(24, 17);
                    SubnetClientV4 Client = _SubnetClients.Find(r => r._ipAddressV4 == ipv4);
                    Client._macAddress = mac.ToLower();
                    Client._scanCompleted.ARP = true;
                }
            }
        }

        ~SubnetV4()
        {
            _subnetClientCallback = null;
            _SubnetClients.Clear();
            _SubnetClientsOnline.Clear();
            _SubnetClientsOffline.Clear();
            _abort.Dispose();
        }

        public void SubnetClientCallback(string ip, bool online)
        {
            SubnetClientV4 _client = _SubnetClients.Find(client => client._ipAddressV4 == ip);
            if (online == true)
            {
                // lock (_SubnetClientsOnline)
                //{
                if (_SubnetClientsOnline.Contains(_client) == false)
                {
                    _SubnetClientsOnline.Add(_client);
                }
                //}
                //lock (_SubnetClientsOffline)
                //{
                if (_SubnetClientsOffline.Contains(_client) == true)
                {
                    _SubnetClientsOffline.Remove(_client);
                }
                //}
            }
            else
            {
                //lock (_SubnetClientsOnline) { 
                //if (_SubnetClientsOnline.Contains(_client) == true)
                // {
                //_SubnetClientsOnline.Remove(_client);
                //} else {
                //    if (_SubnetClientsOffline.Contains(_client) == false)
                //    {
                //       _SubnetClientsOffline.Add(_client);
                //   }
                //}
                //}
                //lock (_SubnetClientsOffline)
                // {
                if (_SubnetClientsOnline.Contains(_client) == false)
                {
                    if (_SubnetClientsOffline.Contains(_client) == false)
                    {
                        _SubnetClientsOffline.Add(_client);
                    }
                }
                //}
            }
            //if ( online == true)
            //{
            _subnetClientCallback?.Invoke(_client);
            //}
        }

        public void ScanSubnet(object sender, DoWorkEventArgs e, Boolean offline = false)
        {
            Application.DoEvents();
            _abort = new CancellationTokenSource();
            _clock.Reset();
            _clock.Start();
            //_scanmode = ScanMode.RAW;
            if (_scanned == false)
            {
                ScanInitial(_scanmode);
                _scanned = true;
            }
            else if (offline == true)
            {
                ScanOffline(_scanmode);
            }
            else
            {
                ScanOnline(_scanmode);
            }
            _abort.Cancel();
            _clock.Stop();
            Roundtrip = _clock.ElapsedMilliseconds;
            iteration++;
        }

        public void ScanInitial(ScanMode scanmode)
        {
            try
            {
                ParallelOptions pop = new ParallelOptions();
                pop.CancellationToken = _abort.Token;
                pop.MaxDegreeOfParallelism = maxThreads;
                lock (_SubnetClients)
                {
                    Parallel.ForEach(_SubnetClients, pop, _client =>
                    {
                        try
                        {
                            _client.Refresh(_ScanProperties, scanmode);
                        }
                        catch (Exception e)
                        {
                            //Console.WriteLine("ScanInitial P: " + e.Message);
                        }
                    });

                }
            }
            catch (OperationCanceledException e)
            {
                //Console.WriteLine("ScanInitial Cancel: " + e.Message);
            }
        }

        public void ScanOnline(ScanMode scanmode)
        {
            try
            {
                ParallelOptions pop = new ParallelOptions();
                pop.CancellationToken = _abort.Token;
                pop.MaxDegreeOfParallelism = maxThreads;
                lock (_SubnetClientsOnline)
                {
                    Parallel.ForEach(_SubnetClientsOnline, pop, _client =>
                    {
                        try
                        {
                            _client.Refresh(_ScanProperties, scanmode);
                        }
                        catch (Exception e)
                        {
                            //Console.WriteLine("ScanOnline P: " + e.Message);
                        }
                    });
                }
            }
            catch (OperationCanceledException e)
            {
                //Console.WriteLine("ScanOnline Cancel: " + e.Message);
            }
        }

        public void ScanOffline(ScanMode scanmode)
        {
            try
            {
                ParallelOptions pop = new ParallelOptions();
                pop.CancellationToken = _abort.Token;
                pop.MaxDegreeOfParallelism = maxThreads;
                ScanProperties _ScanPropertiesOffline = new ScanProperties();
                _ScanPropertiesOffline.ARP = false;
                _ScanPropertiesOffline.PING = true;
                _ScanPropertiesOffline.DNS = false;
                _ScanPropertiesOffline.TRACE = false;
                _ScanPropertiesOffline.PORT = false;
                _ScanPropertiesOffline.RAW = false;
                ScanMode scanmodeOffile = ScanMode.AUTO;
                lock (_SubnetClientsOffline)
                {
                    Parallel.ForEach(_SubnetClientsOffline, pop, _client =>
                    {
                        try
                        {
                            _client.Refresh(_ScanPropertiesOffline, scanmodeOffile);
                        }
                        catch (Exception e)
                        {
                            //Console.WriteLine("ScanOffline P: " + e.Message);
                        }
                    });
                }
            }
            catch (OperationCanceledException e)
            {
                //Console.WriteLine("ScanOffline Cancel: " + e.Message);
            }
        }

        public IPAddress GetDefaultGateway()
        {
            NetworkInterface card = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault();
            if (card == null)
                return null;
            GatewayIPAddressInformation address = card.GetIPProperties().GatewayAddresses.FirstOrDefault();
            if (address == null)
                return null;
            return address.Address;
        }

    }

}
