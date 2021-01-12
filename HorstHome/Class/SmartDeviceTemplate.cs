using System;

namespace HorstHome
{
    public class SmartDeviceTemplate : IDisposable
    {
        public String Name;

        public SmartDeviceTemplate(String n)
        {
            Name = n;
        }

        public void Dispose()
        {

        }

        ~SmartDeviceTemplate()
        {

        }
    }
}

