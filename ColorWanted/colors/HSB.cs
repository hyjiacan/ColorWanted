using System;
using System.Drawing;

namespace ColorWanted.colors
{
    public class HSB
    {
        public float H { get; set; }
        public float S { get; set; }
        public float B { get; set; }

        public HSB() { }

        public HSB(int h, int s, int b)
        {
            H = h;
            S = s;
            B = b;
        }

        public static HSB Parse(Color color)
        {
            // 算法参考: https://en.wikipedia.org/wiki/HSL_and_HSV#Hue_and_chroma
            var hsb = new HSB
            {
                H = (int)color.GetHue()
            };

            var r = color.R / 255f;
            var g = color.G / 255f;
            var b = color.B / 255f;

            if (r == g && g == b)
            {
                hsb.S = 0;
                hsb.B = r;
                return hsb;
            }

            var min = Math.Min(r, Math.Min(g, b));
            var max = Math.Max(r, Math.Max(g, b));

            hsb.S = 1 - min / max;
            hsb.B = max;

            return hsb;
        }
    }
}
