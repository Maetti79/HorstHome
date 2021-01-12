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
        public DateTime lastUpdate;

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

        public void tryUpdate(String Uri, String SID, Int32 cooldown = 10)
        {
            DateTime Now = DateTime.Now;
            try
            {
                if (Now.Subtract(lastUpdate).TotalSeconds > cooldown)
                {
                    foreach (SmartDevice device in Devices)
                    {
                        device.tryUpdate(Uri, SID, 30);
                    }
                    lastUpdate = DateTime.Now;
                }
            }
            catch (Exception Ex)
            {
              
            }
        }

        public void Dispose()
        {

        }

        ~SmartDeviceGroup()
        {

        }
    }
}
