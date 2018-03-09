using System;
using System.Drawing;

namespace ColorWanted.colors
{
    public class HSL
    {
        public float H { get; set; }
        public float S { get; set; }
        public float L { get; set; }

        public HSL() { }

        public HSL(float h, float s, float l)
        {
            H = h;
            S = s;
            L = l;
        }

        public static HSL Parse(Color color)
        {
            // 算法参考: https://en.wikipedia.org/wiki/HSL_and_HSV#Hue_and_chroma
            var hsl = new HSL();
            var r = color.R / 255f;
            var g = color.G / 255f;
            var b = color.B / 255f;
            var min = Math.Min(r, Math.Min(g, b));
            var max = Math.Max(r, Math.Max(g, b));

            #region H
            if (max == min)
            {
                hsl.H = 0;
            }
            else if (max == r)
            {
                if (g >= b)
                {
                    hsl.H = 60 * ((g - b) / (max - min));
                }
                else
                {
                    hsl.H = 60 * ((g - b) / (max - min)) + 360;
                }
            }
            else if (max == g)
            {
                hsl.H = 60 * ((b - r) / (max - min)) + 120;
            }
            else
            {
                hsl.H = 60 * ((r - g) / (max - min)) + 240;
            }
            #endregion

            hsl.L = (max + min) / 2;

            if (hsl.L == 0 || max == min)
            {
                hsl.S = 0;
                return hsl;
            }

            if (hsl.L < 0.5)
            {
                hsl.S = (max - min) / (max+min);
                return hsl;
            }

            hsl.S = (max - min) / (2 - (max + min));

            return hsl;
        }
    }
}
