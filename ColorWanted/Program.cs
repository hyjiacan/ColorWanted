using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

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
            if (args.Length > 0 && !DoUpdateThing(args))
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

        private static bool DoUpdateThing(string[] args)
        {
            log("文件", Application.ExecutablePath);
            log("接受到参数", string.Join(" ", args));
            // 参数长度至少应该是三个

            if (args.Length < 3)
            {
                log("参数长度<3");
                return false;
            }

            // 第一个参数  -update 才有效
            if (args[0] != "-update")
            {
                log("第一个参数不是  -update");
                return false;
            }

            // phase 控制更新不同阶段
            var phase = args[1];

            var oldname = args[2];

            if (phase == "1")
            {
                Thread.Sleep(2000);
                // 此时此程序是刚刚下载的新文件
                // 需要将旧文件重命名
                File.Move(oldname, oldname + ".old");

                // 复制新文件。文件名与旧文件相同
                File.Copy(Application.ExecutablePath, oldname);

                // 启动新文件
                Process.Start(oldname, string.Format(@"-update 2 ""{0}""", Application.ExecutablePath));
                return false;
            }

            if (phase == "2")
            {
                Thread.Sleep(2000);
                // 删除临时文件
                File.Delete(oldname);

                // 删除旧文件
                File.Delete(Application.ExecutablePath + ".old");
                return true;
            }

            return false;
        }

        static void log(params string[] msg)
        {
            File.AppendAllText(@"D:\x.log",string.Join("", msg));
        }
    }
}
