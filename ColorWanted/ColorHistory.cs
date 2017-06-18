using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ColorWanted
{
    /// <summary>
    /// 取色历史记录项
    /// </summary>
    internal class ColorHistory
    {
        public DateTime DateTime { get; set; }

        public Color Color { get; set; }

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
                var temp = row.Split(',');
                return new ColorHistory()
                {
                    DateTime = DateTime.Parse(temp[0]),
                    Color = Color.FromArgb(int.Parse(temp[1]))
                };
            }).ToArray();
        }

        /// <summary>
        /// 记录颜色历史
        /// </summary>
        /// <param name="color">颜色</param>
        public static void Record(Color color)
        {

            File.AppendAllText(FullName,
                string.Format("{0: yyyy-MM-dd HH:mm:ss},{1}{2}",
                    DateTime.Now,
                    color.ToArgb(),
                    Environment.NewLine));
        }
    }
}
