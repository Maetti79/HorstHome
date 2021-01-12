using System;
using System.Xml.Linq;

namespace HorstHome
{
    public class DECT200 : SmartDevice
    {

        public DECT200(XElement device) : base(device)
        {
            iconId = 1;
            Battery = 100;
         
            XElement toggle = device.Element("switch");
            if (toggle.Element("state").Value != "")
            {
                Switch = Convert.ToBoolean(Convert.ToInt32(toggle.Element("state").Value.ToString()));
            }
        }

        ~DECT200()
        {

        }
    }
}
