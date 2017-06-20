using ColorWanted.update;
using System;
using System.Threading;
using System.Windows.Forms;

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
            if (args.Length > 0 && !OnlineUpdate.HandleUpdateArgs(args))
            {
                return;
            }

            bool createdNew;
            // ReSharper disable once ObjectCreationAsStatement
            new Mutex(true, Application.ProductName, out createdNew);
            if (!createdNew)
            {
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
