using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using HorstHome;

namespace HorstCMD
{

    class Program
    {

        static void Main(string[] args)
        {

            try
            {
                String Version = typeof(Program).Assembly.GetName().Version.ToString();
                Console.WriteLine("HorstCMD Version: " + Version);

                Parameter parameter = new Parameter(args);

                FritzBox box = new FritzBox(parameter.Arguments["FritzBox"], parameter.Arguments["Username"], parameter.Arguments["Password"]);

                if (box.info() == true)
                {
                    Console.WriteLine("FritzBox".PadLeft(12, ' ') + ":\t" + box.Info["Name"]);
                }
                else
                {
                    Console.WriteLine("FritzBox:\tUri not correct");
                }

                if (box.connect() == true)
                {
                    parameter.Arguments["SID"] = box.SID;
                    switch (parameter.Arguments["Command"].ToLower())
                    {
                        case "devicelist":
                            getDeviceList(box, parameter);
                            break;
                        case "getbattery":   //Steckdose, Heizkörperventil
                            getBattery(box, parameter);
                            break;
                        case "getstats":
                            getDeviceStats(box, parameter);
                            break;
                        case "getswitch":       //Steckdose, Lampe
                            getSwitch(box, parameter);
                            break;
                        case "setswitch":       //Steckdose, Lampe
                            setSwitch(box, parameter);
                            break;
                        case "gettemperatur":   //Steckdose, Heizkörperventil
                            getTemperatur(box, parameter);
                            break;
                        case "settemperatur":   //Heizkörperventil
                            setTemperatur(box, parameter);
                            break;
                        case "getcolor":        //Lampe
                            getColor(box, parameter);
                            break;
                        case "setcolor":        //Lampe
                            getDeviceList(box, parameter);
                            break;
                        default:
                            getHelp(box, parameter);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("FritzBox:\tUsername or Password not correct");
                }

                Console.ReadKey();
            }
            catch (Exception Ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod() + ": " + Ex.Message.ToString());
            }
        }

        public static void getDeviceList(FritzBox box, Parameter parameter)
        {
            try
            {
                box.getDevicelist();
                foreach (SmartDevice device in box.Devices.OrderBy(x => x.DeviceName))
                {
                    Console.WriteLine(device.GetType().ToString().Replace("HorstHome.", "").PadLeft(12, ' ') + ":\t" + device.DeviceName);
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod() + ": " + Ex.Message.ToString());
            }
        }

        public static void getDeviceStats(FritzBox box, Parameter parameter)
        {
            try
            {
                box.getDevicelist();
                using (SmartDevice device = box.Devices.Find(x => x.DeviceName.Equals(parameter.Arguments["Device"])))
                {
                    device.getBasicDeviceStats(box.Uri, box.SID);
                    Console.WriteLine(device.GetType().ToString().Replace("HorstHome.", "").PadLeft(12, ' ') + ":\t" + device.DeviceName + "\t");

                    if ((Int32)device.Stats.TemperatureGrid > 0 && (Int32)device.Stats.Temperature.Count() > 0)
                    {
                        String dates;
                        double[] values = device.Stats.Temperature.Select(Convert.ToDouble).Select(x => x / 10).Reverse().ToArray();
                        DateTime firstDay = DateTime.Now.AddMinutes(device.Stats.Temperature.Count() * (Int32)(device.Stats.TemperatureGrid / 60) * -1);
                        for (int i = 0; i < device.Stats.Temperature.Count(); i++)
                        {
                            dates = firstDay.AddMinutes(i * (Int32)(device.Stats.TemperatureGrid / 60)).ToString("yyyy-MM-dd HH:mm:ss");
                            Console.WriteLine(dates + "\t" + values[i] + "°C");
                        }  
                    }

                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod() + ": " + Ex.Message.ToString());


            }
        }

        public static void getSwitch(FritzBox box, Parameter parameter)
        {
            try
            {
                box.getDevicelist();
                using (SmartDevice device = box.Devices.Find(x => x.DeviceName.Equals(parameter.Arguments["Device"])))
                {
                    device.getSwitchStateAsync(box.Uri, box.SID);
                    if (device.Switch == true)
                    {
                        Console.WriteLine(device.GetType().ToString().Replace("HorstHome.", "").PadLeft(12, ' ') + ":\t" + device.DeviceName + "\t" + "On");
                    }
                    else
                    {
                        Console.WriteLine(device.GetType().ToString().Replace("HorstHome.", "").PadLeft(12, ' ') + ":\t" + device.DeviceName + "\t" + "Off");
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod() + ": " + Ex.Message.ToString());
            }
        }

        public static void setSwitch(FritzBox box, Parameter parameter)
        {
            try
            {
                box.getDevicelist();
                using (SmartDevice device = box.Devices.Find(x => x.DeviceName.Equals(parameter.Arguments["Device"])))
                {
                    if (Int32.Parse(parameter.Arguments["Value"]) == 1)
                    {
                        device.setSwitchOnAsync(box.Uri, box.SID);
                        Console.WriteLine(device.GetType().ToString().Replace("HorstHome.", "").PadLeft(12, ' ') + ":\t" + device.DeviceName + "\t" + "On");
                    }
                    else if (Int32.Parse(parameter.Arguments["Value"]) == 0)
                    {
                        device.setSwitchOffAsync(box.Uri, box.SID);
                        Console.WriteLine(device.GetType().ToString().Replace("HorstHome.", "").PadLeft(12, ' ') + ":\t" + device.DeviceName + "\t" + "Off");
                    }
                    else
                    {
                        Console.WriteLine(device.GetType().ToString().Replace("HorstHome.", "").PadLeft(12, ' ') + ":\t" + device.DeviceName + "\t" + "Unknowen");
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod() + ": " + Ex.Message.ToString());
            }
        }

        public static void getTemperatur(FritzBox box, Parameter parameter)
        {
            try
            {
                box.getDevicelist();
                using (SmartDevice device = box.Devices.Find(x => x.DeviceName.Equals(parameter.Arguments["Device"])))
                {
                    device.getTemperatureAsync(box.Uri, box.SID);
                    Console.WriteLine(device.GetType().ToString().Replace("HorstHome.", "").PadLeft(12, ' ') + ":\t" + device.DeviceName + "\t" + device.Temperature.ToString() + "°C");
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod() + ": " + Ex.Message.ToString());
            }
        }

        public static void setTemperatur(FritzBox box, Parameter parameter)
        {
            try
            {
                box.getDevicelist();
                using (SmartDevice device = box.Devices.Find(x => x.DeviceName.Equals(parameter.Arguments["Device"])))
                {
                    device.setTemperatureAsync(box.Uri, box.SID, Double.Parse(parameter.Arguments["Value"], CultureInfo.InvariantCulture));
                    Console.WriteLine(device.GetType().ToString().Replace("HorstHome.", "").PadLeft(12, ' ') + ":\t" + device.DeviceName + "\t" + device.Temperature.ToString() + "°C");
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod() + ": " + Ex.Message.ToString());
            }
        }

        public static void getBattery(FritzBox box, Parameter parameter)
        {
            try
            {
                box.getDevicelist();
                using (SmartDevice device = box.Devices.Find(x => x.DeviceName.Equals(parameter.Arguments["Device"])))
                {
                    //device.getTemperatureAsync(box.Uri, box.SID);
                    Console.WriteLine(device.GetType().ToString().Replace("HorstHome.", "").PadLeft(12, ' ') + ":\t" + device.DeviceName + "\t" + device.Battery.ToString() + "%");
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod() + ": " + Ex.Message.ToString());
            }
        }

        public static void getColor(FritzBox box, Parameter parameter)
        {
            try
            {
                box.getDevicelist();
                box.getColordefaults();
                using (SmartDevice device = box.Devices.Find(x => x.DeviceName.Equals(parameter.Arguments["Device"])))
                {
                    device.getBasicDeviceStats(box.Uri, box.SID);
                    Console.WriteLine(device.GetType().ToString().Replace("HorstHome.", "").PadLeft(12, ' ') + ":\t" + device.DeviceName + "\t" + device.Temperature.ToString() + "°C");
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod() + ": " + Ex.Message.ToString());


            }
        }

        public static void getHelp(FritzBox box, Parameter parameter)
        {
            try { 

                Console.WriteLine("");
                Console.WriteLine("Usage:");
                Console.WriteLine("HorstCMD /FritzBox:[Uri] /Username:[Username] /Password:[Password] [/Device:[Device]] [/Command:[Cmd]] [args]");
                Console.WriteLine("");
                Console.WriteLine("\t/FritzBox:\t[FritzBox]\tFritzBox Uri default='http://fritz.box'");
                Console.WriteLine("\t/Password:\t[Password]\tFritzBox Username"); 
                Console.WriteLine("\t/Username:\t[Username]\tFritzBox Password");
                Console.WriteLine("\t/Device:  \t[Device Name]\tget available devices using /Command='devicelist'");
                Console.WriteLine("\t/Command: \t[Command]\tAvailable Commands:");                
                Console.WriteLine("\t                    \t\t'devicelist'");
                Console.WriteLine("\t                    \t\t'getstats'");
                Console.WriteLine("\t                    \t\t'getswitch'");
                Console.WriteLine("\t                    \t\t'setswitch'");
                Console.WriteLine("\t                    \t\t'gettemperatur'");
                Console.WriteLine("\t                    \t\t'settemperatur'");
                Console.WriteLine("\t                    \t\t'getcolor'");
                Console.WriteLine("\t                    \t\t'setcolor'");

            }
            catch (Exception Ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod() + ": " + Ex.Message.ToString());
            }
        }

    }
}
