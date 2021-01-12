using System;
using System.Xml.Linq;

namespace HorstHome
{
    public class CometDECT : SmartDevice
    {

        public CometDECT(XElement device): base(device)
        {
            iconId = 8;
            XElement batt = device.Element("battery");
            Battery = Int32.Parse(batt.Value);
        }

        ~CometDECT()
        {

        }
    }
}
