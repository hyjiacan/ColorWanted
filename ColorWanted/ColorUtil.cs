using System;
using System.Drawing;

namespace ColorWanted
{
    class ColorUtil
    {
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


        public static Color GetColor(Point screenPoint)
        {
            IntPtr displayDC = NativeMethods.CreateDC("DISPLAY", null, null, IntPtr.Zero);
            uint colorref = NativeMethods.GetPixel(displayDC, screenPoint.X, screenPoint.Y);
            NativeMethods.DeleteDC(displayDC);
            return Color.FromArgb(GetRValue(colorref), GetGValue(colorref), GetBValue(colorref));
        }

        /// <summary>
        /// 获取指定颜色的对比色
        /// </summary>
        /// <param name="color"></param>
        /// <param name="light">使用浅色</param>
        /// <returns></returns>
        public static Color GetContrastColor(Color color, bool light = false)
        {
            if (isDark(color) || isSingle(color))
            {
                return light ? Color.FromArgb(220, 220, 220) : Color.White;
            }

            if (isLight(color) || isGray(color))
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

        private static CMYK cmyk;

        /// <summary>
        /// RGB 颜色值搞成 CMYK格式
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        internal static CMYK RGB2CMYK(Color color)
        {
            cmyk.Cyan = (byte)(255 - color.R);
            cmyk.Magenta = (byte)(255 - color.G);
            cmyk.Yellow = (byte)(255 - color.B);
            cmyk.Black = 0;

            var min = Math.Min(cmyk.Cyan, Math.Min(cmyk.Magenta, cmyk.Yellow));

            if (min != 0)
            {
                var fix = (byte)Math.Round(Settings.CmykFixValue * min / 100.0);

                cmyk.Cyan -= fix;
                cmyk.Magenta -= fix;
                cmyk.Yellow -= fix;
                cmyk.Black = (byte)Math.Round(fix / 2.55);
            }


            cmyk.Cyan = (byte)Math.Round(cmyk.Cyan / 2.55);
            cmyk.Magenta = (byte)Math.Round(cmyk.Magenta / 2.55);
            cmyk.Yellow = (byte)Math.Round(cmyk.Yellow / 2.55);


            return cmyk;
        }
    }
}
