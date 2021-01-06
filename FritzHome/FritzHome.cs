﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;
using System.Resources;

namespace FritzHome
{
    public partial class FritzHome : Form
    {
        public PluginCore pluginCore = new PluginCore(Environment.CurrentDirectory);
        public String serialManager = Serial.GetSerialNumber();
        public String licenseInformation = "";
        public String[] Error;
        private Int32 BatteryWarning = 5;

        public FritzBox fritzBox = new FritzBox();
        public CultureInfo culture;
        public ResourceManager rm;
        public NotifyIcon trayIcon;
        public ContextMenuStrip trayMenu;

        public FritzHome()
        {
            InitializeComponent();
            culture = CultureInfo.CurrentCulture;

            trayMenu = new ContextMenuStrip();
            trayMenu.ImageList = Icons;
            trayMenu.Items.Add("Beenden", Icons.Images[0], OnExit);

            trayIcon = new NotifyIcon();
            trayIcon.Text = "Fritz!";
            trayIcon.Icon = Icon.FromHandle(((Bitmap)TrayIcons.Images[0]).GetHicon());

            trayIcon.ContextMenuStrip = trayMenu;
            trayIcon.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            changeCulture(culture.ToString());
            loadLicense();
            loadConnection();
            fritzBox.info();
            if (fritzBox.connect() == true)
            {
                fritzBox.getDevicelist();
                fritzBox.getColordefaults();
                fritzBox.getTemplatelist();
            }

            BatteryWarnings();

            SmartDeviceTreeView.Nodes.Clear();
            trayMenu.Items.Clear();

            String BNodeName = fritzBox.Info["Name"];

            TreeNode BNode = new TreeNode(BNodeName);
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
                        GNode.Nodes.Add(DNode);

                        ToolStripMenuItem DMenu = new ToolStripMenuItem(DNodeName, Icons.Images[device.iconId]);
                        DMenu.Click += trayMenu_ItemClicked;
                        GMenu.DropDownItems.Add(DMenu);
                    }
                }
            }

            foreach (SmartDevice device in fritzBox.Devices)
            {
                if (device.isGrouped == false)
                {
                    String DNodeName = device.DeviceName;

                    TreeNode DNode = new TreeNode(DNodeName);
                    DNode.ImageIndex = device.iconId;
                    DNode.SelectedImageIndex = device.iconId;
                    BNode.Nodes.Add(DNode);

                    ToolStripMenuItem DMenu = new ToolStripMenuItem(DNodeName, Icons.Images[device.iconId]);
                    DMenu.Click += trayMenu_ItemClicked;
                    trayMenu.Items.Add(DMenu);
                }
            }
            trayMenu.Items.Add("-");
            trayMenu.Items.Add("Beenden", Icons.Images[0], OnExit);
        }

        private void trayMenu_ItemClicked(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            SmartDeviceTreeView.SelectedNode = GetNodeByName(SmartDeviceTreeView.Nodes, sender.ToString());
            SmartDeviceTreeView.Select();
        }

        private TreeNode GetNodeByName(TreeNodeCollection nodes, string searchtext)
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

        public Boolean loadLicense()
        {
            try
            {
                licenseInformation = Serial.CallWebservice("https://fritzhome.purepix.net/", Serial.GetSerialNumber());
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

        public void loadPlugins()
        {
            try
            {
                Array pls = pluginCore.getPlugins(licenseInformation);
                foreach (Object pl in pls)
                {
                    Console.WriteLine(pl.ToString());
                }
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
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
                subkey = key.OpenSubKey("FritzBox");
                if (subkey != null)
                {
                    String UriTxt = subkey.GetValue("FritzBoxUri").ToString();
                    String UsernameTxt = subkey.GetValue("Username").ToString();
                    String PasswordTxt = subkey.GetValue("Password").ToString();
                    fritzBox = new FritzBox(UriTxt, UsernameTxt, PasswordTxt);
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
                Microsoft.Win32.RegistryKey subkey;
                string rootKey = "SOFTWARE\\" + Assembly.GetExecutingAssembly().GetName().Name + "\\Connections";
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
                if (key != null)
                {
                    subkey = key.CreateSubKey("FritzBox");
                    if (subkey != null)
                    {
                        subkey.SetValue("Culture", CultureInfo.CurrentCulture.ToString());
                    }
                    key.Close();
                }
                return true;
            }
            catch (Exception err)
            {
                errorLog(System.Reflection.MethodBase.GetCurrentMethod().Name, err);
                return false;
            }
        }

        public void loadSettings()
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
                subkey = key.OpenSubKey("FritzBox");
                if (subkey != null)
                {
                    String c = subkey.GetValue("Culture").ToString();
                    CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(c);
                    CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(c);
                }
                if (key != null)
                {
                    key.Close();
                }
            }
            catch (Exception Ex)
            {
            }
        }

        public void changeCulture(String c)
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

        private void OnExit(object sender, EventArgs e)
        {
            try
            {
                trayIcon.Visible = false;
                Application.Exit();
            }
            catch (Exception ex)
            {

            }
        }

        private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form sform = new Settings())
            {
                var result = sform.ShowDialog();
                if (result == DialogResult.OK)
                {

                }
            }
        }

        private void deviceTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (SmartDeviceTreeView.SelectedNode != null)
            {
                if (fritzBox.Info.Count > 0)
                {
                    if (fritzBox.Info["Name"].ToString() == SmartDeviceTreeView.SelectedNode.Text.ToString())
                    {
                        FritzboxView fbv = new FritzboxView(this,fritzBox);
                        fbv.Dock = DockStyle.Fill;
                        TabPage DeviceInfoTab = new TabPage(fritzBox.Info["Name"].ToString());
                        DeviceInfoTab.Controls.Add(fbv);
                        SmartDeviceTabContainer.TabPages.Clear();
                        SmartDeviceTabContainer.TabPages.Add(DeviceInfoTab);
                    }
                }

                using (SmartDeviceGroup group = fritzBox.Groups.Find(x => x.GroupName.Equals(SmartDeviceTreeView.SelectedNode.Text.ToString())))
                {
                    if (group != null)
                    {
                        //NameLbl.Text = group.GroupName;
                    }
                }

                using (SmartDevice device = fritzBox.Devices.Find(x => x.DeviceName.Equals(SmartDeviceTreeView.SelectedNode.Text.ToString())))
                {
                    if (device != null)
                    {
                        device.tryUpdate(fritzBox.Uri, fritzBox.SID);
                        SmartDeviceTabContainer.TabPages.Clear();
                        if (device.SupportedFunctions.hasFlag(SmartDeviceFunctionType.Thermostat))
                        {
                            ThermostatView thv = new ThermostatView(this,fritzBox.Uri, fritzBox.SID, device);
                            thv.Dock = DockStyle.Fill;
                            TabPage DeviceInfoTab = new TabPage(device.DeviceName);
                            DeviceInfoTab.Controls.Add(thv);
                            SmartDeviceTabContainer.TabPages.Add(DeviceInfoTab);
                        }
                        else if (device.SupportedFunctions.hasFlag(SmartDeviceFunctionType.Switch))
                        {
                            SocketView sv = new SocketView(this,fritzBox.Uri, fritzBox.SID, device);
                            sv.Dock = DockStyle.Fill;
                            TabPage DeviceInfoTab = new TabPage(device.DeviceName);
                            DeviceInfoTab.Controls.Add(sv);
                            SmartDeviceTabContainer.TabPages.Add(DeviceInfoTab);
                        }
                        else if (device.SupportedFunctions.hasFlag(SmartDeviceFunctionType.Color))
                        {
                            LightView lv = new LightView(this,fritzBox.Uri, fritzBox.SID, device);
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
            changeCulture("de-DE");
        }

        private void englischENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeCulture("en-US");
        }

        private void FritzHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                trayIcon.Visible = true;
                this.Hide();
                e.Cancel = true;
            }
        }

        private void ShowEvent(String Titel, String Message)
        {
            trayIcon.BalloonTipText = Titel;
            trayIcon.BalloonTipTitle = Message;
            trayIcon.ShowBalloonTip(500);
        }

        private void MinimzedTray()
        {
            trayIcon.Visible = true;
        }

        private void MaxmizedFromTray()
        {
            trayIcon.Visible = true;
        }

        private void FritzHome_Resize(object sender, EventArgs e)
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
            fritzBox.info();
            if (fritzBox.connect() == true)
            {
                fritzBox.getDevicelist();
                BatteryWarnings();
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
            catch (Exception ex)
            {

            }
        }

        private void SmartDeviceTab_Click(object sender, EventArgs e)
        {

        }

        private void BatteryWarnings() {
            foreach (SmartDevice d in fritzBox.Devices)
            {
                if (d.Battery <= BatteryWarning)
                {
                    DateTime Now = DateTime.Now;
                    if (Now.Subtract(d.LastWarning).TotalMinutes > 60)
                    {
                        d.LastWarning = DateTime.Now;
                        ShowEvent(d.DeviceName, "Battery: " + d.Battery + "%");
                        Console.WriteLine(d.DeviceName + " Battery: " + d.Battery + "%");
                    }
                }
            }
        }
    }
}