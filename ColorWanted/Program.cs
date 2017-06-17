using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ColorWanted.update;

namespace ColorWanted
{
    static class Program
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
