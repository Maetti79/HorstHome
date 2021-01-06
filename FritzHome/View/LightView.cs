using System;
using System.Windows.Forms;
using System.Globalization;

namespace FritzHome
{
    
    public partial class LightView : UserControl
    {
        String Uri;
        String SID;
        SmartDevice device;
        private FritzHome parent;

        public LightView()
        {
            InitializeComponent();
        }

        public LightView(FritzHome mainfrm, String u, String s, SmartDevice d)
        {
            InitializeComponent();
            parent = mainfrm;
            changeCulture();
            Uri = u;
            SID = s;
            device = d;

            if (device.GetType() == typeof(DECT500))
            {
                pictureBox6.Image = DeviceIcons.Images[0];
            }

            Modell.Text = device.GetType().ToString().Replace("FritzHome.", "");
            DeviceName.Text = device.DeviceName;
            Identifier.Text = device.Identifier;
            Manufacturer.Text = device.Manufacturer;
            Firmware.Text = device.FirmwareVersion;

            colorWheel1.Color = ColorRGB.HsBtoRgb((Double)device.ColorHue, (Double)device.ColorSaturation/ 255, (Double)device.Levelpercentage/255);

            updateDynamics();
            refreshTimer.Enabled = true;
        }

        public void changeCulture()
        {
            if (parent != null)
            {
                CultureInfo.DefaultThreadCurrentCulture = parent.culture;
                CultureInfo.DefaultThreadCurrentUICulture = parent.culture;
                if (parent.culture.ToString() == "de-DE")
                {
                    LabelModel.Text = i18n.de.Detail_Model.ToString();
                    LabelName.Text = i18n.de.Detail_Name.ToString();
                    LabelIdentifier.Text = i18n.de.Detail_Indentifier.ToString();
                    LabelManufacturer.Text = i18n.de.Detail_Manufacturer.ToString();
                    LabelFirmware.Text = i18n.de.Detail_Firmware.ToString();
                    OnBtn.Text = i18n.de.Detail_SwitchOn.ToString();
                    OffBtn.Text = i18n.de.Detail_SwitchOff.ToString();
                }
                else
                {
                    LabelModel.Text = i18n.en.Detail_Model.ToString();
                    LabelName.Text = i18n.en.Detail_Name.ToString();
                    LabelIdentifier.Text = i18n.en.Detail_Indentifier.ToString();
                    LabelManufacturer.Text = i18n.en.Detail_Manufacturer.ToString();
                    LabelFirmware.Text = i18n.en.Detail_Firmware.ToString();
                    OnBtn.Text = i18n.en.Detail_SwitchOn.ToString();
                    OffBtn.Text = i18n.en.Detail_SwitchOff.ToString();
                }
            }
        }

        public void updateDynamics()
        {
            if (device.Switch == true)
            {
                OnBtn.Enabled = false;
                OffBtn.Enabled = true;
            }
            else
            {
                OnBtn.Enabled = true;
                OffBtn.Enabled = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LightView_Load(object sender, EventArgs e)
        {

        }

        private void colorWheel1_ColorChanged(object sender, EventArgs e)
        {
            if (device.SupportedColorModes.hasFlag(SmartDeviceColorModeType.HueSaturation))
            {
                SmartDeviceColor[] colorsArr = parent.fritzBox.Colors.ToArray();
                //Color selectedColor = ColorDistance.GetClosestColor(colorsArr, ColorRGB.HSL2RGB(colorWheel1.Color.GetHue() / 360, colorWheel1.Color.GetSaturation() / 255, colorWheel1.Color.GetBrightness() / 100));
                SmartDeviceColor selectedColor = ColorDistance.GetClosestColor(colorsArr, colorWheel1.Color);
                device.ColorHue = Convert.ToInt32(selectedColor.Hue);
                device.ColorSaturation = Convert.ToInt32(selectedColor.Saturation);
                device.Level = Convert.ToInt32(selectedColor.Value);

                device.setColorAsync(Uri, SID, device.ColorHue, device.ColorSaturation);
                device.setLevelAsync(Uri, SID, device.Level);
            }
        }

        private void OnBtn_Click(object sender, EventArgs e)
        {
            OnBtn.Enabled = false;
            OffBtn.Enabled = false;
            if (device.setSwitchOnAsync(Uri, SID).Result)
            {
                device.Switch = true;
                OnBtn.Enabled = false;
                OffBtn.Enabled = true;
            }
        }

        private void OffBtn_Click(object sender, EventArgs e)
        {
            OnBtn.Enabled = false;
            OffBtn.Enabled = false;
            if (device.setSwitchOffAsync(Uri, SID).Result)
            {
                device.Switch = false;
                OnBtn.Enabled = true;
                OffBtn.Enabled = false;
            }
        }
    }
}
