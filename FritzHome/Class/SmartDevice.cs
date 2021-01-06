using System;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace FritzHome
{
    public class SmartDevice : IDisposable
    {

        public Int32 iconId;

        public Int32 Id;
        public String Identifier;
        public String DeviceName;

        public String Manufacturer;
        public String FirmwareVersion;

        //Thermostst, Steckdose
        public Double Temperature;
        public Double TemperatureTarget;
        public Double TemperatureHigh;
        public Double TemperatureLow;
        public Int32 Battery;
        public DateTime LastWarning;

        //Steckdose
        public Boolean Switch;
        public Int32 Power;
        public Int32 Energie;

        //Lampe 
        public List<SmartDeviceColor> Colors;
        public Int32 ColorMode;
        public SmartDeviceColorMode SupportedColorModes;
        public Int32 ColorTemperature;
        public Int32 ColorHue;
        public Int32 ColorSaturation;
        public Int32 Level;
        public Int32 Levelpercentage;

        public Boolean isConnected;
        public Boolean isGrouped;

        public SmartDeviceGroup Group;
        public SmartDeviceFunction SupportedFunctions;
        public SmartDeviceStats Stats;

        public const Int32 Temperature_min = 8;
        public const Int32 Temperature_max = 28;

        public Int32[] Interfaces;

        public DateTime lastUpdate;
        public DateTime lastBasicUpdate;

        public SmartDevice(XElement device)
        {
            Id = Int32.Parse(device.Attribute("id").Value);
            Identifier = device.Attribute("identifier").Value;
            Manufacturer = device.Attribute("manufacturer").Value;
            FirmwareVersion = device.Attribute("fwversion").Value;
            XElement name = device.Element("name");

            DeviceName = name.Value;
            isGrouped = false;
            SupportedFunctions = new SmartDeviceFunction(device.Attribute("functionbitmask").Value);
            if (device.Attribute("productname").Value.ToString().Trim() == "HAN-FUN")
            {
                if (device.Element("etsiunitinfo") != null)
                {
                    foreach (String ihanfun in device.Element("etsiunitinfo").Element("interfaces").Value.Split(','))
                    {
                        SupportedFunctions.addHanFunInterface(ihanfun);
                    }
                }
            }
            Stats = new SmartDeviceStats();

            if (device.Element("present").Value == "1")
            {
                isConnected = true;
            }
            else
            {
                isConnected = false;
            }

            if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Thermometer))
            {
                XElement temp = device.Element("temperature");                
                Temperature = (getDoubleValue(temp, "celsius") - getDoubleValue(temp, "offset")) / 10;
            }
            else
            {
                Temperature = 0;
            }

            if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Level))
            {
                XElement temp = device.Element("levelcontrol");
                Level = getInt32Value(temp, "level");
                Levelpercentage = getInt32Value(temp, "levelpercentage");
            }
            else
            {
                Level = 0;
                Levelpercentage = 0;
            }

            if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Color))
            {
                XElement temp = device.Element("colorcontrol");
                ColorMode = getInt32Attribute(temp, "current_mode");
                SupportedColorModes = new SmartDeviceColorMode(getStringAttribute(temp, "supported_modes"));
                ColorTemperature = getInt32Value(temp, "temperature");
                ColorSaturation = getInt32Value(temp, "saturation"); 
                ColorHue = getInt32Value(temp,"hue"); 
            }
            else
            {
                ColorMode = 0;
                ColorTemperature = 0;
                ColorSaturation = 0;
                ColorHue = 0;
            }
        }

        public Int32 getInt32Value(XElement temp, String n)
        {
            try
            {
                if (temp.Element(n).Value != "")
                {
                    return Int32.Parse(temp.Element(n).Value);
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Double getDoubleValue(XElement temp, String n)
        {
            try
            {
                if (temp.Element(n).Value != "")
                {
                    return Double.Parse(temp.Element(n).Value);
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public String getStringValue(XElement temp, String n)
        {
            try
            {
                if (temp.Element(n).Value != "")
                {
                    return temp.Element(n).Value;
                }
                return "";
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public Int32 getInt32Attribute(XElement temp, String n)
        {
            try
            {
                if (temp.Attribute(n).Value != "")
                {
                    return Int32.Parse(temp.Attribute(n).Value);
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Double getDoubleAttribute(XElement temp, String n)
        {
            try
            {
                if (temp.Attribute(n).Value != "")
                {
                    return Double.Parse(temp.Attribute(n).Value);
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public String getStringAttribute(XElement temp, String n)
        {
            try
            {
                if (temp.Attribute(n).Value != "")
                {
                    return temp.Attribute(n).Value;
                }
                return "";
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public void tryUpdate(String Uri, String SID, Int32 cooldown = 10)
        {
            DateTime Now = DateTime.Now;
            if (Now.Subtract(lastUpdate).TotalSeconds > cooldown)
            {
                if (SupportedFunctions.MethodBit.HasFlag(SmartDeviceFunctionType.Thermostat))
                {
                    getTemperatureHighAsync(Uri, SID);
                    getTemperatureLowAsync(Uri, SID);
                    getTemperatureTargetAsync(Uri, SID);
                }
                if (SupportedFunctions.MethodBit.HasFlag(SmartDeviceFunctionType.Energie))
                {
                    getSwitchPowerAsync(Uri, SID);
                    getSwitchEnergyAsync(Uri, SID);
                    getSwitchStateAsync(Uri, SID);
                }
                if (SupportedFunctions.MethodBit.HasFlag(SmartDeviceFunctionType.Thermometer))
                {
                    getTemperatureAsync(Uri, SID);
                }
                lastUpdate = DateTime.Now;
            }
        }

        // DECT 200, DECT 210
        public Boolean getBasicDeviceStats(String Uri, String SID, Int32 cooldown = 10)
        {
            try
            {
                DateTime Now = DateTime.Now;
                if (Now.Subtract(lastBasicUpdate).TotalSeconds > cooldown)
                {
                    XDocument doc;
                    doc = XDocument.Load(Uri + @"webservices/homeautoswitch.lua?sid=" + SID + "&ain=" + Identifier + "&switchcmd=getbasicdevicestats");
                    Stats = new SmartDeviceStats(doc.Element("devicestats"));
                    lastBasicUpdate = DateTime.Now;
                }
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        // ALL
        public async Task<bool> setSimpleOnOffAsync(String Uri, String SID, Int32 onoff)
        {
            if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Color))
            {
                String Result = await CallWebserviceAsync(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier
                    + "&onoff=" + onoff
                    + "&sid=" + SID
                    + "&switchcmd=setsimpleonoff");
                return true;
            }
            else
            {
                return false;
            }
        }

        // DECT 200, DECT 210
        public async Task<bool> getSwitchStateAsync(String Uri, String SID)
        {
            try
            {
                if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Thermometer))
                {
                    /*String Result = CallWebservice(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier
                            + "&sid=" + SID
                            + "&switchcmd=getswitchstate");
                    Switch = Boolean.Parse(Result);
                    */
                    String Result = await CallWebserviceAsync(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier
                            + "&sid=" + SID
                            + "&switchcmd=getswitchstate");

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        // DECT 200, DECT 210
        public async Task<bool> getSwitchPowerAsync(String Uri, String SID)
        {
            try
            {
                if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Thermometer))
                {
                    String Result = await CallWebserviceAsync(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier
                            + "&sid=" + SID
                            + "&switchcmd=getswitchpower");
                    Power = Int32.Parse(Result);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        // DECT 200, DECT 210
        public async Task<bool> getSwitchEnergyAsync(String Uri, String SID)
        {
            try
            {
                if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Thermometer))
                {
                    String Result = await CallWebserviceAsync(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier
                            + "&sid=" + SID
                            + "&switchcmd=getswitchenergy");
                    Energie = Int32.Parse(Result);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        // DECT 200, DECT 210, DECT 500
        public async Task<bool> setSwitchOnAsync(String Uri, String SID)
        {
            if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Switch))
            {
                String Result = await CallWebserviceAsync(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier
                       + "&sid=" + SID
                       + "&switchcmd=setswitchon");
                if (Int32.Parse(Result) == 1)
                {
                    return true;
                }
            }
            else if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Thermostat))
            {
                String Result = await CallWebserviceAsync(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier
                    + "&sid=" + SID
                    + "&param=254"
                    + "&switchcmd=sethkrtsoll");
                if (Int32.Parse(Result) == 254)
                {
                    return true;
                }
            }
            return false;
        }

        // DECT 200, DECT 210, DECT 500
        public async Task<bool> setSwitchOffAsync(String Uri, String SID)
        {
            try
            {
                if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Switch))
                {
                    String Result = await CallWebserviceAsync(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier
                         + "&sid=" + SID
                         + "&switchcmd=setswitchoff");
                    if (Int32.Parse(Result) == 0)
                    {
                        return true;
                    }
                }
                else if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Thermostat))
                {
                    String Result = await CallWebserviceAsync(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier
                        + "&sid=" + SID
                        + "&param=253"
                        + "&switchcmd=sethkrtsoll");
                    if (Int32.Parse(Result) == 253)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        // DECT 300, DECT 301, Comet DECT
        public async Task<bool> setTemperatureAsync(String Uri, String SID, Double celsius)
        {
            try
            {
                if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Thermostat))
                {
                    String Result = await CallWebserviceAsync(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier
                            + "&sid=" + SID
                            + "&param=" + TemperatureCensiusToHKR(celsius)
                            + "&switchcmd=sethkrtsoll");
                    if (Int32.Parse(Result) == TemperatureCensiusToHKR(celsius))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        // DECT 300, DECT 301, Comet DECT
        public async Task<bool> setBoostAsync(String Uri, String SID, DateTime endTime)
        {
            try
            {
                if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Thermostat))
                {
                    String Result = await CallWebserviceAsync(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier
                            + "&sid=" + SID
                            + "&endtimestamp=" + ConvertToUnixTimestamp(endTime).ToString()
                            + "&switchcmd=sethkrtsoll");
                    if (Double.Parse(Result) == ConvertToUnixTimestamp(endTime))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        // DECT 200, DECT 210, DECT 300, DECT 301, Comet DECT
        public async Task<bool> getTemperatureAsync(String Uri, String SID)
        {
            try
            {
                if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Thermometer))
                {
                    String Result = await CallWebserviceAsync(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier
                            + "&sid=" + SID
                            + "&switchcmd=gettemperature");
                    Temperature = Double.Parse(Result) / 10;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        // DECT 200, DECT 210, DECT 300, DECT 301, Comet DECT
        public async Task<bool> getTemperatureTargetAsync(String Uri, String SID)
        {
            try
            {
                if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Thermostat))
                {
                    String Result = await CallWebserviceAsync(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier
                            + "&sid=" + SID
                            + "&switchcmd=gethkrtsoll");
                    TemperatureTarget = TemperatureHKRToCelsius(Double.Parse(Result));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        // DECT 200, DECT 210, DECT 300, DECT 301, Comet DECT
        public async Task<bool> getTemperatureHighAsync(String Uri, String SID)
        {
            try
            {
                if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Thermostat))
                {
                    String Result = await CallWebserviceAsync(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier
                            + "&sid=" + SID
                            + "&switchcmd=gethkrkomfort");
                    TemperatureHigh = TemperatureHKRToCelsius(Double.Parse(Result));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        // DECT 200, DECT 210, DECT 300, DECT 301, Comet DECT
        public async Task<bool> getTemperatureLowAsync(String Uri, String SID)
        {
            try
            {
                if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Thermostat))
                {
                    String Result = await CallWebserviceAsync(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier
                            + "&sid=" + SID
                            + "&switchcmd=gethkrabsenk");
                    TemperatureLow = TemperatureHKRToCelsius(Double.Parse(Result));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        // DECT 500, DECT 200, DECT 210,
        public async Task<bool> setLevelAsync(String Uri, String SID, Int32 level)
        {
            if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Level))
            {
                String Result = await CallWebserviceAsync(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier + "&level=" + level + "&sid=" + SID + "&switchcmd=setlevel");
                if (Result == level.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        // DECT 500
        public async Task<bool> setLevelPercentageAsync(String Uri, String SID, Int32 percentage)
        {
            if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Level))
            {
                String Result = await CallWebserviceAsync(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier + "&level=" + percentage + "&sid=" + SID + "&switchcmd=setlevelpercentage");
                return true;
            }
            else
            {
                return false;
            }
        }

        // DECT 500
        public async Task<bool> setColorAsync(String Uri, String SID, Int32 hue, Int32 saturation, Int32 duration = 100)
        {
            if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Color))
            {
                String Result = await CallWebserviceAsync(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier
                    + "&hue=" + hue
                    + "&saturation=" + saturation
                    + "&duration=" + duration
                    + "&sid=" + SID
                    + "&switchcmd=setcolor");
                Console.WriteLine(Result);
                return true;
            }
            else
            {
                return false;
            }
        }

        // DECT 500
        public async Task<bool> setColorTemperatureAsync(String Uri, String SID, Int32 colortemperature, Int32 duration = 100)
        {
            if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Color))
            {
                String Result = await CallWebserviceAsync(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier
                    + "&temperature=" + colortemperature
                    + "&duration=" + duration
                    + "&sid=" + SID
                    + "&switchcmd=setcolortemperature");
                return true;
            }
            else
            {
                return false;
            }
        }

        //HAN-FUN Rollo
        public async Task<bool> setBlindAsync(String Uri, String SID, String target)
        {
            if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Blind))
            {
                String Result = await CallWebserviceAsync(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier
                    + "&target=" + target
                    + "&sid=" + SID
                    + "&switchcmd=setblind");
                return true;
            }
            else
            {
                return false;
            }
        }

        //HAN-FUN Rollo
        public async Task<bool> setBlindOpenAsync(String Uri, String SID)
        {
            if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Blind))
            {
                String Result = await CallWebserviceAsync(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier
                    + "&target=open"
                    + "&sid=" + SID
                    + "&switchcmd=setblind");
                return true;
            }
            else
            {
                return false;
            }
        }

        //HAN-FUN Rollo
        public async Task<bool> setBlindCloseAsync(String Uri, String SID)
        {
            if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Blind))
            {
                String Result = await CallWebserviceAsync(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier
                    + "&target=close"
                    + "&sid=" + SID
                    + "&switchcmd=setblind");
                return true;
            }
            else
            {
                return false;
            }
        }

        //HAN-FUN Rollo
        public async Task<bool> setBlindStopAsync(String Uri, String SID)
        {
            if (SupportedFunctions.hasFlag(SmartDeviceFunctionType.Color))
            {
                String Result = await CallWebserviceAsync(Uri + @"webservices/homeautoswitch.lua?ain=" + Identifier
                    + "&target=stop"
                    + "&sid=" + SID
                    + "&switchcmd=setblind");
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<String> CallWebserviceAsync(String url, String data = "")
        {
            String responseText = await Task.Run(() =>
            {
                try
                {
                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                    WebResponse response = request.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    return new StreamReader(responseStream).ReadToEnd();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                return null;
            });

            return responseText;
        }

        public static string CallWebservice(String URL, String data = "")
        {
            String response = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "GET";
            request.ContentType = "application/text";

            //request.ContentLength = data.Length;
            //using (Stream webStream = request.GetRequestStream())
            //using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            //{
            //    requestWriter.Write(data);
            //}

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            response = responseReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                response = e.Message;
            }
            return response;
        }

        public Int32 TemperatureCensiusToHKR(Double celsius)
        {
            try
            {
                if (celsius < Temperature_min) { celsius = Temperature_min; }
                if (celsius > Temperature_max) { celsius = Temperature_max; }
                celsius = Math.Round(celsius * 2, MidpointRounding.AwayFromZero) / 2;
                return Convert.ToInt32(celsius * 2);
            }
            catch (Exception Ex)
            {
                return 16;
            }
        }

        public Double TemperatureHKRToCelsius(Double hkr)
        {
            try
            {
                Double celsius = hkr / 2;
                if (celsius < Temperature_min) { celsius = Temperature_min; }
                if (celsius > Temperature_max) { celsius = Temperature_max; }
                return celsius;
            }
            catch (Exception Ex)
            {
                return 16;
            }
        }

        public static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return origin.AddSeconds(timestamp);
        }

        public static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        public Int32 BatteryIconIndex()
        {
            return Battery / 10;
        }

        public void Dispose()
        {

        }

        ~SmartDevice()
        {

        }
    }
}
