using System;
using System.Linq;
using System.Windows.Forms;
using ColorWanted.enums;
using ColorWanted.ext;
using ColorWanted.util;

namespace ColorWanted.hotkey
{
    internal class HotKey
    {
        public HotKeyType HotKeyType { get; set; }
        public KeyModifier KeyModifier { get; set; }
        public Keys Key { get; set; }

        private static IntPtr MainFormHandle;

        public HotKey() { }

        public HotKey(HotKeyType hotKeyType, Keys key, KeyModifier keyModifier = KeyModifier.Alt)
        {
            HotKeyType = hotKeyType;
            KeyModifier = keyModifier;
            Key = key;
        }

        private static readonly HotKey[] hotkeys;
        // TODO 定义快捷键   
        static HotKey()
        {
            hotkeys = new[]
            { 
                new HotKey(HotKeyType.BringToTop ,Keys.T),
                new HotKey(HotKeyType.CopyColor,  Keys.C),
                new HotKey(HotKeyType.CopyPolicy,  Keys.V),   
                new HotKey(HotKeyType.ControlDraw,  Keys.Oemtilde),
                new HotKey(HotKeyType.ShowColorPicker,  Keys.F3),
                new HotKey(HotKeyType.ShowMoreFormat,  Keys.E),
                new HotKey(HotKeyType.ShowPreview,  Keys.F2),
                new HotKey(HotKeyType.SwitchMode,  Keys.F1) 
            };
        }

        public static HotKey Get(HotKeyType type)
        {
            return hotkeys.First(item => item.HotKeyType == type);
        }


        /// <summary>
        /// 将全局快捷键绑定到指定句柄上
        /// </summary>
        /// <param name="handle"></param>
        public static void Bind(IntPtr handle)
        {
            MainFormHandle = handle;
            foreach (var hotkey in Util.Enum<HotKeyType>().Select(Get))
            {
                NativeMethods.RegisterHotKey(handle, hotkey.HotKeyType.AsInt(), hotkey.KeyModifier, hotkey.Key);
            }
        }

        /// <summary>
        /// 将全局快捷键绑定到指定句柄上
        /// </summary>
        public static void Bind()
        {
            Bind(MainFormHandle);
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
            Unbind(MainFormHandle);
        }
    }
}
