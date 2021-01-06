using System;
using System.Xml.Linq;

namespace FritzHome
{
    public class DECT201 : SmartDevice
    {

        public DECT201(XElement device) : base(device)
        {
            iconId = 2;

            Battery = 100;
         
            XElement toggle = device.Element("switch");
            if (toggle.Element("state").Value != "")
            {
                Switch = Convert.ToBoolean(Convert.ToInt32(toggle.Element("state").Value.ToString()));
            }
        }

        ~DECT201()
        {

        }
    }
}
