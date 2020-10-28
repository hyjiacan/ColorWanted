
namespace ColorWanted.setting
{
    partial class Settings
    {
        [SettingModule("多语言")]
        public static class I18n
        {
            private const string section = "i18n";
            private static void Set(string key, string value)
            {
                SetValue(section, key, value);
            }

            private static string Get(string key)
            {
                return GetValue(section, key);
            }

            /// <summary>
            /// 语言
            /// </summary>
            [SettingItem("设置语言")]
            public static string Lang
            {
                get { return Get("lang"); }
                set
                {
                    Set("lang", value);
                }
            }
        }
    }
}
