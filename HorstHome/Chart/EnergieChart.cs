using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace HorstHome
{
    public partial class EnergieChart : UserControl
    {

        String Uri;
        String SID;
        SmartDevice device;
        private HorstHome parent;

        public EnergieChart()
        {
            InitializeComponent();
        }

        public EnergieChart(HorstHome mainfrm, String u, String s, SmartDevice d)
        {
            InitializeComponent();
            parent = mainfrm;
            changeCulture();

            Uri = u;
            SID = s;
            device = d;

            device.getBasicDeviceStats(Uri, SID);

            chartM();
            chartY();
        }

        public void changeCulture()
        {
            if (parent != null)
            {
                CultureInfo.DefaultThreadCurrentCulture = parent.culture;
                CultureInfo.DefaultThreadCurrentUICulture = parent.culture;
                if (parent.culture.ToString() == "de-DE")
                {
                    formsPlot1.plt.YLabel(i18n.de.Chart_Wh.ToString());
                    formsPlot1.plt.XLabel(i18n.de.Chart_Month.ToString());
                    formsPlot2.plt.YLabel(i18n.de.Chart_Wh.ToString());
                    formsPlot2.plt.XLabel(i18n.de.Chart_Month.ToString());
                }
                else
                {
                    formsPlot1.plt.YLabel(i18n.en.Chart_Wh.ToString());
                    formsPlot1.plt.XLabel(i18n.en.Chart_Year.ToString());
                    formsPlot2.plt.YLabel(i18n.en.Chart_Wh.ToString());
                    formsPlot2.plt.XLabel(i18n.en.Chart_Year.ToString());
                }
                formsPlot1.Render();
                formsPlot2.Render();
            }
        }

        public void chartM() {

            if ((Int32)device.Stats.EnergyMGrid > 0 && (Int32)device.Stats.EnergyM.Count() > 0)
            {
                double[] dates = new double[device.Stats.EnergyM.Count()];
                DateTime firstDay = DateTime.Now.AddDays(device.Stats.EnergyM.Count() * -1);
                for (int i = 0; i < device.Stats.EnergyM.Count(); i++)
                {
                    dates[i] = firstDay.AddDays(i).ToOADate();
                }
                double[] values = device.Stats.EnergyM.Select(Convert.ToDouble).Reverse().ToArray();
                if (device.Stats.EnergyM.Count() > 0)
                {
                    formsPlot1.plt.PlotBar(dates, values);
                }
                formsPlot1.plt.Ticks(dateTimeX: true);

                formsPlot1.plt.Grid(xSpacing: 7, xSpacingDateTimeUnit: ScottPlot.Config.DateTimeUnit.Day);

                formsPlot1.plt.Ticks(dateTimeX: true, xTickRotation: 0, dateTimeFormatStringX: "yyyy.MM.dd");
                formsPlot1.plt.Layout(xScaleHeight: 60);
                if (parent.culture.ToString() == "de-DE")
                {
                    formsPlot1.plt.YLabel(i18n.de.Chart_Wh.ToString());
                    formsPlot1.plt.XLabel(i18n.de.Chart_Month.ToString());
                }
                else
                {
                    formsPlot1.plt.YLabel(i18n.en.Chart_Wh.ToString());
                    formsPlot1.plt.XLabel(i18n.en.Chart_Month.ToString());
                }
            }
            formsPlot1.Render();
        }

        public void chartY()
        {
            if ((Int32)device.Stats.EnergyYGrid > 0 && (Int32)device.Stats.EnergyY.Count() > 0)
            {
                double[] dates = new double[device.Stats.EnergyY.Count()];
                DateTime firstDay = DateTime.Now.AddMonths(device.Stats.EnergyY.Count() * -1);
                for (int i = 0; i < device.Stats.EnergyY.Count(); i++)
                {
                    dates[i] = firstDay.AddMonths(i).ToOADate();
                }
                double[] values = device.Stats.EnergyY.Select(Convert.ToDouble).Reverse().ToArray();
                if (device.Stats.EnergyY.Count() > 0)
                {
                    formsPlot2.plt.PlotBar(dates, values);
                }
                formsPlot2.plt.Ticks(dateTimeX: true);

                formsPlot2.plt.Grid(xSpacing: 1, xSpacingDateTimeUnit: ScottPlot.Config.DateTimeUnit.Month);

                formsPlot2.plt.Ticks(dateTimeX: true, xTickRotation: 0, dateTimeFormatStringX: "yyyy.MM");
                formsPlot2.plt.Layout(xScaleHeight: 60);
                if (parent.culture.ToString() == "de-DE")
                {
                    formsPlot2.plt.YLabel(i18n.de.Chart_Wh.ToString());
                    formsPlot2.plt.XLabel(i18n.de.Chart_Year.ToString());
                }
                else
                {
                    formsPlot2.plt.YLabel(i18n.en.Chart_Wh.ToString());
                    formsPlot2.plt.XLabel(i18n.en.Chart_Year.ToString());
                }
            }
            formsPlot2.Render();
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        private void formsPlot2_Load(object sender, EventArgs e)
        {

        }

        private void EnergieChart_Load(object sender, EventArgs e)
        {

        }
    }
}
