using System;
using System.Windows.Forms;
using System.Globalization;
using SubnetPing;

namespace HorstHome
{
    public partial class NetworkView : UserControl
    {

        String Uri;
        String SID;
        SubnetClientV4 device;
        Boolean Initiated;
        private HorstHome parent;

        public NetworkView()
        {
            InitializeComponent();
        }

        public NetworkView(HorstHome mainfrm, String u, String s, SubnetClientV4 d)
        {
            InitializeComponent();
            parent = mainfrm;
            changeCulture();
            Uri = u;
            SID = s;
            device = d;

            IP.Text = device._ipAddressV4;
            Mac.Text = device._macAddress;
            Hostname.Text = device._hostname;
            Manufacturer.Text = "";

            updateDynamics();
            refreshTimer.Enabled = true;
        }

        private void NetworkView_Load(object sender, EventArgs e)
        {

        }

        public void updateDynamics()
        {
            if (Initiated == true)
            {

            }
            else
            {

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
                    LabelMac.Text = i18n.de.Detail_Mac.ToString();
                    LabelIP.Text = i18n.de.Detail_IP.ToString();
                    LabelHostname.Text = i18n.de.Detail_Hostname.ToString();
                    LabelManufacturer.Text = i18n.de.Detail_Manufacturer.ToString();
                }
                else
                {
                    LabelMac.Text = i18n.en.Detail_Mac.ToString();
                    LabelIP.Text = i18n.en.Detail_IP.ToString();
                    LabelHostname.Text = i18n.en.Detail_Hostname.ToString();
                    LabelManufacturer.Text = i18n.en.Detail_Manufacturer.ToString();
                }
            }
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {

        }
    }
}
