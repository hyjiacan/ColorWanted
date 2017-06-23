using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ColorWanted.setting
{
    // ReSharper disable EmptyGeneralCatchClause
    // 防止权限问题导致的失败
    // 即使失败，也不应该影响功能
    // 所有文件操作都加个  try catch
    partial class Settings
    {
        /// <summary>
        /// 基础配置
        /// </summary>
        public static class Base
        {
            private const string section = "base";

            private static void Set(string key, string value)
            {
                SetValue(section, key, value);
            }

            private static string Get(string key)
            {
                return GetValue(section, key);
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
                            if (reg == null) return;
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


            public static bool IsFirstRun
            {
                get { return Get("firstrun") != "0"; }
                set
                {
                    Set("firstrun", value ? "1" : "0");
                }
            }

            /// <summary>
            /// 调色板的自定义颜色
            /// </summary>
            public static int[] CustomColors
            {
                get
                {
                    var temp = Get("customcolors");
                    return string.IsNullOrWhiteSpace(temp)
                        ? null
                        : temp.Split(',').Select(int.Parse).ToArray();
                }
                set
                {
                    Set("customcolors", string.Join(",", value));
                }
            }



            /// <summary>
            /// 是否只复制十六进制的值，为true时复制不会包含#字符，默认为 false
            /// </summary>
            public static bool HexValueOnly
            {
                get { return Get("hexvalueonly") == "1"; }
                set
                {
                    Set("hexvalueonly", value ? "1" : "0");
                }
            }

            /// <summary>
            /// 是否只复制RGB的值，为true时复制不会包含rgb()字符只有值  "255,255,255"，默认为 false
            /// </summary>
            public static bool RgbValueOnly
            {
                get { return Get("rgbvalueonly") == "1"; }
                set
                {
                    Set("rgbvalueonly", value ? "1" : "0");
                }
            }
        }
    }
}
