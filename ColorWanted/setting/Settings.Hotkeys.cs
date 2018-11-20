using System;
using System.Windows.Forms;
using ColorWanted.hotkey;

namespace ColorWanted.setting
{
    partial class Settings
    {
        /// <summary>
        /// 快捷键
        /// </summary>
        public static class Hotkeys
        {
            private const string section = "hotkey";

            private static void Set(string key, string value)
            {
                SetValue(section, key, value);
            }

            private static string Get(string key)
            {
                return GetValue(section, key);
            }

            public static HotKey Get(HotKeyType type)
            {
                var text = Get(type.ToString());
                if (string.IsNullOrWhiteSpace(text))
                {
                    return null;
                }

                var temp = text.Split('#');

                var hotkey = HotKey.FromType(type);
                hotkey.Modifiers = (KeyModifier)Enum.Parse(typeof(KeyModifier), temp[0]);

                switch (temp[1])
                {
                    case "`":
                        hotkey.Key = Keys.Oemtilde;
                        break;
                    case "Enter":
                        hotkey.Key = Keys.Enter;
                        break;
                    case "CapsLock":
                        hotkey.Key = Keys.CapsLock;
                        break;
                    default:
                        hotkey.Key = (Keys) Enum.Parse(typeof(Keys), temp[1]);
                        break;
                }
                return hotkey;
            }

            public static void Set(HotKey hotkey)
            {
                Set(hotkey.HotKeyType.ToString(),
                    string.Format("{0}#{1}", (int)hotkey.Modifiers, (int)hotkey.Key));
            }
        }
    }
}
