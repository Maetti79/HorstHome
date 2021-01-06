using System;
using System.Xml.Linq;

namespace FritzHome
{
    public class DECT400 : SmartDevice
    {

        public DECT400(XElement device) : base(device)
        {
            iconId = 5;
            XElement batt = device.Element("battery");
            Battery = Int32.Parse(batt.Value);
        }

        ~DECT400()
        {

        }
    }
}
