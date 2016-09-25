using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

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

        public static bool Autostart
        {
            get
            {
                try
                {
                    using (var reg = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run"))
                    {
                        if (reg != null)
                        {
                            var path = reg.GetValue(Application.ProductName);
                            if (path != null)
                            {
                                if (string.Equals(path.ToString(), "\"" + Application.ExecutablePath + "\"", StringComparison.OrdinalIgnoreCase))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                catch { }

                return false;
            }

            set
            {
                try
                {
                    using (var reg = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run"))
                    {
                        if (value)
                        {
                            reg.SetValue(Application.ProductName, "\"" + Application.ExecutablePath + "\"");
                        }
                        else
                        {
                            reg.DeleteValue(Application.ProductName);
                        }
                    }
                }
                catch
                {
                }
            }
        }
    }
}
