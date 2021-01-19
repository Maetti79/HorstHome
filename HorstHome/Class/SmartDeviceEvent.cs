using System;
using System.Drawing;

namespace HorstHome
{

    [Flags]
    public enum SmartDeviceEventType : int
    {
        None,
        Connect,
        Disconnect,
        BatteryWarning,
        ThemeraturAlert,
        MotionAlert,
        SmokeAlert,
        WaterAlert,
        CO2Alert,
        GlassbreakAlert,
        SabotageAlert,
        PowerlostAlert,
    }

    public class SmartDeviceEvent : IDisposable
    {
        
        public SmartDevice device;
        public SmartDeviceEventType alert;

        public SmartDeviceEvent(SmartDevice d,SmartDeviceEventType e)
        {
            device = d;
            alert = e;
        }

        public void Dispose()
        {

        }

        ~SmartDeviceEvent()
        {

        }
    }
}

