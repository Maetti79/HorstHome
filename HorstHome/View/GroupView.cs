using System;
using System.Windows.Forms;
using System.Globalization;

namespace HorstHome
{
    public partial class GroupView : UserControl
    {
        String Uri;
        String SID;
        SmartDeviceGroup group;
        Boolean Initiated;
        private HorstHome parent;

        public GroupView()
        {
            InitializeComponent();
        }

        public GroupView(HorstHome mainfrm, String u, String s, SmartDeviceGroup g)
        {
            InitializeComponent();
            parent = mainfrm;
            changeCulture();
            Uri = u;
            SID = s;
            group = g;

            pictureBox6.Image = Icons.Images[group.Devices[0].iconId];

            Modell.Text = group.GroupName.ToString();

            deviceList.Clear();
            foreach (SmartDevice device in group.Devices)
            {
                ListViewItem gd = new ListViewItem();
                gd.Name = device.DeviceName;
                gd.Text = device.DeviceName;
                gd.ImageIndex = device.iconId;
                deviceList.Items.Add(gd);
            }

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
                }
                else
                {
                    LabelModel.Text = i18n.en.Detail_Model.ToString();
                }
            }
        }

        public void updateDynamics()
        {
        
        }

        private void GroupView_Load(object sender, EventArgs e)
        {

        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            group.tryUpdate(Uri, SID, 30);
            DateTime Now = DateTime.Now;
            if (Now.Subtract(group.lastUpdate).TotalSeconds > 0)
            {
                Initiated = true;
            }
            updateDynamics();
        }
    }
}
