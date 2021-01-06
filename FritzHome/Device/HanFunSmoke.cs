using System;
using System.Xml.Linq;

namespace FritzHome
{
    public class HanFunSmoke : SmartDevice
    {

        public HanFunSmoke(XElement device): base(device)
        {
            iconId = 10;
            Battery = 100;
        }

        ~HanFunSmoke()
        {

        }
    }
}
