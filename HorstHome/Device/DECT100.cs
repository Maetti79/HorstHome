using System;
using System.Xml.Linq;

namespace HorstHome
{
    public class DECT100 : SmartDevice
    {

        public DECT100(XElement device) : base(device)
        {
            iconId = 0;
            Battery = 100;
        }

        ~DECT100()
        {

        }
    }
}
