using System;
using System.Xml.Linq;

namespace HorstHome
{
    public class DECT301 : SmartDevice
    {

        public DECT301(XElement device): base(device)
        {
            iconId = 4;
            XElement batt = device.Element("battery");
            Battery = Int32.Parse(batt.Value);
        }

        ~DECT301()
        {

        }
    }
}
