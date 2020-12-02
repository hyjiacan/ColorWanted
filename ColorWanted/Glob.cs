using System;
using System.IO;
using System.Windows.Forms;

namespace ColorWanted
{
    /// <summary>
    /// 全局数据
    /// </summary>
    internal static class Glob
    {
        public static string AppDataPath { get; private set; }

        static Glob()
        {
            AppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                Application.ProductName);

            if (Directory.Exists(AppDataPath)) return;

            try
            {
                Directory.CreateDirectory(AppDataPath);
            }
            catch
            {
                // ignore
            }
        }
    }
}
