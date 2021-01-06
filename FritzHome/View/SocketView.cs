﻿using System;
using System.Windows.Forms;
using System.Globalization;

namespace FritzHome
{
    public partial class SocketView : UserControl
    {

        String Uri;
        String SID;
        SmartDevice device;
        private FritzHome parent;

        public SocketView()
        {
            InitializeComponent();
        }

        public SocketView(FritzHome mainfrm, String u, String s, SmartDevice d)
        {
            InitializeComponent();
            parent = mainfrm;
            changeCulture();
            Uri = u;
            SID = s;
            device = d;

            if (device.GetType() == typeof(DECT200))
            {
                pictureBox6.Image = DeviceIcons.Images[0];
            }
            if (device.GetType() == typeof(DECT201))
            {
                pictureBox6.Image = DeviceIcons.Images[1];
            }

            Modell.Text = device.GetType().ToString().Replace("FritzHome.", "");
            DeviceName.Text = device.DeviceName;
            Identifier.Text = device.Identifier;
            Manufacturer.Text = device.Manufacturer;
            Firmware.Text = device.FirmwareVersion;

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
                    LabelFirmware.Text = i18n.de.Detail_Battery.ToString();
                    LabelTemperatur.Text = i18n.de.Detail_Battery.ToString();
                    LabelEnergie.Text = i18n.de.Detail_Battery.ToString();
                    OnBtn.Text = i18n.de.Detail_SwitchOn.ToString();
                    OffBtn.Text = i18n.de.Detail_SwitchOff.ToString();
                }
                else
                {
                    LabelModel.Text = i18n.en.Detail_Model.ToString();
                    LabelName.Text = i18n.en.Detail_Name.ToString();
                    LabelIdentifier.Text = i18n.en.Detail_Indentifier.ToString();
                    LabelManufacturer.Text = i18n.en.Detail_Manufacturer.ToString();
                    LabelFirmware.Text = i18n.en.Detail_Battery.ToString();
                    LabelTemperatur.Text = i18n.en.Detail_Battery.ToString();
                    LabelEnergie.Text = i18n.en.Detail_Battery.ToString();
                    OnBtn.Text = i18n.en.Detail_SwitchOn.ToString();
                    OffBtn.Text = i18n.en.Detail_SwitchOff.ToString();
                }
            }
        }

        public void updateDynamics() {
            Tempratur.Text = device.Temperature.ToString() + "°C";
            Energie.Text = Math.Round(device.Energie / 1000m, 2).ToString() + " Wh";
            Power.Text = Math.Round(device.Power / 1000m, 2).ToString() + " Watt";
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 230 * 15;
            progressBar1.Value = Convert.ToInt32(device.Power / 1000);

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

        private void SocketView_Load(object sender, EventArgs e)
        {

        }

        private void OffBtn_Click(object sender, EventArgs e)
        {
            OnBtn.Enabled = false;
            OffBtn.Enabled = false;
            if (device.setSwitchOffAsync(Uri, SID).Result) {
                device.Switch = false;
                OnBtn.Enabled = true;
                OffBtn.Enabled = false;
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

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            device.tryUpdate(Uri, SID, 5);
            updateDynamics();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
