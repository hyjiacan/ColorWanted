
namespace ColorWanted.setting
{
    partial class Settings
    {
        /// <summary>
        /// 进程间通信使用的消息配置
        /// </summary>

        [SettingModule("UDP 消息")]
        public static class Msg
        {
            private const string section = "msg";
            private static void Set(string key, string value)
            {
                SetValue(section, key, value);
            }

            private static string Get(string key)
            {
                return GetValue(section, key);
            }

            /// <summary>
            /// UDP 端口
            /// </summary>
            public static int Port
            {
                get
                {
                    var p = Get("port");
                    int.TryParse(p, out int port);
                    return port;
                }
                set
                {
                    Set("port", value.ToString());
                }
            }

            /// <summary>
            /// 是否启用取色广播
            /// </summary>
            [SettingItem("是否启用取色广播")]
            public static bool BroadcastEnabled
            {
                get
                {
                    var v = Get("broadcastenabled");
                    // 默认为禁用
                    return v == "1";
                }
                set
                {
                    Set("broadcastenabled", value ? "1" : "0");
                }
            }

            /// <summary>
            /// UDP 端口
            /// </summary>
            [SettingItem("取色广播端口")]
            public static int BroadcastPort
            {
                get
                {
                    var p = Get("broadcastport");
                    if (!int.TryParse(p, out int port))
                    {
                        port = 9792;
                    }
                    return port;
                }
                set
                {
                    Set("broadcastport", value.ToString());
                }
            }
        }
    }
}
