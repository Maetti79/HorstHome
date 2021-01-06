using System;
using System.Drawing;

namespace FritzHome
{
    public class SmartDeviceColor : IDisposable
    {
        public String Name;
        public Int32 Hue;
        public Int32 Saturation;
        public Int32 Value;
        public Color Color;

        public SmartDeviceColor(String n, Int32 h, Int32 s, Int32 v)
        {
            Name = n;
            Hue = h;
            Saturation = s;
            Value = v;
            Color = ColorRGB.HsBtoRgb((Double)Hue, (Double)Saturation / 255, (Double)Value / 255);
        }

        public void Dispose()
        {

        }

        ~SmartDeviceColor()
        {

        }
    }
}

