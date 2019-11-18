namespace ColorWanted.setting
{
    partial class Settings
    {
        /// <summary>
        /// 剪贴板 
        /// </summary>
        public static class Clipboard
        {
            private const string section = "clipboard";

            private static void Set(string key, string value)
            {
                SetValue(section, key, value);
            }

            private static string Get(string key)
            {
                return GetValue(section, key);
            }

            /// <summary>
            /// 是否监视剪贴板
            /// </summary>
            public static bool Enabled
            {
                get
                {
                    var v = Get("enabled");
                    return v == "1";
                }
                set
                {
                    Set("enabled", value ? "1" : "0");
                }
            }
        }
    }
}
