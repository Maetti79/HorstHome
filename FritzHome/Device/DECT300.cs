using System;
using System.Xml.Linq;

namespace FritzHome
{
    public class DECT300 : SmartDevice
    {

        public DECT300(XElement device): base(device)
        {
            iconId = 3;

            XElement batt = device.Element("battery");
            Battery = Int32.Parse(batt.Value);
        }

        ~DECT300()
        {

        }
    }
}
