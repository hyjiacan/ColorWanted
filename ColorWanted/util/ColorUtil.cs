using System;
using System.Drawing;
using ColorWanted.ext;

namespace ColorWanted.util
{
    internal static class ColorUtil
    {
        private readonly static IntPtr displayDC;
        public static int Range = 0;

        static ColorUtil()
        {
            displayDC = NativeMethods.CreateDC("DISPLAY", null, null, IntPtr.Zero);
        }

        public static void DeleteDC()
        {
            NativeMethods.DeleteDC(displayDC);
        }

        public static byte GetRValue(uint color)
        {
            return (byte)color;
        }

        public static byte GetGValue(uint color)
        {
            return (byte)((short)color >> 8);
        }

        public static byte GetBValue(uint color)
        {
            return (byte)(color >> 16);
        }

        public static Color GetColor(Point screenPoint)
        {
            var colorref = NativeMethods.GetPixel(displayDC, screenPoint.X, screenPoint.Y);
            return Color.FromArgb(GetRValue(colorref), GetGValue(colorref), GetBValue(colorref));
        }

        public static bool isGray(Color color)
        {
            return bt(color.R) + bt(color.G) + bt(color.B) >= 2;
        }

        public static int bt(byte val)
        {
            return val >= 100 && val <= 200 ? 1 : 0;
        }

        public static bool isLight(Color color)
        {
            return gt200(color.R) + gt200(color.G) + gt200(color.B) >= 2;
        }

        public static bool isDark(Color color)
        {
            return lt150(color.R) + lt150(color.G) + lt150(color.B) >= 2;
        }

        public static bool isSingle(Color color)
        {
            return lt100(color.R) + lt100(color.G) + lt100(color.B) == 2 && gt200(color.R) + gt200(color.G) + gt200(color.B) == 1;
        }
        public static int lt150(byte val)
        {
            return val <= 150 ? 1 : 0;
        }
        public static int lt100(byte val)
        {
            return val <= 100 ? 1 : 0;
        }

        public static int gt200(byte val)
        {
            return val >= 200 ? 1 : 0;
        }

        /// <summary>
        /// 获取指定颜色的对比色
        /// </summary>
        /// <param name="color"></param>
        /// <param name="light">使用浅色</param>
        /// <returns></returns>
        public static Color GetContrastColor(Color color, bool light = false)
        {
            if (isDark(color) || isSingle(color) || isGray(color))
            {
                return light ? Color.FromArgb(220, 220, 220) : Color.White;
            }

            if (isLight(color))
            {
                return light ? Color.FromArgb(150, 150, 150) : Color.Black;
            }

            var diffr = 255 - color.R;
            var diffg = 255 - color.G;
            var diffb = 255 - color.B;

            if (light)
            {
                if (diffr < 100)
                {
                    diffr += 50;
                }
                if (diffg < 100)
                {
                    diffg += 50;
                }
                if (diffb < 100)
                {
                    diffb += 50;
                }
            }

            return Color.FromArgb(diffr, diffg, diffb);
        }


        /// <summary>
        /// 判断两个颜色是否相同或在指定的色差范围内
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <param name="range">允许的差范围</param>
        /// <returns></returns>
        public static bool IsSimilarColor(Color c1, Color c2, int range = -1)
        {
            if (range == -1)
            {
                range = Range;
            }
            return lt(c1.R, c2.R, range) && lt(c1.G, c2.G, range) && lt(c1.B, c2.B, range);
        }

        static bool lt(int a, int b, int lt)
        {
            return Math.Abs(a - b) <= lt;
        }
    }
}

