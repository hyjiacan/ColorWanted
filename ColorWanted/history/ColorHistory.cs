using System;
using System.Drawing;
using System.IO;
using System.Linq;
using ColorWanted.util;

namespace ColorWanted.history
{
    /// <summary>
    /// 取色历史记录项
    /// </summary>
    internal class ColorHistory
    {
        /// <summary>
        /// 取色时间，精确到秒
        /// </summary>
        public DateTime DateTime { get; set; }
        /// <summary>
        /// 颜色值
        /// </summary>
        public Color Color { get; set; }
        /// <summary>
        /// 取色来源，默认为0，表示来自屏幕取色，为1表示调色板取色
        /// </summary>
        public int Source { get; set; }

        /// <summary>
        /// 历史记录文件名称(完整路径)
        /// </summary>
        public static readonly string FullName;

        static ColorHistory()
        {
            FullName = Path.Combine(Settings.DataPath, "history.txt");
            if (File.Exists(FullName))
            {
                return;
            }

            File.Create(FullName).Close();
        }

        /// <summary>
        /// 读取颜色历史
        /// </summary>
        /// <returns></returns>
        public static ColorHistory[] Get()
        {
            return File.ReadAllLines(FullName).Select(row =>
            {
                try
                {
                    var temp = row.Split(',');
                    return new ColorHistory
                    {
                        DateTime = DateTime.Parse(temp[0]),
                        Color = Color.FromArgb(int.Parse(temp[1])),
                        Source = int.Parse(temp[2])
                    };
                }
                catch
                {
                    return null;
                }
            }).Where(item => item != null).ToArray();
        }

        /// <summary>
        /// 记录颜色历史
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="source">取色来源，默认为0，表示来自屏幕取色，为1表示调色板取色</param>
        public static void Record(Color color, int source = 0)
        {

            File.AppendAllText(FullName,
                string.Format("{0:yyyy-MM-dd HH:mm:ss},{1},{2}{3}",
                    DateTime.Now,
                    color.ToArgb(),
                    source,
                    Environment.NewLine));
        }
    }
}
