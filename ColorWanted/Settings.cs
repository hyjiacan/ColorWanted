using ColorWanted.enums;
using Microsoft.Win32;
using System;
using System.Drawing;
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

        private static bool Set(string key, string value)
        {
            try
            {
                NativeMethods.WriteIni(section, key, value, filename);
				return true;
            }
            catch 
			{ 
				return false;
			}
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

        public static DisplayMode Mode
        {
            get
            {
                var v = Get("mode");
                DisplayMode mode;
                if (!Enum.TryParse<DisplayMode>(v, out mode))
                {
                    mode = DisplayMode.Fixed;
                }
                return mode;
            }
            set
            {
                Set("mode", value.ToString());
            }
        }


        public static Point Location
        {
            get
            {
                return ParsePoint(Get("location"));
            }
            set
            {
                Set("location", string.Format("{0},{1}", value.X, value.Y));
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
					
					return false;
                }
                catch {
					return false;
				}
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

        public static Point PreviewLocation
        {
            get
            {
                return ParsePoint(Get("previewLocation"));
            }
            set
            {
                Set("previewLocation", string.Format("{0},{1}", value.X, value.Y));
            }
        }

        private static Point ParsePoint(string loc)
        {
            Point point = Point.Empty;

            if (string.IsNullOrWhiteSpace(loc))
            {
                return point;
            }

            var arr = loc.Split(',');
            if (arr.Length != 2)
            {
                return point;
            }
            int x, y;
            if (int.TryParse(arr[0], out x))
            {
                point.X = x;
            }
            if (int.TryParse(arr[1], out y))
            {
                point.Y = y;
            }

            return point;
        }
    }
}
