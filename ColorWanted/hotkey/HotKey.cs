using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ColorWanted.ext;
using ColorWanted.setting;
using ColorWanted.util;

namespace ColorWanted.hotkey
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class HotKey : Attribute
    {
        public string Name { get; private set; }
        public KeyModifier Modifiers { get; set; }
        public Keys Key { get; set; }
        public HotKeyType HotKeyType { get; set; }

        public HotKey(string name)
        {
            Name = name;
        }

        public bool HasHotkey()
        {
            return Modifiers != KeyModifier.None || Key != Keys.None;
        }

        public override string ToString()
        {
            var buffer = new StringBuilder();
            if ((Modifiers & KeyModifier.Ctrl) == KeyModifier.Ctrl)
            {
                buffer.Append(@"Ctrl + ");
            }
            if ((Modifiers & KeyModifier.Shift) == KeyModifier.Shift)
            {
                buffer.Append(@"Shift + ");
            }
            if ((Modifiers & KeyModifier.Alt) == KeyModifier.Alt)
            {
                buffer.Append(@"Alt + ");
            }
            switch (Key)
            {
                case Keys.Oemtilde:
                    buffer.Append("`");
                    break;
                case Keys.Enter:
                    buffer.Append("Enter");
                    break;
                case Keys.CapsLock:
                    buffer.Append("CapsLock");
                    break;
                default:
                    buffer.Append(Key);
                    break;
            }
            return buffer.ToString();
        }

        public void Reset()
        {
            var hotkey = FromType(HotKeyType);
            Modifiers = hotkey.Modifiers;
            Key = hotkey.Key;
        }

        public string ToFullString()
        {
            return string.Format(@"{0} # {1} #", Name, ToString());
        }

        public static HotKey FromType(HotKeyType hotKeyType)
        {
            var type = typeof(HotKeyType);
            var attrs = type.GetField(hotKeyType.ToString()).GetCustomAttributes(typeof(HotKey), false);
            if (attrs.Length == 0)
            {
                return null;
            }
            var attr = attrs[0] as HotKey;
            // ReSharper disable once PossibleNullReferenceException
            attr.HotKeyType = hotKeyType;
            return attr;
        }

        public static HotKey Get(HotKeyType type)
        {
            return Settings.Hotkeys.Get(type) ?? FromType(type);
        }

        public static void Set(HotKey hotkey)
        {
            Settings.Hotkeys.Set(hotkey);
        }

        #region 快捷键的绑定与解除绑定操作
        /// <summary>
        /// 将全局快捷键绑定到指定句柄上
        /// </summary>
        /// <param name="handle"></param>
        public static void Bind(IntPtr handle)
        {
            foreach (var hotkey in Util.Enum<HotKeyType>().Select(Get)
                .Where(hotkey=>hotkey.HasHotkey()))
            {
                NativeMethods.RegisterHotKey(handle,
                    hotkey.HotKeyType.AsInt(),
                    hotkey.Modifiers,
                    hotkey.Key);
            }
        }

        /// <summary>
        /// 将全局快捷键绑定到指定句柄上
        /// </summary>
        public static void Bind()
        {
            Bind(MainForm.Instance.Handle);
        }

        /// <summary>
        /// 将全局快捷键从指定句柄上解除绑定
        /// </summary>
        /// <param name="handle"></param>
        public static void Unbind(IntPtr handle)
        {
            foreach (var hotkey in Util.Enum<HotKeyType>())
            {
                NativeMethods.UnregisterHotKey(handle, hotkey.AsInt());
            }
        }
        /// <summary>
        /// 将全局快捷键从指定句柄上解除绑定
        /// </summary>
        public static void Unbind()
        {
            Unbind(MainForm.Instance.Handle);
        }
        #endregion
    }
}

