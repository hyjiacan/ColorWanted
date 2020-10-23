using ColorWanted.ext;
using ColorWanted.setting;
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
        public static PointF ScaleRatio { get; private set; }

        static Util()
        {
            ScaleRatio = GetScaleRatio();
        }

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


        public static Size GetScreenSize(bool workingArea = false)
        {
            int width = 0;
            int height = 0;

            if (workingArea)
            {
                width = Screen.AllScreens.Sum(screen => screen.WorkingArea.Width);
                height = Screen.PrimaryScreen.WorkingArea.Height;
            }
            else
            {
                width = Screen.AllScreens.Sum(screen => screen.Bounds.Width);
                height = Screen.PrimaryScreen.Bounds.Height;
            }
            return new Size(width, height);
        }

        public static Rectangle GetCurrentScreen(bool workingArea = false)
        {
            var mousePosition = new Point();

            NativeMethods.GetCursorPos(ref mousePosition);

            return workingArea ? Screen.GetWorkingArea(mousePosition) : Screen.GetBounds(mousePosition);
        }

        public static Rectangle GetScreenBounds(bool workingDir = false)
        {
            if (Settings.Shoot.CurrentScreen)
            {
                return GetCurrentScreen(workingDir);
            }

            return new Rectangle(new Point(0, 0), GetScreenSize(workingDir));
        }

        public static string Round(double value)
        {
            var temp = value.ToString("0.00").Split('.');

            temp[1] = temp[1].TrimEnd('0');

            return temp[1] == "" ? temp[0] : string.Join(".", temp);
        }
        public static bool RunAsAdmin()
        {
            /**
             * 当前用户是管理员的时候，直接启动应用程序
             * 如果不是管理员，则使用启动对象启动程序，以确保使用管理员身份运行
             */
            //获得当前登录的Windows用户标示
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            //创建Windows用户主题
            Application.EnableVisualStyles();

            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            //判断当前登录用户是否为管理员
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                return true;
            }

            if (MessageBox.Show("此操作需要管理员权限，点击\"确定\"以管理员身份运行", "管理员", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return false;
            }

            //创建启动对象
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                //设置运行文件
                FileName = Application.ExecutablePath,
                //设置启动参数
                //startInfo.Arguments = String.Join(" ", Args);
                //设置启动动作,确保以管理员身份运行
                Verb = "runas"
            };
            try
            {
                //如果不是管理员，则启动UAC
                System.Diagnostics.Process.Start(startInfo);
                //退出
                Environment.Exit(0);
            }
            catch
            {
            }
            return false;
        }

        /// <summary>
        /// 获取屏幕的缩放比例
        /// </summary
        /// <see cref="https://blog.csdn.net/chenlu5201314/article/details/89792317"/>
        /// <returns></returns>
        public static PointF GetScaleRatio()
        {
            IntPtr hdc = NativeMethods.GetDC(IntPtr.Zero);

            float ScaleX = (float)NativeMethods.GetDeviceCaps(hdc, NativeMethods.DESKTOPHORZRES)
                / NativeMethods.GetDeviceCaps(hdc, NativeMethods.HORZRES);

            float ScaleY = (float)NativeMethods.GetDeviceCaps(hdc, NativeMethods.DESKTOPVERTRES)
                / NativeMethods.GetDeviceCaps(hdc, NativeMethods.VERTRES);

            // uint pixel = GetPixel(hdc, (int)(pnt.X * ScaleX), (int)(pnt.Y * ScaleY));

            return new PointF(ScaleX, ScaleY);
        }

        public static int ScaleX(int value)
        {
            if (value == 0)
            {
                return value;
            }
            var scale = ScaleRatio;
            if (scale.X == 1)
            {
                return value;
            }

            return (int)(value * scale.X);
            //return value;
        }

        public static int ScaleY(int value)
        {
            if (value == 0)
            {
                return value;
            }
            var scale = ScaleRatio;
            if (scale.Y == 1)
            {
                return value;
            }

            return (int)(value * scale.Y);
            //return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>当文件不存在或长度为0时，返回空字符串</returns>
        public static string HashFile(string filename)
        {
            if (!File.Exists(filename))
            {
                return "";
            }
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                if (fs.Length == 0)
                {
                    return "";
                }
                var hash = System.Security.Cryptography.SHA1.Create().ComputeHash(fs);
                fs.Close();
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }
    }
}
