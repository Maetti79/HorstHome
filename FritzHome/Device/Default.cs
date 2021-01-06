using System;
using System.Xml.Linq;

namespace FritzHome
{
    public class Default : SmartDevice
    {

        public Default(XElement device): base(device)
        {
            iconId = 5;
        }

        ~Default()
        {

        }
    }
}
