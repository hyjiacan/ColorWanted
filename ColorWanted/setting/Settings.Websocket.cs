
namespace ColorWanted.setting
{
    partial class Settings
    {
        /// <summary>
        /// 进程间通信使用的消息配置
        /// </summary>
        [SettingModule("Webcosket 支持")]
        public static class Websocket
        {
            private const string section = "websocket";
            private static void Set(string key, string value)
            {
                SetValue(section, key, value);
            }

            private static string Get(string key)
            {
                return GetValue(section, key);
            }

            /// <summary>
            /// 是否启用websocket支持
            /// </summary>
            [SettingItem("是否启用", true)]
            public static bool Enabled
            {
                get
                {
                    var v = Get("enabled");
                    // 默认为禁用
                    return v == "1";
                }
                set
                {
                    Set("enabled", value ? "1" : "0");
                }
            }

            /// <summary>
            /// 端口
            /// </summary>
            [SettingItem("端口", true)]
            public static int Port
            {
                get
                {
                    var p = Get("port");
                    if (!int.TryParse(p, out int port))
                    {
                        port = 9791;
                    }
                    return port;
                }
                set
                {
                    Set("port", value.ToString());
                }
            }
        }
    }
}
