using ColorWanted.enums;
using ColorWanted.ext;
using System;
using System.Windows.Forms;

namespace ColorWanted
{
    /// <summary>
    /// 静态工具类
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// 将全局快捷键绑定到指定句柄上
        /// </summary>
        /// <param name="handle"></param>
        public static void BindHotkeys(IntPtr handle)
        {
            NativeMethods.RegisterHotKey(handle, HotKeyValue.CopyHexColor.AsInt(), KeyModifiers.Alt, Keys.C);
            NativeMethods.RegisterHotKey(handle, HotKeyValue.CopyRgbColor.AsInt(), KeyModifiers.Alt, Keys.G);
            NativeMethods.RegisterHotKey(handle, HotKeyValue.SwitchMode.AsInt(), KeyModifiers.Alt, Keys.F1);
        }

        /// <summary>
        /// 将全局快捷键从指定句柄上解除绑定
        /// </summary>
        /// <param name="handle"></param>
        public static void UnbindHotkeys(IntPtr handle)
        {
            NativeMethods.UnregisterHotKey(handle, HotKeyValue.CopyHexColor.AsInt());
            NativeMethods.UnregisterHotKey(handle, HotKeyValue.CopyRgbColor.AsInt());
            NativeMethods.UnregisterHotKey(handle, HotKeyValue.SwitchMode.AsInt());
        }
    }
}
