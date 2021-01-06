using System;
using System.Xml.Linq;

namespace FritzHome
{
    public class DECT440 : SmartDevice
    {

        public DECT440(XElement device) : base(device)
        {
            iconId = 6;
            XElement batt = device.Element("battery");
            Battery = Int32.Parse(batt.Value);
        }

        ~DECT440()
        {

        }
    }
}
