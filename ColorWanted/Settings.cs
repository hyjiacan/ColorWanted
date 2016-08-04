using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Drawing;

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

        private static void Set(string key, string value)
        {
            try
            {
                NativeMethods.WriteIni(section, key, value, filename);
            }
            catch { }
        }

        private static string Get(string key)
        {
            try
            {
                var buf = new StringBuilder(512);
                NativeMethods.ReadIni(section, key, "", buf, 512, filename);
                return buf.ToString();
            }
            catch { return ""; }
        }

        public static bool FormVisible
        {
            get
            {
                var v = Get("visible");
                return v == "" || v == "1";
            }
            set
            {
                Set("visible", value ? "1" : "0");
            }
        }

        public static bool AutoPin
        {
            get
            {
                var v = Get("autopin");
                return v == "" || v == "1";
            }
            set
            {
                Set("autopin", value ? "1" : "0");
            }
        }

        public static bool ShowRgb
        {
            get
            {
                var v = Get("showrgb");
                return v != "" && v == "1";
            }
            set
            {
                Set("showrgb", value ? "1" : "0");
            }
        }

        public static bool FollowCaret
        {
            get
            {
                var v = Get("follow");
                return v != "" && v == "1";
            }
            set
            {
                Set("follow", value ? "1" : "0");
            }
        }


        public static string Location
        {
            get
            {
                return Get("location");
            }
            set
            {
                Set("location", value);
            }
        }
    }
}
