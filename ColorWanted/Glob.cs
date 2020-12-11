using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;

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

        public static bool IsShiftKeyDown
        {
            get
            {
                var val = ext.NativeMethods.GetKeyState(0x10);
                return val < 0;
            }
        }
    }
}
