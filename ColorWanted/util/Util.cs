using ColorWanted.ext;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ColorWanted.util
{
    /// <summary>
    /// 静态工具类
    /// </summary>
    internal static class Util
    {
        /// <summary>
        /// 使用 Windows API复制数据到剪贴板
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="text"></param>
        /// <returns>复制成功时返回 null,失败时返回错误消息</returns>
        public static string SetClipboard(IntPtr handle, string text)
        {
            // 把要复制的数据搞成字节
            var data = Encoding.Default.GetBytes(text);
            return SetClipboard(handle, 1, data);
        }

        /// <summary>
        /// 使用 Windows API复制数据到剪贴板
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="image"></param>
        /// <returns>复制成功时返回 null,失败时返回错误消息</returns>
        public static string SetClipboard(IntPtr handle, Image image)
        {
            Clipboard.SetImage(image);
            return null;
            //// 把要复制的数据搞成字节
            //using (var stream = new MemoryStream())
            //{
            //    stream.Position = 0;
            //    image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            //    var data = stream.ToArray();
            //    File.WriteAllBytes("a.png", data);
            //    return SetClipboard(handle, 2, data);
            //}
        }

        /// <summary>
        /// 使用 Windows API复制数据到剪贴板
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="format">
        /// #define CF_TEXT             1
        /// #define CF_BITMAP           2
        /// #define CF_METAFILEPICT     3
        /// #define CF_SYLK             4
        /// #define CF_DIF              5
        /// #define CF_TIFF             6
        /// #define CF_OEMTEXT          7
        /// #define CF_DIB              8
        /// #define CF_PALETTE          9
        /// #define CF_PENDATA          10
        /// #define CF_RIFF             11
        /// #define CF_WAVE             12
        /// #define CF_UNICODETEXT      13
        /// #define CF_ENHMETAFILE      14
        /// 选项在 WinUser.h 里面可以找到定义
        /// </param>
        /// <param name="data"></param>
        /// <returns>复制成功时返回 null,失败时返回错误消息</returns>
        public static string SetClipboard(IntPtr handle, uint format, byte[] data)
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

            // 复制数据
            NativeMethods.SetClipboardData(format, mem);

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
            if (reportform.Visible)
            {
                reportform.BringToFront();
                return;
            }
            reportform.SetException(ex);
            reportform.ShowDialog();
            reportform.BringToFront();
        }

        /// <summary>
        /// 枚举出一个枚举类型的所有项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> Enum<T>() where T : struct
        {
            var type = typeof(T);
            return System.Enum.GetNames(type)
                .Select(name => (T)System.Enum.Parse(type, name));
        }

        private static BugReportForm reportform;

        private static Size ScreenSize;

        public static Size GetScreenSize()
        {
            if (!ScreenSize.IsEmpty) return ScreenSize;

            var screen = Screen.PrimaryScreen.WorkingArea;
            ScreenSize = new Size(screen.Width, screen.Height);

            return ScreenSize;
        }

        public static string Round(double value)
        {
            var temp = value.ToString("0.00").Split('.');

            temp[1] = temp[1].TrimEnd('0');

            return temp[1] == "" ? temp[0] : string.Join(".", temp);
        }
    }
}
