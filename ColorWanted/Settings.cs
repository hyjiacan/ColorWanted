using System.IO;
using System.Windows.Forms;
using System.Text;

namespace ColorWanted
{
    class Settings
    {
        private static string filename;
        private const string section = "colorwanted";
        static Settings()
        {
            filename = Path.Combine(Path.GetTempPath(), Application.ProductName);
        }

        public static void Set(string key, string value)
        {
            try
            {
                NativeMethods.WriteIni(section, key, value, filename);
            }
            catch { }
        }

        public static string Get(string key)
        {
            try
            {
                var buf = new StringBuilder(512);
                NativeMethods.ReadIni(section, key, "", buf, 512, filename);
                return buf.ToString();
            }
            catch { return ""; }
        }
    }
}
