using System;
using System.Threading;
using System.Windows.Forms;
using ColorWanted.util;

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
            bool createdNew;
            // ReSharper disable once ObjectCreationAsStatement
            new Mutex(true, Application.ProductName, out createdNew);
            if (!createdNew)
            {
                return;
            }

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
                Application.Run(new MainForm());
            }
            catch (ObjectDisposedException)
            {
                // ignore
            }
        }
    }
}
