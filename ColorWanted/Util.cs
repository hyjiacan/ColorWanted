using ColorWanted.enums;
using ColorWanted.ext;
using System;
using System.Runtime.InteropServices;
using System.Text;
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
            NativeMethods.RegisterHotKey(handle, HotKeyValue.CopyColor.AsInt(), KeyModifiers.Alt, Keys.C);
            NativeMethods.RegisterHotKey(handle, HotKeyValue.ShowMoreFormat.AsInt(), KeyModifiers.Alt, Keys.E);
            NativeMethods.RegisterHotKey(handle, HotKeyValue.SwitchMode.AsInt(), KeyModifiers.Alt, Keys.F1);
            NativeMethods.RegisterHotKey(handle, HotKeyValue.ShowPreview.AsInt(), KeyModifiers.Alt, Keys.F2);
            NativeMethods.RegisterHotKey(handle, HotKeyValue.ShowColorPicker.AsInt(), KeyModifiers.Alt, Keys.F3);
            // Alt + ` 键
            NativeMethods.RegisterHotKey(handle, HotKeyValue.DrawControl.AsInt(), KeyModifiers.Alt, Keys.Oemtilde);
        }

        /// <summary>
        /// 将全局快捷键从指定句柄上解除绑定
        /// </summary>
        /// <param name="handle"></param>
        public static void UnbindHotkeys(IntPtr handle)
        {
            NativeMethods.UnregisterHotKey(handle, HotKeyValue.CopyColor.AsInt());
            NativeMethods.UnregisterHotKey(handle, HotKeyValue.ShowMoreFormat.AsInt());
            NativeMethods.UnregisterHotKey(handle, HotKeyValue.SwitchMode.AsInt());
            NativeMethods.UnregisterHotKey(handle, HotKeyValue.ShowPreview.AsInt());
            NativeMethods.UnregisterHotKey(handle, HotKeyValue.ShowColorPicker.AsInt());
            NativeMethods.UnregisterHotKey(handle, HotKeyValue.DrawControl.AsInt());
        }

        /// <summary>
        /// 使用 Windows API复制数据到剪贴板
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="text"></param>
        /// <returns>复制成功时返回 null,失败时返回错误消息</returns>
        public static string SetClipboard(IntPtr handle, string text)
        {
            // 打开
            if (!NativeMethods.OpenClipboard(handle))
            {
                return "打开剪贴板失败";
            }

            // 清空
            if (!NativeMethods.EmptyClipboard())
            {
                NativeMethods.CloseClipboard();
                return "打开剪贴板失败";
            }

            // 把要复制的数据搞成字节
            var data = Encoding.Default.GetBytes(text);

            // 多整一个字节，用来放结果符
            var datalength = data.Length + 1;

            // 分配内存 使用 0: GMEM_FIXED 标记
            // 在 winbase.h 中可以找到定义

            var mem = NativeMethods.GlobalAlloc(2, datalength);

            // 分配失败
            if (mem == IntPtr.Zero)
            {
                NativeMethods.CloseClipboard();
                return "分配内存失败";
            }

            // 锁定内存
            var buffer = NativeMethods.GlobalLock(mem);

            // 分配失败
            if (buffer == IntPtr.Zero)
            {
                NativeMethods.CloseClipboard();
                return "锁定失败";
            }

            // 写数据到内存
            Marshal.Copy(data, 0, buffer, data.Length);

            // 复制数据 使用 1: CF_TEXT 选项
            // 选项在 WinUser.h 里面可以找到定义
            NativeMethods.SetClipboardData(1, mem);

            // 解除锁定
            NativeMethods.GlobalUnlock(mem);

            // 关闭
            NativeMethods.CloseClipboard();

            return null;
        }

        public static void ShowBugReportForm(Exception ex)
        {
            // 发生未处理的异常时，打开BUG报告窗口
            if (reportform == null)
            {
                reportform = new BugReportForm();
            }
            reportform.SetException(ex);
            reportform.ShowDialog();
            Application.Exit();
        }

        private static BugReportForm reportform;
    }
}
