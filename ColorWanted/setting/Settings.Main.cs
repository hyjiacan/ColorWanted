using System;
using System.Drawing;
using ColorWanted.mode;

namespace ColorWanted.setting
{
    partial class Settings
    {
        /// <summary>
        /// 主窗口（取色窗口）
        /// </summary>
        public static class Main
        {
            private const string section = "main";
            private static void Set(string key, string value)
            {
                SetValue(section, key, value);
            }

            private static string Get(string key)
            {
                return GetValue(section, key);
            }


            public static Point Location
            {
                get
                {
                    return ParsePoint(Get("location"));
                }
                set
                {
                    Set("location", string.Format("{0},{1}", value.X, value.Y));
                }
            }
            public static FormatMode Format
            {
                get
                {
                    var mode = Get("format");
                    FormatMode temp;
                    if (!Enum.TryParse(mode, out temp))
                    {
                        temp = FormatMode.Mini;
                    }
                    return temp;
                }
                set
                {
                    Set("format", ((int)value).ToString());
                }
            }

            public static DisplayMode Display
            {
                get
                {
                    var v = Get("display");
                    DisplayMode mode;
                    if (!Enum.TryParse(v, out mode))
                    {
                        mode = DisplayMode.Fixed;
                    }
                    return mode;
                }
                set
                {
                    Set("display", value.ToString());
                }
            }
        }

    }
}
