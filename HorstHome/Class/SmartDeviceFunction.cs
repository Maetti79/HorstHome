using System;

namespace HorstHome
{
    [Flags]
    public enum SmartDeviceFunctionType : int
    {
        HanFun = 0,
        Light = 1,
        Alarm = 1 << 1,
        Button = 1 << 2,
        Thermostat = 1 << 6,
        Energie = 1 << 7,
        Thermometer = 1 << 8,
        Switch = 1 << 9,
        DECTRepeater = 1 << 10,
        Microphone = 1 << 11,
        Blind = 1 << 13,
        Aktor = 1 << 15,
        Level = 1 << 16,
        Color = 1 << 17
    }

    [Flags]
    public enum SmartDeviceColorModeType : int
    {
        None = 0,
        HueSaturation = 1 ,
        ColorThemteratur = 4
    }

    public class SmartDeviceFunction
    {

        public SmartDeviceFunctionType MethodBit;

        public SmartDeviceFunction(String functbit)
        {
            MethodBit = (SmartDeviceFunctionType)Enum.Parse(typeof(SmartDeviceFunctionType), functbit);
        }

        public void addHanFunInterface(String hanfuni)
        {
            Int32 HanFunInterface = Int32.Parse(hanfuni);
            if (HanFunInterface == 277) // KEEP_ALIVE
            {
            }
            if (HanFunInterface == 256) // ALERT
            {
                MethodBit ^= SmartDeviceFunctionType.Alarm;
            }
            if (HanFunInterface == 512) // ON_OFF
            {
                MethodBit ^= MethodBit & SmartDeviceFunctionType.Switch;
            }
            if (HanFunInterface == 513) // LEVEL_CTRL
            {
                MethodBit ^= SmartDeviceFunctionType.Level;
            }
            if (HanFunInterface == 514) // COLOR_CTRL
            {
                MethodBit ^= SmartDeviceFunctionType.Color;
            }
            if (HanFunInterface == 772) // SIMPLE_BUTTON
            {
                MethodBit ^= SmartDeviceFunctionType.Button;
            }
            if (HanFunInterface == 1024) // SUOTA-Update)
            {
            }
        }

        public Boolean hasFlag(SmartDeviceFunctionType flag)
        {
            return MethodBit.HasFlag(flag);
        }

        ~SmartDeviceFunction()
        {

        }
    }

    public class SmartDeviceColorMode
    {

        public SmartDeviceColorModeType MethodBit;

        public SmartDeviceColorMode(String functbit)
        {
            MethodBit = (SmartDeviceColorModeType)Enum.Parse(typeof(SmartDeviceColorModeType), functbit);
        }

        public Boolean hasFlag(SmartDeviceColorModeType flag)
        {
            return MethodBit.HasFlag(flag);
        }

        ~SmartDeviceColorMode()
        {

        }
    }

}
