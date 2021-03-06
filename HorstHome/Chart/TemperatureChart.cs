﻿using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace HorstHome
{
    public partial class TemperatureChart : UserControl
    {

        String Uri;
        String SID;
        SmartDevice device;
        private HorstHome parent;

        public TemperatureChart()
        {
            InitializeComponent();
        }

        public TemperatureChart(HorstHome mainfrm, String u, String s, SmartDevice d)
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
                    formsPlot1.plt.YLabel(i18n.de.Chart_Temperature.ToString());
                    formsPlot1.plt.XLabel(i18n.de.Chart_Day.ToString());
                }
                else
                {
                    formsPlot1.plt.YLabel(i18n.en.Chart_Temperature.ToString());
                    formsPlot1.plt.XLabel(i18n.en.Chart_Day.ToString());
                }
            }
        }

        public void chart()
        {
            if ((Int32)device.Stats.TemperatureGrid > 0 && (Int32)device.Stats.Temperature.Count() > 0)
            {
                double[] dates = new double[device.Stats.Temperature.Count()];
                DateTime firstDay = DateTime.Now.AddMinutes(device.Stats.Temperature.Count() * (Int32)(device.Stats.TemperatureGrid / 60) * -1);
                for (int i = 0; i < device.Stats.Temperature.Count(); i++)
                {
                    dates[i] = firstDay.AddMinutes(i * (Int32)(device.Stats.TemperatureGrid / 60)).ToOADate();
                }
                double[] values = device.Stats.Temperature.Select(Convert.ToDouble).Select(x => x / 10).Reverse().ToArray();

                //formsPlot1.plt.PlotScatter(dates, values);
                formsPlot1.plt.PlotFillAboveBelow(dates, values, fillAlpha: .5, labelAbove: "above", labelBelow: "below");
                formsPlot1.plt.Ticks(dateTimeX: true);
                formsPlot1.plt.Grid(xSpacing: 2, xSpacingDateTimeUnit: ScottPlot.Config.DateTimeUnit.Hour);
                formsPlot1.plt.Ticks(dateTimeX: true, xTickRotation: 0, dateTimeFormatStringX: "HH");
                formsPlot1.plt.Layout(xScaleHeight: 60);
                if (parent.culture.ToString() == "de-DE")
                {
                    formsPlot1.plt.YLabel(i18n.de.Chart_Temperature.ToString());
                    formsPlot1.plt.XLabel(i18n.de.Chart_Day.ToString());
                }
                else
                {
                    formsPlot1.plt.YLabel(i18n.en.Chart_Temperature.ToString());
                    formsPlot1.plt.XLabel(i18n.en.Chart_Day.ToString());
                }
            }
            formsPlot1.Render();
        }

        private void TemperatureChart_Load(object sender, EventArgs e)
        {

        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }
    }
}
