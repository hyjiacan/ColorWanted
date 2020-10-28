using System;
using System.Drawing;
using System.Windows.Forms;
using ColorWanted.viewer;
using Microsoft.Win32;

namespace ColorWanted.setting
{
    partial class Settings
    {
        /// <summary>
        /// 基础配置
        /// </summary>
        [SettingModule("图片查看器")]
        public static class Viewer
        {
            private const string section = "viewer";

            private static void Set(string key, string value)
            {
                SetValue(section, key, value);
            }

            private static string Get(string key)
            {
                return GetValue(section, key);
            }

            /// <summary>
            /// 自定义背景色
            /// </summary>
            public static Color BackColor
            {
                get
                {
                    var color = Color.FromArgb(64, 64, 64);
                    var val = Get("backcolor");

                    if (string.IsNullOrWhiteSpace(val) || !int.TryParse(val, out int colorValue))
                    {
                        return color;
                    }
                    try
                    {
                        return Color.FromArgb(colorValue);
                    }
                    catch
                    {
                        return color;
                    }
                }
                set
                {
                    Set("backcolor", value.ToArgb().ToString());
                }
            }

            /// <summary>
            /// 是否启用单实例，启用时只打开一个看图窗口，默认为 true
            /// </summary>
            [SettingItem("是否启用单实例，启用时只打开一个看图窗口")]
            public static bool Singleton
            {
                get { return Get("singleton") != "0"; }
                set
                {
                    Set("singleton", value ? "1" : "0");
                }
            }

            /// <summary>
            /// 是否绘制边框
            /// </summary>
            public static bool DrawBorder
            {
                get { return Get("drawborder") != "0"; }
                set
                {
                    Set("drawborder", value ? "1" : "0");
                }
            }

            /// <summary>
            /// 是否绘制中心标线
            /// </summary>
            public static bool DrawCenterLine
            {
                get { return Get("drawcenterline") != "0"; }
                set
                {
                    Set("drawcenterline", value ? "1" : "0");
                }
            }

            [SettingItem("启用图片查看器")]
            public static bool Enabled
            {
                get
                {
                    // 从配置文件读取配置
                    return Get("enabled") == "1";
                }

                set
                {
                    //if (!Util.RunAsAdmin())
                    //{
                    //    Enabled = value;
                    //    return;
                    //}
                    try
                    {
                        var name = Application.ProductName;
                        var exePath = '"' + Application.ExecutablePath + '"';
                        var root = Registry.ClassesRoot;
                        RegistryKey shell = root.OpenSubKey(@"*\shell", true);

                        string appId = $"hyjiacan.{name}.1";

                        if (value)
                        {
                            // 双击打开支持
                            RegistryKey key = root.CreateSubKey(appId);
                            key = key.CreateSubKey("shell");
                            key = key.CreateSubKey("open");
                            key = key.CreateSubKey("command");
                            key.SetValue(string.Empty, exePath + " /viewer \"%1\"");
                            key.Close();

                            Array.ForEach(ViewerUtil.SUPPORTED_IMAGES_TYPES, item =>
                            {
                                root.CreateSubKey(item).SetValue(string.Empty, appId);
                            });

                            //if (shell.GetSubKeyNames().Contains(name))
                            //{
                            //    return;
                            //}
                            //RegistryKey custom = shell.CreateSubKey(name);
                            //custom.SetValue(string.Empty, "Open with " + name);
                            //custom.SetValue("Icon", exePath);
                            //RegistryKey cmd = custom.CreateSubKey("command");
                            //cmd.SetValue(string.Empty, exePath);
                            //cmd.Close();
                            //custom.Close();
                        }
                        else
                        {
                            // 删除
                            root.DeleteSubKeyTree(appId, false);
                            Array.ForEach(ViewerUtil.SUPPORTED_IMAGES_TYPES, item =>
                            {
                                if (root.CreateSubKey(item).GetValue(string.Empty)?.ToString() == appId)
                                {
                                    root.CreateSubKey(item).DeleteValue(string.Empty);
                                }
                            });
                            shell.DeleteSubKeyTree(name, false);
                        }

                        shell.Close();
                        shell.Dispose();

                        // 写注册表成功后，将其写入配置文件，以避免每次启动读取注册表
                        Set("enabled", value ? "1" : "0");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"此操作需要管理员权限，请重新以管理员身份运行: {e.Message}");
                    }
                }
            }
        }
    }
}
