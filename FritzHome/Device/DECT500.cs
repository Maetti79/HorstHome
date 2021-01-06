using System;
using System.Xml.Linq;

namespace FritzHome
{
    public class DECT500 : SmartDevice
    {

        public DECT500(XElement device): base(device)
        {
            iconId = 7;
            Battery = 100;
        }

        ~DECT500()
        {

        }
    }
}
