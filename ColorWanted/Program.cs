using ColorWanted.update;
using System;
using System.Threading;
using System.Windows.Forms;
using ColorWanted.util;
using System.Diagnostics;

namespace ColorWanted
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        public static void Main(params string[] args)
        {
            if (args.Length > 0 && args[1] == "/update" && !OnlineUpdate.HandleUpdateArgs(args))
            {
                return;
            }

            // ReSharper disable once ObjectCreationAsStatement
            using (_ = new Mutex(true, Application.ProductName, out bool createdNew))
            {
                if (createdNew)
                {
                    Run(args);
                    return;
                }
                RunWithArgs(args);
            }
        }

        private static void Run(params string[] args)
        {
            // 绑定异常捕捉处理函数
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender, e) =>
            {
                Util.ShowBugReportForm(e.Exception);
            };
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                if (e.IsTerminating)
                {

                }
                Util.ShowBugReportForm((Exception)e.ExceptionObject);
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new MainForm(args));
            }
            catch (ObjectDisposedException)
            {
                // ignore
            }
        }

        private static void RunWithArgs(params string[] args)
        {
            var argLength = args.Length;
            if (argLength == 0)
            {
                // 没有参数时，直接显示原窗口
                Msg.Send(MsgTypes.ShowWindow);
                return;
            }

            // 如果是查看图片
            if (argLength > 1 && args[0] == "/viewer")
            {
                Msg.Send(MsgTypes.ViewImage, args[1]);
            }
        }
    }
}
