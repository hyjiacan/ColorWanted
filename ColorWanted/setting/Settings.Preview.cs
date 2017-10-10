
using System.Drawing;

namespace ColorWanted.setting
{
    partial class Settings
    {
        /// <summary>
        /// 预览窗口 
        /// </summary>
        public static class Preview
        {
            private const string section = "preview";

            private static void Set(string key, string value)
            {
                SetValue(section, key, value);
            }

            private static string Get(string key)
            {
                return GetValue(section, key);
            }

            /// <summary>
            /// 预览窗口的大小
            /// </summary>
            public static int Size
            {
                get
                {
                    int temp;
                    int.TryParse(Get("size"), out temp);
                    return temp;
                }
                set
                {
                    Set("size", value.ToString());
                }
            }

            /// <summary>
            /// 是否显示预览窗口
            /// </summary>
            public static bool Visible
            {
                get
                {
                    var v = Get("visible");
                    return v == "" || v == "1";
                }
                set
                {
                    Set("visible", value ? "1" : "0");
                }
            }

            /// <summary>
            /// 预览窗口的最后位置
            /// </summary>
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

            /// <summary>
            /// 是否使用像素放大，默认为true
            /// </summary>
            public static bool PixelScale
            {
                get
                {
                    var v = Get("pixelscale");
                    return v == "" || v == "1";
                }
                set
                {
                    Set("pixelscale", value ? "1" : "0");
                }
            }
        }
    }
}
