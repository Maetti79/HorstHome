using System;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text;
using SubnetPing;
using System.Windows.Forms;
using System.ComponentModel;

namespace HorstHome
{
    
    public delegate void DeviceCallback(SmartDevice device);
    public delegate void GroupCallback(SmartDeviceGroup group);
    public delegate void ColorCallback(SmartDeviceColor color);
    public delegate void TemplcateCallback(SmartDeviceTemplate template);
    public delegate void StatsCallback(SmartDeviceStats stats);
    public delegate void EventCallback(SmartDeviceEvent e);
    public delegate void NetworkCallback(SubnetClientV4 device);

    public class FritzBox : IDisposable
    {
        public String Name;
        public String Uri;
        public String Username;
        public String Password;
        public String SID;

        public Int32 iconId;

        public Dictionary<String, String> Info;

        public List<SmartDevice> Devices;
        public List<SmartDeviceGroup> Groups;
        public List<SmartDeviceColor> Colors;
        public List<SmartDeviceTemplate> Templates;

        public DeviceCallback DevicesCallback;
        public GroupCallback GroupsCallback;
        public ColorCallback ColorsCallback;
        public TemplcateCallback TemplatesCallback;
        public NetworkCallback NetworkCallback;

        public SubnetV4 LocalSubnetV4;
        public Timer timer;
        public BackgroundWorker backgroundWorker;
        
        enum NodeTypes
        {
            HasChildren,
            IsNode,
            IsAttribute
        }

        public FritzBox()
        {
            Devices = new List<SmartDevice>();
            Groups = new List<SmartDeviceGroup>();
            Colors = new List<SmartDeviceColor>();
            Info = new Dictionary<String, String>();
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
            iconId = 11;
        }

        public FritzBox(String n, String b, String u, String p)
        {
            Name = n;
            Devices = new List<SmartDevice>();
            Groups = new List<SmartDeviceGroup>();
            Colors = new List<SmartDeviceColor>();
            Info = new Dictionary<String, String>();
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
            iconId = 11;
            Uri = b;
            Username = u;
            Password = p;
        }

        public Boolean info()
        {
            try
            {
                XDocument doc = XDocument.Load(Uri + @"jason_boxinfo.xml");
                if (doc != null)
                {
                    foreach (XElement boxinfo in doc.Elements())
                    {
                        foreach (XElement element in boxinfo.Elements())
                        {
                            if (element.Name.LocalName.ToString() != "Flag")
                            {
                                Info.Add(element.Name.LocalName.ToString(), element.Value);
                            }
                        }
                    }
                    if (Info["Name"].ToString().Contains("7490"))
                    {
                        iconId = 11;
                    }
                    if (Info["Name"].ToString().Contains("7590"))
                    {
                        iconId = 12;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex) {
                return false;
            }
        }

        public Boolean connect()
        {
            try
            {
                XDocument doc = XDocument.Load(Uri + @"login_sid.lua");
                SID = GetValue(doc, "SID");
                if (SID == "0000000000000000")
                {
                    String challenge = GetValue(doc, "Challenge");
                    doc = XDocument.Load(Uri + @"login_sid.lua?username=" + Username + @"&response=" + GetResponse(challenge, Password));
                    SID = GetValue(doc, "SID");
                }
                if (SID != "0000000000000000")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex) {
                return false;
            }
        }

        private String GetResponse(string challenge, string kennwort)
        {
            return challenge + "-" + GetMD5Hash(challenge + "-" + kennwort);
        }

        private String GetMD5Hash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Unicode.GetBytes(input));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString();
        }

        private String GetValue(XDocument doc, string name)
        {
            XElement info = doc.FirstNode as XElement;
            return info.Element(name).Value;
        }

        public void getDevicelist(DeviceCallback callback)
        {
            try
            {
                DevicesCallback = callback;
                Devices = new List<SmartDevice>();
                Groups = new List<SmartDeviceGroup>();

                XDocument doc;
                doc = XDocument.Load(Uri + @"webservices/homeautoswitch.lua?sid=" + SID + "&switchcmd=getdevicelistinfos");

                //Add Devices
                foreach (XElement Xdevice in doc.Element("devicelist").Elements())
                {
                    XElement name = Xdevice.Element("name");
                    if (Xdevice.Name == "device")
                    {
                        SmartDevice d = SmartDeviceFactory.getSmartDevice(Xdevice);
                        if (d.GetType() != typeof(Default))
                        {
                            Devices.Add(d);
                        }
                    }
                }

                //Add Groups
                foreach (XElement Xdevice in doc.Element("devicelist").Elements())
                {
                    XElement name = Xdevice.Element("name");
                    if (Xdevice.Name == "group")
                    {
                        SmartDeviceGroup Group = new SmartDeviceGroup(name.Value);
                        XElement groupinfo = Xdevice.Element("groupinfo");
                        XElement members = groupinfo.Element("members");
                        foreach (SmartDevice device in Devices)
                        {

                            if (members.Value.ToString().Split(',').Contains(device.Id.ToString()))
                            {
                                Group.addDevice(device);
                                device.isGrouped = true;
                                device.Group = Group;
                                //Console.WriteLine("add " + device.Id.ToString());
                            }
                            else
                            {
                                //Console.WriteLine("skip " +device.Id.ToString());
                            }

                        }
                        if (Group.Devices.Count > 0)
                        {
                            Groups.Add(Group);
                        }
                    }
                }

                //Set Device Group
                foreach (SmartDeviceGroup group in Groups)
                {
                    foreach (SmartDevice device in Devices)
                    {
                        if (group.Devices.Contains(device))
                        {
                            device.isGrouped = true;
                            device.Group = group;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
            }
        }

        public void getColordefaults(ColorCallback callback)
        {
            try
            {
                ColorsCallback = callback;
                Colors = new List<SmartDeviceColor>();

                XDocument doc;
                doc = XDocument.Load(Uri + @"webservices/homeautoswitch.lua?sid=" + SID + "&switchcmd=getcolordefaults");

                //Add Devices
                foreach (XElement hsdefaults in doc.Element("colordefaults").Elements("hsdefaults").Elements())
                {
                    XElement name = hsdefaults.Element("name");
                    foreach (XElement hsc in hsdefaults.Elements("color"))
                    {
                        Colors.Add(new SmartDeviceColor(name.Value.ToString() + '_' + hsc.Attribute("sat_index").Value
                        , Int32.Parse(hsc.Attribute("hue").Value)
                        , Int32.Parse(hsc.Attribute("sat").Value)
                        , Int32.Parse(hsc.Attribute("val").Value))
                        );
                    }
                }
            }
            catch (Exception Ex)
            {
            }
        }

        public void getTemplatelist(TemplcateCallback callback)
        {
            try
            {
                TemplatesCallback = callback;
                Templates = new List<SmartDeviceTemplate>();

                XDocument doc;
                doc = XDocument.Load(Uri + @"webservices/homeautoswitch.lua?sid=" + SID + "&switchcmd=gettemplatelistinfos");

                //Add Devices
                foreach (XElement template in doc.Element("templatelist").Elements())
                {
                    XElement name = template.Element("name");
                    Templates.Add(new SmartDeviceTemplate(name.Value.ToString()));
                }
            }
            catch (Exception Ex)
            {
            }
        }

        public void getLocalNetworkDevices(NetworkCallback callback) {
            NetworkCallback = callback;
            LocalSubnetV4 = new SubnetV4(Uri, 64, 128, 1000);
            LocalSubnetV4._subnetClientCallback = LocalNetworkDevicesDetected;
            LocalSubnetV4._enabled = true;
            LocalSubnetV4.clientList();
            //LocalSubnetV4.ScanInitial(ScanMode.AUTO);
        }

        private void LocalNetworkDevicesDetected(SubnetClientV4 n)
        {
            try
            {
                if (n._isOnline == true)
                {
                    NetworkCallback?.Invoke(n);
                }
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Update: " + ex.Message);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy == false)
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            if (worker.CancellationPending)
            {
                return;
            }
            else
            {
                LocalSubnetV4.ScanSubnet(sender, e, false);
            }
        }

        public void Dispose()
        {

        }

        ~FritzBox()
        {

        }

    }
}
