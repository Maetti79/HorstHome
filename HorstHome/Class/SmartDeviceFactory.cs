using System;
using System.Xml.Linq;

namespace HorstHome
{
    public class SmartDeviceFactory
    {

        static public SmartDevice getSmartDevice(XElement device)
        {

            if (device.Attribute("functionbitmask").Value == "1")
            {
                return new Default(device);
            }
            switch (device.Attribute("productname").Value.ToString().Trim())
            {
                case "FRITZ!DECT Repeater 100":
                    // DECT Repeater
                    return new DECT100(device);
                case "FRITZ!DECT 200":
                    // Steckdose
                    return new DECT200(device);
                case "FRITZ!DECT 210":
                    // Außensteckdose
                    return new DECT201(device);
                case "FRITZ!DECT 300":
                    // Thermostat Alt
                    return new DECT300(device);
                case "FRITZ!DECT 301":
                    // Thermostat Neu
                    return new DECT301(device);
                case "FRITZ!DECT 400":
                    // Smart Button
                    return new DECT400(device);
                case "FRITZ!DECT 440":
                    // Smart Thermostat 4 Button
                    return new DECT440(device);
                case "FRITZ!DECT 500":
                    // LED E27 LED Glühbirne
                    return new DECT500(device);
                case "Comet DECT":
                    // Heizungs Thermostat
                    return new CometDECT(device);
                case "HAN-FUN":
                    // Bewegungsmelder, Rauchmelder
                    Int32 HanFunType = 0;
                    if (device.Element("etsiunitinfo") != null)
                    {
                        HanFunType = Int32.Parse(device.Element("etsiunitinfo").Element("unittype").Value);
                    }

                    switch (HanFunType)
                    {
                        case 0:
                            return new Default(device);
                        case 273: // SIMPLE_BUTTON
                        case 256: // SIMPLE_ON_OFF_SWITCHABLE
                        case 257: // SIMPLE_ON_OFF_SWITCH
                        case 262: // AC_OUTLET
                        case 263: // AC_OUTLET_SIMPLE_POWER_METERING
                        case 264: // SIMPLE_LIGHT
                        case 265: // DIMMABLE_LIGHT
                        case 266: // DIMMER_SWITCH
                        case 277: // COLOR_BULB
                        case 278: // DIMMABLE_COLOR_BULB
                        case 281: // BLIND
                        case 282: // LAMELLAR
                        case 512: // SIMPLE_DETECTOR
                        case 513: // DOOR_OPEN_CLOSE_DETECTOR
                        case 514: // WINDOW_OPEN_CLOSE_DETECTOR
                        case 515: // MOTION_DETECTOR
                            return new HanFunMotion(device);
                        case 516: // SMOKE_DETECTOR
                            return new HanFunSmoke(device);
                        case 518: // FLOOD_DETECTOR
                        case 519: // GLAS_BREAK_DETECTOR
                        case 520: // VIBRATION_DETECTOR
                        case 640: // SIREN
                        default:
                            return new HanFun(device);
                    }
                default:
                    return new Default(device);
            }
            //}
            // catch (Exception Ex)
            //{
            //    return new Default(device);
            //}
        }

    }
}
