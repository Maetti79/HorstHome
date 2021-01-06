using System;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace FritzHome
{
    public class SmartDeviceStats : IDisposable
    {

        public List<Int32> Temperature;
        public Int32 TemperatureGrid;
        public List<Int32> Voltage;
        public Int32 VoltageGrid;
        public List<Int32> Power;
        public Int32 PowerGrid;
        public List<Int32> EnergyM;
        public Int32 EnergyMGrid;
        public List<Int32> EnergyY;
        public Int32 EnergyYGrid;

        public SmartDeviceStats()
        {
            Temperature = new List<Int32>();
            Voltage = new List<Int32>();
            Power = new List<Int32>();
            EnergyY = new List<Int32>();
            EnergyM = new List<Int32>();
        }

        public SmartDeviceStats(XElement devicestats)
        {
            try
            {
                setTemperatures(devicestats);
                setVoltages(devicestats);
                setPowers(devicestats);
                setEnergys(devicestats);
            }
            catch (Exception Ex)
            {

            }
        }

        public Boolean setTemperatures(XElement devicestats)
        {
            try
            {
                Temperature = new List<Int32>();
                TemperatureGrid = Int32.Parse(devicestats.Element("temperature").Element("stats").Attribute("grid").Value);
                foreach (XElement e in devicestats.Element("temperature").Elements("stats"))
                {
                    foreach (String value in e.Value.Split(','))
                    {
                        Temperature.Add(Int32.Parse(value));
                    }
                }
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public Boolean setVoltages(XElement devicestats)
        {
            try
            {
                Voltage = new List<Int32>();
                VoltageGrid = Int32.Parse(devicestats.Element("voltage").Element("stats").Attribute("grid").Value);
                foreach (XElement e in devicestats.Element("voltage").Elements("stats"))
                {
                    foreach (String value in e.Value.Split(','))
                    {
                        Voltage.Add(Int32.Parse(value));
                    }
                }
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public Boolean setPowers(XElement devicestats)
        {
            try
            {
                Power = new List<Int32>();
                PowerGrid = Int32.Parse(devicestats.Element("power").Element("stats").Attribute("grid").Value);
                foreach (XElement e in devicestats.Element("power").Elements("stats"))
                {
                    foreach (String value in e.Value.Split(','))
                    {
                        Power.Add(Int32.Parse(value));
                    }
                }
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public Boolean setEnergys(XElement devicestats)
        {
            try
            {
                EnergyY = new List<Int32>();
                EnergyM = new List<Int32>();

                foreach (XElement e in devicestats.Element("energy").Elements("stats"))
                {
                    if (Int32.Parse(e.Attribute("grid").Value) == 86400)
                    {
                        EnergyMGrid = Int32.Parse(e.Attribute("grid").Value);
                        foreach (String value in e.Value.Split(','))
                        {
                            EnergyM.Add(Int32.Parse(value));
                        }
                    }
                    else {
                        EnergyYGrid = Int32.Parse(e.Attribute("grid").Value);
                        foreach (String value in e.Value.Split(','))
                        {
                            EnergyY.Add(Int32.Parse(value));
                        }
                    }
                }
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public void Dispose()
        {

        }

        ~SmartDeviceStats()
        {

        }
    }
}
