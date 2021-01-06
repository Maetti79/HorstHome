using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace FritzHome
{
    public partial class VoltageChart : UserControl
    {
        String Uri;
        String SID;
        SmartDevice device;
        private FritzHome parent;

        public VoltageChart()
        {
            InitializeComponent();
        }

        public VoltageChart(FritzHome mainfrm, String u, String s, SmartDevice d)
        {
            InitializeComponent();
            parent = mainfrm;
            changeCulture();
            Uri = u;
            SID = s;
            device = d;

            device.getBasicDeviceStats(Uri, SID);

            chart();
        }

        public void changeCulture()
        {
            if (parent != null)
            {
                CultureInfo.DefaultThreadCurrentCulture = parent.culture;
                CultureInfo.DefaultThreadCurrentUICulture = parent.culture;
                if (parent.culture.ToString() == "de-DE")
                {
                    formsPlot1.plt.YLabel(i18n.de.Chart_V.ToString());
                    formsPlot1.plt.XLabel(i18n.de.Chart_Day.ToString());
                }
                else
                {
                    formsPlot1.plt.YLabel(i18n.en.Chart_V.ToString());
                    formsPlot1.plt.XLabel(i18n.en.Chart_Day.ToString());
                }
            }
        }

        public void chart()
        {
            if ((Int32)device.Stats.VoltageGrid > 0 && (Int32)device.Stats.Voltage.Count() > 0)
            {
                double[] dates = new double[device.Stats.Voltage.Count()];
                DateTime firstDay = DateTime.Now.AddSeconds(device.Stats.Voltage.Count() * (Int32)(device.Stats.VoltageGrid) * -1);
                for (int i = 0; i < device.Stats.Power.Count(); i++)
                {
                    dates[i] = firstDay.AddSeconds(i * (Int32)(device.Stats.VoltageGrid)).ToOADate();
                }
                double[] values = device.Stats.Voltage.Select(Convert.ToDouble).Select(x => x / 1000).Reverse().ToArray();
                if (device.Stats.Voltage.Count() > 0)
                {
                    formsPlot1.plt.PlotScatter(dates, values);
                }
                formsPlot1.plt.Ticks(dateTimeX: true);

                formsPlot1.plt.Grid(xSpacing: 5, xSpacingDateTimeUnit: ScottPlot.Config.DateTimeUnit.Minute);

                formsPlot1.plt.Ticks(dateTimeX: true, xTickRotation: 0, dateTimeFormatStringX: "HH:mm");
                formsPlot1.plt.Layout(xScaleHeight: 60);
                if (parent.culture.ToString() == "de-DE")
                {
                    formsPlot1.plt.YLabel(i18n.de.Chart_V.ToString());
                    formsPlot1.plt.XLabel(i18n.de.Chart_Day.ToString());
                }
                else
                {
                    formsPlot1.plt.YLabel(i18n.en.Chart_V.ToString());
                    formsPlot1.plt.XLabel(i18n.en.Chart_Day.ToString());
                }
                formsPlot1.Render();
            }
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }
    }
}
