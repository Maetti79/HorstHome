using System;
using System.Xml.Linq;
using System.Collections.Generic;

namespace HorstHome
{
    public class SmartDeviceGroup : IDisposable
    {
        public String GroupName;
        public Int32 Id;
        public Int32 iconId;

        public List<SmartDevice> Devices;

        public SmartDeviceGroup(String name)
        {
            GroupName = name;
            iconId = 2;
            Devices = new List<SmartDevice>();
        }

        public void addDevice(SmartDevice device)
        {
            Devices.Add(device);
            iconId = device.iconId;
        }

        public void Dispose()
        {

        }

        ~SmartDeviceGroup()
        {

        }
    }
}
