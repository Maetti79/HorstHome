using System;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;
using System.Collections.Generic;

namespace HorstHome
{
    public partial class Settings : Form
    {

        private FritzBox TestBox;
        private Boolean connectionOk;
        private HorstHome parent;

        public Settings()
        {
            InitializeComponent();
            changeCulture();
            loadConnection();
            pictureBox1.Image = ConnectIcons.Images[2];
            connectionOk = false;
            validateConnection();
        }

        public Settings(HorstHome mainfrm)
        {
            InitializeComponent();
            parent = mainfrm;
            changeCulture();
            loadConnection();
            pictureBox1.Image = ConnectIcons.Images[2];
            connectionOk = false;
            validateConnection();
        }

        public void changeCulture()
        {
            if (parent != null)
            {
                CultureInfo.DefaultThreadCurrentCulture = parent.culture;
                CultureInfo.DefaultThreadCurrentUICulture = parent.culture;

                if (parent.culture.ToString() == "de-DE")
                {
                    this.Text = i18n.de.Settings_Titel.ToString();
                    FritzBoxGroup.Text = i18n.de.Settings_Group.ToString();
                    LabelUri.Text = i18n.de.Settings_Uri.ToString();
                    LabelUsername.Text = i18n.de.Settings_Username.ToString();
                    LabelPassword.Text = i18n.de.Settings_Password.ToString();
                    LabelConnection.Text = i18n.de.Settings_Conenction.ToString();
                    ValidateBtn.Text = i18n.de.Settings_Validate.ToString();
                    OkBtn.Text = i18n.de.Settings_Ok.ToString();
                    CancelBtn.Text = i18n.de.Settings_Cancel.ToString();
                }
                else
                {
                    this.Text = i18n.en.Settings_Titel.ToString();
                    FritzBoxGroup.Text = i18n.en.Settings_Group.ToString();
                    LabelUri.Text = i18n.en.Settings_Uri.ToString();
                    LabelUsername.Text = i18n.en.Settings_Username.ToString();
                    LabelPassword.Text = i18n.en.Settings_Password.ToString();
                    LabelConnection.Text = i18n.en.Settings_Conenction.ToString();
                    ValidateBtn.Text = i18n.en.Settings_Validate.ToString();
                    OkBtn.Text = i18n.en.Settings_Ok.ToString();
                    CancelBtn.Text = i18n.en.Settings_Cancel.ToString();
                }
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (connectionOk == true)
            {
                saveConnection();
                this.Close();
            }
            else
            {
                if (TestBox.connect())
                {
                    saveConnection();
                    this.Close();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void validateBtn_Click(object sender, EventArgs e)
        {
            validateConnection();
        }

        public Boolean validateConnection() {
            pictureBox1.Image = ConnectIcons.Images[0];
            errorTxt.Text = "";
            TestBox = new FritzBox(UriTxt.Text.ToString(), UsernameTxt.Text.ToString(), PasswordTxt.Text.ToString());
            TestBox.info();
            if (TestBox.connect())
            {
                connectionOk = true;
                pictureBox1.Image = ConnectIcons.Images[1];
                foreach (KeyValuePair<string, string> info in TestBox.Info)
                {
                    errorTxt.Text += info.Key + ":\t" + info.Value + "\r\n";
                }
                return true;
            }
            else
            {
                connectionOk = false;
                pictureBox1.Image = ConnectIcons.Images[2];
                return false;
            }
        }

        public void saveConnection()
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
                    subkey.SetValue("FritzBoxUri", UriTxt.Text.ToString());
                    subkey.SetValue("Username", UsernameTxt.Text.ToString());
                    if (PasswordTxt.Text.ToString() != "")
                    {
                        String Salt = StringEncryptor.GenerateAPassKey(Serial.cpuSerial());
                        subkey.SetValue("Password", StringEncryptor.Encrypt(PasswordTxt.Text.ToString(), Salt));
                    }
                }
                key.Close();
            }
        }

        public void loadConnection()
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
                UriTxt.Text = subkey.GetValue("FritzBoxUri", "http://fritz.box/").ToString();
                UsernameTxt.Text = subkey.GetValue("Username", "").ToString();
                String Salt = StringEncryptor.GenerateAPassKey(Serial.cpuSerial());
                PasswordTxt.Text = "";
                if (subkey.GetValue("Password", "").ToString() != "")
                {
                    PasswordTxt.Text = StringEncryptor.Decrypt(subkey.GetValue("Password", "").ToString(), Salt);
                } 
            }
            if (key != null)
            {
                key.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }
    }
}
