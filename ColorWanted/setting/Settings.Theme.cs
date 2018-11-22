
using ColorWanted.theme;
using System;
using System.Drawing;

namespace ColorWanted.setting
{
    partial class Settings
    {
        /// <summary>
        /// 主题 
        /// </summary>
        public static class Theme
        {
            private const string section = "theme";

            private static void Set(string key, string value)
            {
                SetValue(section, key, value);
            }

            private static string Get(string key)
            {
                return GetValue(section, key);
            }

            /// <summary>
            /// 窗体透明度
            /// </summary>
            public static int Opacity
            {
                get
                {
                    int temp;
                    if (!int.TryParse(Get("opacity"), out temp))
                    {
                        // 默认透明度为80%
                        temp = 80;
                    }
                    return temp;
                }
                set
                {
                    Set("opacity", value.ToString());
                }
            }

            /// <summary>
            /// 配色类型
            /// </summary>
            public static ThemeType Type
            {
                get
                {
                    ThemeType type;
                    if (!Enum.TryParse(Get("type"), true, out type))
                    {
                        // 默认使用黑色
                        type  = ThemeType.Dark;
                    }
                    return type;
                }
                set
                {
                    Set("type", value.ToString());
                }
            }

            /// <summary>
            /// 自定义主题的前景色
            /// </summary>
            public static Color CustomForeColor
            {
                get
                {
                    var color = Color.Empty;
                    var val = Get("customforecolor");
                    int colorValue;

                    if (string.IsNullOrWhiteSpace(val) || !int.TryParse(val, out colorValue))
                    {
                        return color;
                    }
                    try
                    {
                        return Color.FromArgb(colorValue);
                    }
                    catch
                    {
                        return color;
                    }
                }
                set
                {
                    Set("customforecolor", value.ToArgb().ToString());
                }
            }

            /// <summary>
            /// 自定义主题的背景色
            /// </summary>
            public static Color CustomBackColor
            {
                get
                {
                    var color = Color.Empty;
                    var val = Get("custombackcolor");
                    int colorValue;

                    if (string.IsNullOrWhiteSpace(val) || !int.TryParse(val, out colorValue))
                    {
                        return color;
                    }
                    try
                    {
                        return Color.FromArgb(colorValue);
                    }
                    catch
                    {
                        return color;
                    }
                }
                set
                {
                    Set("custombackcolor", value.ToArgb().ToString());
                }
            }
        }
    }
}
