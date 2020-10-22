
namespace ColorWanted.setting
{
    partial class Settings
    {
        /// <summary>
        /// 截图和录屏配置
        /// </summary>
        public static class Shoot
        {
            private const string section = "shoot";
            private static void Set(string key, string value)
            {
                SetValue(section, key, value);
            }

            private static string Get(string key)
            {
                return GetValue(section, key);
            }

            /// <summary>
            /// 仅在当前光标所在屏幕操作，默认为 true
            /// </summary>
            public static bool CurrentScreen
            {
                get { return Get("currentscreen") != "0"; }
                set
                {
                    Set("currentscreen", value ? "1" : "0");
                }
            }

            /// <summary>
            /// 是否在操作时隐藏取色窗口(主窗口的预览窗口)，默认为 true
            /// </summary>
            public static bool HideColorWindows
            {
                get { return Get("hidecolorwindows") != "0"; }
                set
                {
                    Set("hidecolorwindows", value ? "1" : "0");
                }
            }
        }
    }
}
