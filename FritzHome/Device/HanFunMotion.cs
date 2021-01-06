using System;
using System.Xml.Linq;

namespace FritzHome
{
    public class HanFunMotion : SmartDevice
    {

        public HanFunMotion(XElement device): base(device)
        {
            iconId = 9;
            Battery = 100;
        }

        ~HanFunMotion()
        {

        }
    }
}
