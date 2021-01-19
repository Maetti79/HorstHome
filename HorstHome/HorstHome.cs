using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;
using System.Collections.Generic;
using System.Resources;
using System.ComponentModel;
using SubnetPing;

namespace HorstHome
{
    public partial class HorstHome : Form
    {
        public PluginCore pluginCore = new PluginCore(Environment.CurrentDirectory);
        public String serialManager = Serial.GetSerialNumber();
        public String licenseInformation = "";
        public String[] Error;
        private Int32 BatteryWarning = 5;

        public List<FritzBox> fritzBoxes;
        public CultureInfo culture;
        public ResourceManager rm;
        public NotifyIcon trayIcon;
        public ContextMenuStrip trayMenu;
        String BNodeName;
        TreeNode BNode;
        TreeNode NGNode;

        public HorstHome()
        {
            InitializeComponent();
            try
            {
                culture = CultureInfo.CurrentCulture;

                trayMenu = new ContextMenuStrip();
                trayMenu.ImageList = Icons;
                if (culture.ToString() == "de-DE")
                {
                    trayMenu.Items.Add(i18n.de.Tray_Quit.ToString(), Icons.Images[13], OnExit);
                }
                else
                {
                    trayMenu.Items.Add(i18n.en.Tray_Quit.ToString(), Icons.Images[13], OnExit);
                }

                trayIcon = new NotifyIcon();
                trayIcon.Text = "Horst!Home";
                trayIcon.Icon = Icon.FromHandle(((Bitmap)TrayIcons.Images[0]).GetHicon());

                trayIcon.ContextMenuStrip = trayMenu;
                trayIcon.Visible = true;
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.Show();
                fritzBoxes = new List<FritzBox>();
                reload();
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void reload()
        {
            try
            {
                changeCulture(culture.ToString());
                if (loadLicense() == true && loadConnection() == true)
                {
                    loadFritzboxes();
                }

                SmartDeviceTreeView.Nodes.Clear();
                trayMenu.Items.Clear();
                foreach (FritzBox fritzBox in fritzBoxes)
                {
                    loadDevices(fritzBox);
                    loadGroups(fritzBox);
                    loadNetwork(fritzBox);
                    BatteryWarnings(fritzBox);
                }
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private Boolean loadFritzboxes()
        {
            try
            {
                foreach (FritzBox fritzBox in fritzBoxes)
                {
                    loadFritzbox(fritzBox);
                }
                return true;
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                return false;
            }
        }

        private Boolean loadFritzbox(FritzBox fritzBox)
        {
            try
            {
                fritzBox.info();
                if (fritzBox.connect() == true)
                {
                    fritzBox.getDevicelist(DevicelistCallback);
                    fritzBox.getColordefaults(ColordefaultsCallback);
                    fritzBox.getTemplatelist(TemplatelistCallback);
                    loadDevices(fritzBox);
                    loadGroups(fritzBox);
                    BatteryWarnings(fritzBox);
                    //Async Callback
                    fritzBox.getLocalNetworkDevices(NetworkCallback);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                return false;
            }
        }

        private void loadDevices(FritzBox fritzBox)
        {
            try
            {
                BNodeName = fritzBox.Name;

                BNode = new TreeNode(BNodeName);
                BNode.ImageIndex = fritzBox.iconId;
                BNode.SelectedImageIndex = fritzBox.iconId;
                SmartDeviceTreeView.Nodes.Add(BNode);

                ToolStripMenuItem BoxMenu = new ToolStripMenuItem(BNodeName, Icons.Images[fritzBox.iconId]);
                BoxMenu.Click += trayMenu_ItemClicked;
                trayMenu.Items.Add(BoxMenu);
                foreach (SmartDeviceGroup group in fritzBox.Groups)
                {
                    String GNodeName = group.GroupName;

                    TreeNode GNode = new TreeNode(GNodeName);
                    GNode.ImageIndex = group.iconId;
                    GNode.SelectedImageIndex = group.iconId;
                    BNode.Nodes.Add(GNode);

                    ToolStripMenuItem GMenu = new ToolStripMenuItem(GNodeName, Icons.Images[group.iconId]);
                    GMenu.Click += trayMenu_ItemClicked;
                    trayMenu.Items.Add(GMenu);

                    foreach (SmartDevice device in fritzBox.Devices)
                    {
                        if (group.Devices.Contains(device) && device.isGrouped == true)
                        {
                            String DNodeName = device.DeviceName;

                            TreeNode DNode = new TreeNode(DNodeName);
                            DNode.ImageIndex = device.iconId;
                            DNode.SelectedImageIndex = device.iconId;
                            if (device.isConnected == false)
                            {
                                DNode.ForeColor = Color.Gray;
                            }
                            else
                            {
                                DNode.ForeColor = Color.Black;
                            }
                            GNode.Nodes.Add(DNode);

                            ToolStripMenuItem DMenu = new ToolStripMenuItem(DNodeName, Icons.Images[device.iconId]);
                            DMenu.Click += trayMenu_ItemClicked;
                            GMenu.DropDownItems.Add(DMenu);
                        }
                    }
                }

            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void loadGroups(FritzBox fritzBox)
        {
            try
            {
                foreach (SmartDevice device in fritzBox.Devices)
                {
                    if (device.isGrouped == false)
                    {
                        String DNodeName = device.DeviceName;

                        TreeNode DNode = new TreeNode(DNodeName);
                        DNode.ImageIndex = device.iconId;
                        DNode.SelectedImageIndex = device.iconId;
                        if (device.isConnected == false)
                        {
                            DNode.ForeColor = Color.Gray;
                        }
                        else
                        {
                            DNode.ForeColor = Color.Black;
                        }
                        BNode.Nodes.Add(DNode);

                        ToolStripMenuItem DMenu = new ToolStripMenuItem(DNodeName, Icons.Images[device.iconId]);
                        DMenu.Click += trayMenu_ItemClicked;
                        trayMenu.Items.Add(DMenu);
                    }
                }
                trayMenu.Items.Add("-");
                trayMenu.Items.Add("Beenden", Icons.Images[0], OnExit);
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        public void loadNetwork(FritzBox fritzBox)
        {
            try
            {
                NGNode = new TreeNode("Network");
                NGNode.ImageIndex = 14;
                NGNode.SelectedImageIndex = 14;
                NGNode.ForeColor = Color.Black;
                BNode.Nodes.Add(NGNode);
                foreach (SubnetPing.SubnetClientV4 ClientV4 in fritzBox.LocalSubnetV4._SubnetClients)
                {
                    if (ClientV4._isOnline == true)
                    {
                        TreeNode NDNode = new TreeNode(ClientV4._ipAddressV4.ToString());
                        NDNode.ImageIndex = 14;
                        NDNode.SelectedImageIndex = 14;

                        NDNode.ForeColor = Color.Black;

                        NGNode.Nodes.Add(NDNode);
                    }
                }
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void trayMenu_ItemClicked(object sender, EventArgs e)
        {
            try
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                SmartDeviceTreeView.SelectedNode = GetNodeByName(SmartDeviceTreeView.Nodes, sender.ToString());
                SmartDeviceTreeView.Select();
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }

        }

        private TreeNode GetNodeByName(TreeNodeCollection nodes, string searchtext)
        {
            try
            {
                TreeNode n_found_node = null;
                bool b_node_found = false;

                foreach (TreeNode node in nodes)
                {

                    if (node.Text == searchtext)
                    {
                        b_node_found = true;
                        n_found_node = node;

                        return n_found_node;
                    }

                    if (!b_node_found)
                    {
                        n_found_node = GetNodeByName(node.Nodes, searchtext);

                        if (n_found_node != null)
                        {
                            return n_found_node;
                        }
                    }
                }
                return null;
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                return null;
            }
        }

        public Boolean loadLicense()
        {
            try
            {
                licenseInformation = Serial.CallWebservice("https://HorstHome.purepix.net/", Serial.GetSerialNumber()).Trim();
                Microsoft.Win32.RegistryKey key;
                string rootKey = "SOFTWARE\\" + Assembly.GetExecutingAssembly().GetName().Name;
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
                if (key == null)
                {
                    key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
                }
                key.SetValue("LicenseInformation", licenseInformation);
                key.Close();
                return true;
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                return false;
            }
        }

        public Boolean loadPlugins()
        {
            try
            {
                Array pls = pluginCore.getPlugins(licenseInformation);
                /*
                foreach (Object pl in pls)
                {
                    Console.WriteLine(pl.ToString());
                }
                */
                return true;
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                return false;
            }
        }

        public Boolean loadConnection()
        {
            try
            {
                Microsoft.Win32.RegistryKey key;
                Microsoft.Win32.RegistryKey subkey;
                string rootKey = "SOFTWARE\\" + Assembly.GetExecutingAssembly().GetName().Name + "\\Connections";
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(rootKey);
                if (key == null)
                {
                    key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
                }
                foreach (String subKeyName in key.GetSubKeyNames())
                {
                    subkey = key.OpenSubKey(subKeyName);
                    if (subkey != null)
                    {
                        String UriTxt = subkey.GetValue("FritzBoxUri", "http://fritz.box/").ToString();
                        String UsernameTxt = subkey.GetValue("Username", "").ToString();
                        String Salt = StringEncryptor.GenerateAPassKey(Serial.cpuSerial());
                        String PasswordTxt = "";
                        if (subkey.GetValue("Password", "").ToString() != "")
                        {
                            PasswordTxt = StringEncryptor.Decrypt(subkey.GetValue("Password", "").ToString(), Salt);
                        }
                        fritzBoxes.Add(new FritzBox(subKeyName, UriTxt, UsernameTxt, PasswordTxt));
                    }
                }
                key.Close();
                return true;
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                return false;
            }
        }

        public Boolean saveSettings()
        {
            try
            {
                Microsoft.Win32.RegistryKey key;
                string rootKey = "SOFTWARE\\" + Assembly.GetExecutingAssembly().GetName().Name;
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
                if (key == null)
                {
                    key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
                }
                key.SetValue("Culture", CultureInfo.CurrentCulture.ToString());
                key.Close();
                return true;
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                return false;
            }
        }

        private void DevicelistCallback(SmartDevice device)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    if (GetNodeByName(NGNode.Nodes, device.DeviceName) != null)
                    {

                    }
                }));
                Application.DoEvents();
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void ColordefaultsCallback(SmartDeviceColor color)
        {
            try
            {
                Invoke(new Action(() =>
                {

                }));
                Application.DoEvents();
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void TemplatelistCallback(SmartDeviceTemplate template)
        {
            try
            {
                Invoke(new Action(() =>
                {

                }));
                Application.DoEvents();
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void StatsCallback(SmartDeviceStats stats)
        {
            try
            {
                Invoke(new Action(() =>
                {

                }));
                Application.DoEvents();
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void NetworkCallback(SubnetClientV4 client)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    if (GetNodeByName(NGNode.Nodes, client._ipAddressV4.ToString()) == null)
                    {
                        TreeNode NDNode = new TreeNode(client._ipAddressV4);
                        NDNode.ImageIndex = 14;
                        NDNode.SelectedImageIndex = 14;
                        if (client._isOnline == true)
                        {
                            NDNode.ForeColor = Color.Black;
                        }
                        else
                        {
                            NDNode.ForeColor = Color.Gray;
                        }
                        NGNode.Nodes.Add(NDNode);
                    }
                    else
                    {
                        TreeNode NDNode = GetNodeByName(NGNode.Nodes, client._ipAddressV4.ToString());
                        if (client._isOnline == true)
                        {
                            NDNode.ForeColor = Color.Black;
                        }
                        else
                        {
                            NDNode.ForeColor = Color.Gray;
                        }
                    }
                }));
                Application.DoEvents();
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        public void loadSettings()
        {
            try
            {
                Microsoft.Win32.RegistryKey key;
                Microsoft.Win32.RegistryKey subkey;
                string rootKey = "SOFTWARE\\" + Assembly.GetExecutingAssembly().GetName().Name;
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(rootKey);
                if (key == null)
                {
                    key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
                }
                subkey = key.OpenSubKey("FritzBox");
                if (subkey != null)
                {
                    String c = subkey.GetValue("Culture", "de-DE").ToString();
                    CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(c);
                    CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(c);
                }
                if (key != null)
                {
                    key.Close();
                }
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        public void changeCulture(String c)
        {
            try
            {
                if (c != "de-DE")
                {
                    c = "en-US";
                }
                culture = new CultureInfo(c);
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(c);
                CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(c);

                if (culture.ToString() == "de-DE")
                {
                    MainMenu.Items.Find("FritzboxToolStripMenuItem", true)[0].Text = i18n.de.Menu_Fritzbox.ToString();
                    MainMenu.Items.Find("SettingsToolStripMenuItem", true)[0].Text = i18n.de.Menu_Settings.ToString();
                    MainMenu.Items.Find("QuitToolStripMenuItem", true)[0].Text = i18n.de.Menu_Quit.ToString();

                    MainMenu.Items.Find("LanguageToolStripMenuItem", true)[0].Text = i18n.de.Menu_Language.ToString();
                    MainMenu.Items.Find("LanguageDEToolStripMenuItem", true)[0].Text = i18n.de.Menu_DE.ToString();
                    ToolStripMenuItem d = (ToolStripMenuItem)MainMenu.Items.Find("LanguageDEToolStripMenuItem", true)[0];
                    d.Checked = true;
                    MainMenu.Items.Find("LanguageENToolStripMenuItem", true)[0].Text = i18n.de.Menu_EN.ToString();
                    ToolStripMenuItem e = (ToolStripMenuItem)MainMenu.Items.Find("LanguageENToolStripMenuItem", true)[0];
                    e.Checked = false;

                    MainMenu.Items.Find("AboutToolStripMenuItem", true)[0].Text = i18n.de.Menu_About.ToString();
                    MainMenu.Items.Find("LicenseToolStripMenuItem", true)[0].Text = i18n.de.Menu_License.ToString();
                    MainMenu.Items.Find("UpdateToolStripMenuItem", true)[0].Text = i18n.de.Menu_Update.ToString();
                }
                else
                {
                    MainMenu.Items.Find("FritzboxToolStripMenuItem", true)[0].Text = i18n.en.Menu_Fritzbox.ToString();
                    MainMenu.Items.Find("SettingsToolStripMenuItem", true)[0].Text = i18n.en.Menu_Settings.ToString();
                    MainMenu.Items.Find("QuitToolStripMenuItem", true)[0].Text = i18n.en.Menu_Quit.ToString();

                    MainMenu.Items.Find("LanguageToolStripMenuItem", true)[0].Text = i18n.en.Menu_Language.ToString();
                    MainMenu.Items.Find("LanguageDEToolStripMenuItem", true)[0].Text = i18n.en.Menu_DE.ToString();
                    ToolStripMenuItem d = (ToolStripMenuItem)MainMenu.Items.Find("LanguageDEToolStripMenuItem", true)[0];
                    d.Checked = true;
                    MainMenu.Items.Find("LanguageENToolStripMenuItem", true)[0].Text = i18n.en.Menu_EN.ToString();
                    ToolStripMenuItem e = (ToolStripMenuItem)MainMenu.Items.Find("LanguageENToolStripMenuItem", true)[0];
                    e.Checked = false;

                    MainMenu.Items.Find("AboutToolStripMenuItem", true)[0].Text = i18n.en.Menu_About.ToString();
                    MainMenu.Items.Find("LicenseToolStripMenuItem", true)[0].Text = i18n.en.Menu_License.ToString();
                    MainMenu.Items.Find("UpdateToolStripMenuItem", true)[0].Text = i18n.en.Menu_Update.ToString();
                }
                saveSettings();
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void OnExit(object sender, EventArgs e)
        {
            try
            {
                trayIcon.Visible = false;
                Application.Exit();
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (Form sform = new Settings())
                {
                    var result = sform.ShowDialog();
                    if (result == DialogResult.OK)
                    {

                    }
                }
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void deviceTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (SmartDeviceTreeView.SelectedNode != null)
                {
                    foreach (FritzBox fritzBox in fritzBoxes)
                    {
                        if (fritzBox.Info.Count > 0)
                        {
                            if (fritzBox.Name == SmartDeviceTreeView.SelectedNode.Text.ToString())
                            {
                                SmartDeviceTabContainer.TabPages.Clear();
                                FritzboxView fbv = new FritzboxView(this, fritzBox);
                                fbv.Dock = DockStyle.Fill;
                                TabPage DeviceInfoTab = new TabPage(fritzBox.Name);
                                DeviceInfoTab.Controls.Add(fbv);
                                SmartDeviceTabContainer.TabPages.Add(DeviceInfoTab);
                                Application.DoEvents();
                            }
                        }

                        using (SmartDeviceGroup group = fritzBox.Groups.Find(x => x.GroupName.Equals(SmartDeviceTreeView.SelectedNode.Text.ToString())))
                        {
                            if (group != null)
                            {
                                SmartDeviceTabContainer.TabPages.Clear();
                                GroupView gv = new GroupView(this, fritzBox.Uri, fritzBox.SID, group);
                                gv.Dock = DockStyle.Fill;
                                TabPage DeviceInfoTab = new TabPage(group.GroupName);
                                DeviceInfoTab.Controls.Add(gv);
                                SmartDeviceTabContainer.TabPages.Add(DeviceInfoTab);
                                Application.DoEvents();
                            }
                        }

                        using (SmartDevice device = fritzBox.Devices.Find(x => x.DeviceName.Equals(SmartDeviceTreeView.SelectedNode.Text.ToString())))
                        {
                            if (device != null)
                            {
                                SmartDeviceTabContainer.TabPages.Clear();
                                device.tryUpdate(fritzBox.Uri, fritzBox.SID);
                                if (device.SupportedFunctions.hasFlag(SmartDeviceFunctionType.Thermostat))
                                {
                                    ThermostatView thv = new ThermostatView(this, fritzBox.Uri, fritzBox.SID, device);
                                    thv.Dock = DockStyle.Fill;
                                    TabPage DeviceInfoTab = new TabPage(device.DeviceName);
                                    DeviceInfoTab.Controls.Add(thv);
                                    SmartDeviceTabContainer.TabPages.Add(DeviceInfoTab);
                                }
                                else if (device.SupportedFunctions.hasFlag(SmartDeviceFunctionType.Switch))
                                {
                                    SocketView sv = new SocketView(this, fritzBox.Uri, fritzBox.SID, device);
                                    sv.Dock = DockStyle.Fill;
                                    TabPage DeviceInfoTab = new TabPage(device.DeviceName);
                                    DeviceInfoTab.Controls.Add(sv);
                                    SmartDeviceTabContainer.TabPages.Add(DeviceInfoTab);
                                }
                                else if (device.SupportedFunctions.hasFlag(SmartDeviceFunctionType.Color))
                                {
                                    LightView lv = new LightView(this, fritzBox.Uri, fritzBox.SID, device);
                                    lv.Dock = DockStyle.Fill;
                                    TabPage DeviceInfoTab = new TabPage(device.DeviceName);
                                    DeviceInfoTab.Controls.Add(lv);
                                    SmartDeviceTabContainer.TabPages.Add(DeviceInfoTab);
                                }
                                else
                                {
                                    AlarmView av = new AlarmView(this, fritzBox.Uri, fritzBox.SID, device);
                                    av.Dock = DockStyle.Fill;
                                    TabPage DeviceInfoTab = new TabPage(device.DeviceName);
                                    DeviceInfoTab.Controls.Add(av);
                                    SmartDeviceTabContainer.TabPages.Add(DeviceInfoTab);
                                }

                                if (device.SupportedFunctions.hasFlag(SmartDeviceFunctionType.Energie))
                                {
                                    EnergieChart ec = new EnergieChart(this, fritzBox.Uri, fritzBox.SID, device);
                                    ec.Dock = DockStyle.Fill;
                                    TabPage EnergieTab = new TabPage("Energie");
                                    EnergieTab.Controls.Add(ec);
                                    SmartDeviceTabContainer.TabPages.Add(EnergieTab);
                                }
                                if (device.SupportedFunctions.hasFlag(SmartDeviceFunctionType.Energie))
                                {
                                    VoltageChart vc = new VoltageChart(this, fritzBox.Uri, fritzBox.SID, device);
                                    vc.Dock = DockStyle.Fill;
                                    TabPage VoltageTab = new TabPage("Voltage");
                                    VoltageTab.Controls.Add(vc);
                                    SmartDeviceTabContainer.TabPages.Add(VoltageTab);
                                }
                                if (device.SupportedFunctions.hasFlag(SmartDeviceFunctionType.Energie))
                                {
                                    PowerChart pc = new PowerChart(this, fritzBox.Uri, fritzBox.SID, device);
                                    pc.Dock = DockStyle.Fill;
                                    TabPage PowerTab = new TabPage("Power");
                                    PowerTab.Controls.Add(pc);
                                    SmartDeviceTabContainer.TabPages.Add(PowerTab);
                                }
                                if (device.SupportedFunctions.hasFlag(SmartDeviceFunctionType.Thermometer))
                                {
                                    TemperatureChart tc = new TemperatureChart(this, fritzBox.Uri, fritzBox.SID, device);
                                    tc.Dock = DockStyle.Fill;
                                    TabPage TemperatureTab = new TabPage("Temperature");
                                    TemperatureTab.Controls.Add(tc);
                                    SmartDeviceTabContainer.TabPages.Add(TemperatureTab);
                                }
                                Application.DoEvents();
                            }
                        }

                        using (SubnetClientV4 client = fritzBox.LocalSubnetV4._SubnetClients.Find(x => x._ipAddressV4.Equals(SmartDeviceTreeView.SelectedNode.Text.ToString())))
                        {
                            if (client != null)
                            {
                                SmartDeviceTabContainer.TabPages.Clear();
                                NetworkView  nv = new NetworkView(this, fritzBox.Uri, fritzBox.SID, client);
                                nv.Dock = DockStyle.Fill;
                                TabPage DeviceInfoTab = new TabPage(client._ipAddressV4);
                                DeviceInfoTab.Controls.Add(nv);
                                SmartDeviceTabContainer.TabPages.Add(DeviceInfoTab);
                                Application.DoEvents();
                            }
                        }
                    }
                }

                /*
                using (SmartDevice device = box.Devices.Find(x => x.DeviceName.Equals(deviceTree.SelectedNode.Text.ToString())))
                {
                    Random r = new Random();
                    int rr = r.Next(0, box.Colors.Count - 1);
                    SmartDeviceColor c = box.Colors[rr];
                    device.setLevel(box.Uri, box.SID, c.Value);
                    device.setColor(box.Uri, box.SID, c.Hue, c.Saturation, 5);
                }
                */
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void languageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deutschdeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                changeCulture("de-DE");
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void englischENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                changeCulture("en-US");
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void HorstHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    trayIcon.Visible = true;
                    this.Hide();
                    e.Cancel = true;
                }
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void ShowEvent(String Titel, String Message)
        {
            try
            {
                trayIcon.BalloonTipText = Titel;
                trayIcon.BalloonTipTitle = Message;
                trayIcon.ShowBalloonTip(500);
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void MinimzedTray()
        {
            try
            {
                trayIcon.Visible = true;
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void MaxmizedFromTray()
        {
            try
            {
                trayIcon.Visible = true;
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void HorstHome_Resize(object sender, EventArgs e)
        {
            try
            {
                if (FormWindowState.Minimized == this.WindowState)
                {
                    MinimzedTray();
                }
                else if (FormWindowState.Normal == this.WindowState)
                {

                    MaxmizedFromTray();
                }
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        public void errorLog(String Class, Exception ErrorMsg)
        {
            try
            {
                Error = Error.AddItemToArray(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") + " [" + Class + "] " + ErrorMsg.Message);
                Console.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") + " [" + Class + "] " + ErrorMsg.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(ErrorMsg.Message);
                Console.WriteLine(e.Message);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var sform = new LicenseForm(this))
                {
                    var result = sform.ShowDialog();
                    if (result == DialogResult.OK)
                    {

                    }
                }
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void ReloadTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                foreach (FritzBox fritzBox in fritzBoxes)
                {
                    fritzBox.info();
                    if (fritzBox.connect() == true)
                    {
                        fritzBox.getDevicelist(DevicelistCallback);
                        BatteryWarnings(fritzBox);
                    }
                }
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (Form sform = new Settings(this))
                {
                    var result = sform.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        reload();
                    }
                }
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                trayIcon.Visible = false;
                Application.Exit();
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void SmartDeviceTab_Click(object sender, EventArgs e)
        {

        }

        private void BatteryWarnings(FritzBox fritzBox)
        {

            try
            {
                foreach (SmartDevice d in fritzBox.Devices)
                {
                    if (d.Battery <= BatteryWarning)
                    {
                        DateTime Now = DateTime.Now;
                        if (Now.Subtract(d.LastWarning).TotalMinutes > 60)
                        {
                            d.LastWarning = DateTime.Now;
                            ShowEvent(fritzBox.Name + " " + d.DeviceName, "Battery: " + d.Battery + "%");
                            //Console.WriteLine(d.DeviceName + " Battery: " + d.Battery + "%");
                        }
                    }
                }
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void MainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fritzBoxSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextMenu.Items.Clear();
            if (SmartDeviceTreeView.SelectedNode == null)
            {
                ToolStripMenuItem CMenu = new ToolStripMenuItem("Add Fritzbox", Icons.Images[11]);
                CMenu.Click += CMenu_ItemClicked;
                contextMenu.Items.Add(CMenu);
            }
            else
            {
                foreach (FritzBox fritzBox in fritzBoxes)
                {
                    if (fritzBox.Info.Count > 0)
                    {
                        if (fritzBox.Name == SmartDeviceTreeView.SelectedNode.Text.ToString())
                        {
                            ToolStripMenuItem CMenu = new ToolStripMenuItem("Edit " + fritzBox.Name, Icons.Images[fritzBox.iconId]);
                            CMenu.Click += CMenu_ItemClicked;
                            contextMenu.Items.Add(CMenu);
                            ToolStripMenuItem DMenu = new ToolStripMenuItem("Delete " + fritzBox.Name, Icons.Images[fritzBox.iconId]);
                            DMenu.Click += DMenu_ItemClicked;
                            contextMenu.Items.Add(DMenu);
                            break;
                        }
                    }
                }
            }
            contextMenu.Show();
        }

        private void CMenu_ItemClicked(object sender, EventArgs e)
        {
            try
            {
                if (SmartDeviceTreeView.SelectedNode == null)
                {
                    using (Form sform = new Settings(this))
                    {
                        var result = sform.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            reload();
                        }
                    }
                }
                else
                {
                    using (Form sform = new Settings(this, SmartDeviceTreeView.SelectedNode.Text.ToString()))
                    {
                        var result = sform.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            reload();
                        }
                    }
                }
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void DMenu_ItemClicked(object sender, EventArgs e)
        {
            try
            {
                if (SmartDeviceTreeView.SelectedNode != null)
                {
                    using (FritzBox fritzbox = fritzBoxes.Find(x => x.Name.Equals(SmartDeviceTreeView.SelectedNode.Text.ToString())))
                    {
                        fritzBoxes.Remove(fritzbox);
                        removeConnection(fritzbox);
                    }
                    reload();
                }
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void saveConnection(FritzBox fritzBox)
        {
            try
            {
                Microsoft.Win32.RegistryKey key;
                Microsoft.Win32.RegistryKey subkey;
                string rootKey = "SOFTWARE\\" + Assembly.GetExecutingAssembly().GetName().Name + "\\Connections";
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
                if (key != null)
                {
                    subkey = key.CreateSubKey(fritzBox.Name);
                    if (subkey != null)
                    {
                        subkey.SetValue("FritzBoxUri", fritzBox.Uri);
                        subkey.SetValue("Username", fritzBox.Username);
                        if (fritzBox.Password != "")
                        {
                            String Salt = StringEncryptor.GenerateAPassKey(Serial.cpuSerial());
                            subkey.SetValue("Password", StringEncryptor.Encrypt(fritzBox.Password, Salt));
                        }
                    }
                    key.Close();
                }
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

        public void removeConnection(FritzBox fritzBox)
        {
            try
            {
                Microsoft.Win32.RegistryKey key;
                string rootKey = "SOFTWARE\\" + Assembly.GetExecutingAssembly().GetName().Name + "\\Connections";
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
                if (key != null)
                {
                    key.DeleteSubKeyTree(fritzBox.Name);
                    key.Close();
                }
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
            }
        }

    }
}
