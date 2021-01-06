using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;
using System.Web.Script.Serialization;

namespace FritzHome
{
    public partial class LicenseForm : Form
    {

        public PluginCore plugincore = new PluginCore(Environment.CurrentDirectory);
        public String SerialManager = Serial.GetSerialNumber();
        private FritzHome parent;
        private String LicenseInformation = "";

        public LicenseForm()
        {
            InitializeComponent();
        }

        public LicenseForm(FritzHome mainfrm)
        {
            parent = mainfrm;
            InitializeComponent();
            changeCulture();
        }

        public void changeCulture()
        {
            if (parent != null)
            {
                CultureInfo.DefaultThreadCurrentCulture = parent.culture;
                CultureInfo.DefaultThreadCurrentUICulture = parent.culture;

                if (parent.culture.ToString() == "de-DE")
                {
                    this.Text = i18n.de.License_Titel.ToString();
                    LabelKey.Text = i18n.de.License_Key.ToString();
                    LabelType.Text = i18n.de.License_Type.ToString();
                    LabelExpires.Text = i18n.de.License_Expires.ToString();
                    DonateBtn.Text = i18n.de.License_Donate.ToString();
                    ReloadBtn.Text = i18n.de.License_Reload.ToString();
                    CloseBtn.Text = i18n.de.License_Close.ToString();
                    EulaRtf.Clear();
                    EulaRtf.Rtf = Properties.Resources.EULA_DE;
                }
                else
                {
                    this.Text = i18n.en.License_Titel.ToString();
                    LabelKey.Text = i18n.en.License_Key.ToString();
                    LabelType.Text = i18n.en.License_Type.ToString();
                    LabelExpires.Text = i18n.en.License_Expires.ToString();
                    DonateBtn.Text = i18n.en.License_Donate.ToString();
                    ReloadBtn.Text = i18n.en.License_Reload.ToString();
                    CloseBtn.Text = i18n.en.License_Close.ToString();
                    EulaRtf.Clear();
                    EulaRtf.Rtf = Properties.Resources.EULA_EN;
                }
            }
        }

        public void loadPlugins()
        {
            try
            {
                LicenseBox.Clear();
                LicenseBox.Items.Add("AVM", "AVM", 0);
                LicenseBox.Items.Add("HAN-FUN", "HAN-FUN", 0);
                Array pls = plugincore.getPlugins();
                foreach (Object pl in pls)
                {
                    LicenseBox.Items.Add(pl.ToString(), "Plugin: " + plugincore.Hook(pl.ToString()) + ", " + plugincore.Type(pl.ToString()) + ", " + plugincore.Description(pl.ToString()), 0);
                }

                var dict = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(LicenseInformation);

                Microsoft.Win32.RegistryKey key;
                string rootKey = "SOFTWARE\\" + Assembly.GetExecutingAssembly().GetName().Name;
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
                if (key == null)
                {
                    key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
                }
                key.SetValue("LicenseInformation", LicenseInformation);
                key.Close();
                foreach (ListViewItem item in LicenseBox.Items)
                {
                    if (LicenseInformation.Contains(item.Name))
                    {
                        item.ImageIndex = 1;
                    }
                    else
                    {
                        item.ImageIndex = 0;
                    }
                }

                if (dict["serial"] != null)
                {
                    LabelKey.Text = "License Key: " + dict["serial"].ToString();
                }
                if (dict["license"] != null)
                {
                    LabelType.Text = "License Type: " + dict["license"].ToString();
                }
                if (dict["expires"] != null)
                {
                    LabelExpires.Text = "Expires: " + dict["expires"].ToString();
                }
            }
            catch (Exception licenseEx)
            {
                Console.Write(licenseEx.Message);
            }
        }

        private void LicenseForm_Load(object sender, EventArgs e)
        {
            LicenseInformation = parent.licenseInformation;
            LabelKey.Text = SerialManager;
            loadPlugins();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            LicenseInformation = Serial.CallWebservice("https://fritzhome.purepix.net/", Serial.GetSerialNumber());
            Microsoft.Win32.RegistryKey key;
            string rootKey = "SOFTWARE\\" + Assembly.GetExecutingAssembly().GetName().Name;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
            if (key == null)
            {
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(rootKey);
            }
            key.SetValue("LicenseInformation", LicenseInformation);
            key.Close();
            parent.licenseInformation = LicenseInformation;
            loadPlugins();
        }

        private void OkBtn_Click_1(object sender, EventArgs e)
        {
            LicenseInformation = parent.licenseInformation;
            LabelKey.Text = SerialManager;
            loadPlugins();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void donateBtn_Click_1(object sender, EventArgs e)
        {
            string url = "";
            string business = "dennis@beerboys.de";
            string description = "FritzHome%20-%20Donation";
            string country = "DE";
            string currency = "EUR";
            string serial = SerialManager.ToString();
            url += "https://www.paypal.com/cgi-bin/webscr" +
                "?cmd=" + "_donations" +
                "&business=" + business +
                "&lc=" + country +
                "&item_name=" + description +
                "&item_number=" + serial +
                "&custom=" + serial +
                "&currency_code=" + currency +
                "&amount=5.00" +
                "&bn=" + "PP%2dDonationsBF";
            System.Diagnostics.Process.Start(url);
        }
    }
}
