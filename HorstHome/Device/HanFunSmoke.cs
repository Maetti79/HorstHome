﻿using System;
using System.Xml.Linq;

namespace HorstHome
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
