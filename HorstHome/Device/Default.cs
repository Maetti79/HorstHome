using System;
using System.Xml.Linq;

namespace HorstHome
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
