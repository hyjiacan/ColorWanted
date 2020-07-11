
namespace ColorWanted.setting
{
    partial class Settings
    {
        /// <summary>
        /// 进程间通信使用的消息配置
        /// </summary>
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
        }
    }
}
