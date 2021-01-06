using System;
using System.Xml.Linq;

namespace FritzHome
{
    public class HanFun : SmartDevice
    {

        public HanFun(XElement device): base(device)
        {
            try
            {
                Int32 HanFunType = Int32.Parse(device.Element("etsiunitinfo").Element("unittype").Value);
                switch (HanFunType) {
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
                        iconId = 9;
                        break;
                    case 516: // SMOKE_DETECTOR
                        iconId = 10;
                        break;
                    case 518: // FLOOD_DETECTOR
                    case 519: // GLAS_BREAK_DETECTOR
                    case 520: // VIBRATION_DETECTOR
                    case 640: // SIREN
                    default:
                        iconId = 9;
                        break;
                }

            }
            catch (Exception Ex) {
            }
        }

        ~HanFun()
        {

        }
    }
}
