using System;
using System.Windows.Forms;
using System.Globalization;

namespace HorstHome
{
    public partial class FritzboxView : UserControl
    {

        private HorstHome parent;

        public FritzboxView()
        {
            InitializeComponent();
        }

        public FritzboxView(HorstHome mainfrm, FritzBox box)
        {
            InitializeComponent();
            parent = mainfrm;
            changeCulture();
            DeviceName.Text = box.Info["Name"].ToString();
            Serial.Text = box.Info["Serial"].ToString();
            Manufacturer.Text = box.Info["OEM"].ToString();
            Firmware.Text = box.Info["Version"].ToString();
            Annex.Text = box.Info["Annex"].ToString();
            Revision.Text = box.Info["HW"].ToString();

            if (box.Info["Name"].ToString() == "FRITZ!Box 7490")
            {
                pictureBox1.Image = DeviceIcons.Images[0];
            }
            if (box.Info["Name"].ToString() == "FRITZ!Box 7590")
            {
                pictureBox1.Image = DeviceIcons.Images[1];
            }

        }

        public void changeCulture()
        {
            if (parent != null)
            {
                CultureInfo.DefaultThreadCurrentCulture = parent.culture;
                CultureInfo.DefaultThreadCurrentUICulture = parent.culture;
                if (parent.culture.ToString() == "de-DE")
                {
                    LabelModel.Text = i18n.de.Detail_Fritzbox.ToString();
                    LabelManufacturer.Text = i18n.de.Detail_Manufacturer.ToString();
                    LabelRevision.Text = i18n.de.Detail_Revision.ToString();
                    LabelFirmware.Text = i18n.de.Detail_Firmware.ToString();
                    LabelSerial.Text = i18n.de.Detail_Serial.ToString();
                    LabelAnnex.Text = i18n.de.Detail_Annex.ToString();
                }
                else
                {
                    LabelModel.Text = i18n.en.Detail_Fritzbox.ToString();
                    LabelManufacturer.Text = i18n.en.Detail_Manufacturer.ToString();
                    LabelRevision.Text = i18n.en.Detail_Revision.ToString();
                    LabelFirmware.Text = i18n.en.Detail_Firmware.ToString();
                    LabelSerial.Text = i18n.en.Detail_Serial.ToString();
                    LabelAnnex.Text = i18n.en.Detail_Annex.ToString();
                }
            }
        }

        private void FritzboxView_Load(object sender, EventArgs e)
        {

        }

        private void Revision_TextChanged(object sender, EventArgs e)
        {

        }

        private void Serial_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
