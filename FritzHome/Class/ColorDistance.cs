using System.Drawing;
using System.Linq;
using System;

namespace FritzHome
{
    public class ColorDistance
    {
        public static SmartDeviceColor GetClosestColor(SmartDeviceColor[] colorArray, Color baseColor)
        {
            var colors = colorArray.Select(x => new { Value = x, Diff = GetDiff(x, baseColor) }).OrderBy(x => x.Diff).ToList();
     
            var max = colors.Max(x => x.Diff);
            return colors.Find(x => x.Diff == max).Value;
        }

        public static double GetDiff(SmartDeviceColor c1, Color c2)
        {
            double d = Math.Sqrt(Math.Pow(c1.Color.R - c2.R, 2) + Math.Pow(c1.Color.G - c2.G, 2) + Math.Pow(c1.Color.B - c2.B, 2));
            return d / Math.Sqrt((255) ^ 2 + (255) ^ 2 + (255) ^ 2);
        }

    }
}
