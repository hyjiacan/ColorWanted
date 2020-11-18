using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ColorWanted.ext;

// ReSharper disable EmptyGeneralCatchClause
// 防止权限问题导致的失败
// 即使失败，也不应该影响功能
// 所有文件操作都加个  try catch
namespace ColorWanted.setting
{
    /// <summary>
    /// 配置文件操作
    /// </summary>
    internal static partial class Settings
    {
        /// <summary>
        /// 配置数据存放路径
        /// </summary>
        public static readonly string DataPath;

        /// <summary>
        /// 配置完整路径
        /// </summary>
        public static readonly string FullName;

        /// <summary>
        /// 配置文件名
        /// </summary>
        public const string FileName = "option.ini";

        /// <summary>
        /// 为了减少频繁读取配置引发性能问题，添加配置项的缓存
        /// </summary>
        private static readonly Dictionary<string, string> cache = new Dictionary<string, string>();

        static Settings()
        {
            DataPath = Path.Combine(Environment
                    .GetFolderPath(Environment.SpecialFolder.ApplicationData),
                Application.ProductName);
            FullName = Path.Combine(DataPath, FileName);

            if (Directory.Exists(DataPath)) return;

            try
            {
                Directory.CreateDirectory(DataPath);
            }
            catch
            {
            }
        }

        private static void UpodateCache(string section, string key, string value)
        {
            var cacheKey = $"{section}-{key}";
            if (cache.ContainsKey(cacheKey))
            {
                cache[cacheKey] = value;
            }
            else
            {
                cache.Add(cacheKey, value);
            }
        }

        private static void SetValue(string section, string key, string value)
        {
            try
            {
                UpodateCache(section, key, value);
                NativeMethods.WriteIni(section, key, value, FullName);
            }
            catch { }
        }

        private static string GetValue(string section, string key)
        {
            try
            {
                var cacheKey = $"{section}-{key}";
                if (cache.ContainsKey(cacheKey))
                {
                    return cache[cacheKey];
                }

                var buf = new StringBuilder(512);
                NativeMethods.ReadIni(section, key, "", buf, 512, FullName);

                var value = buf.ToString();
                cache.Add(cacheKey, value);

                return value;
            }
            catch { return ""; }
        }

        private static Point ParsePoint(string loc)
        {
            var point = Point.Empty;

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
