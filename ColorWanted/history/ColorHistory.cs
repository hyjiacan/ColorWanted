using ColorWanted.setting;
using ColorWanted.util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

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

        /// <summary>
        /// 历史记录存放路径(完整路径)
        /// </summary>
        public static readonly string RecordPath;

        static ColorHistory()
        {
            FullName = Path.Combine(Settings.DataPath, "history.txt");
            RecordPath = Path.Combine(Settings.DataPath, "history");

            if (!Directory.Exists(RecordPath))
            {
                Directory.CreateDirectory(RecordPath);
            }
        }

        /// <summary>
        /// 读取颜色历史
        /// </summary>
        /// <returns></returns>
        public static ColorHistory[] Get(string path)
        {
            return File.ReadAllLines(path).Select(row =>
            {
                try
                {
                    var temp = row.Split(',');
                    return new ColorHistory
                    {
                        // 从 4.1.0 开始，日期记录为时间戳格式
                        // 以前的格式为： yyyy-MM-dd HH:mm:ss
                        DateTime = temp[0].Contains(" ") ? DateTime.Parse(temp[0]) : DateTime.FromFileTime(long.Parse(temp[0])),
                        Color = Color.FromArgb(int.Parse(temp[1])),
                        Source = int.Parse(temp[2])
                    };
                }
                catch(Exception ex)
                {
                    Logger.Warn(ex);
                    return null;
                }
            }).Where(item => item != null).ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year">year为0时，获取年份，不为0时，获取对应年的月份</param>
        /// <returns></returns>
        public static List<DateTreeNode> GetDateTree(int year = 0)
        {
            Migrate();

            if (year == 0)
            {
                return Directory.GetDirectories(RecordPath).Select(yearPath =>
                {
                    return new DateTreeNode
                    {
                        Name = Path.GetFileNameWithoutExtension(yearPath),
                        Path = yearPath,
                        ParentYear = year
                    };
                }).ToList();
            }

            return Directory.GetFiles(Path.Combine(RecordPath, year.ToString())).Select(yearPath =>
            {
                return new DateTreeNode
                {
                    Name = Path.GetFileNameWithoutExtension(yearPath),
                    Path = yearPath,
                    ParentYear = year
                };
            }).ToList();
        }

        /// <summary>
        /// 记录颜色历史
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="source">取色来源，默认为0，表示来自屏幕取色，为1表示调色板取色</param>
        public static void Record(Color color, int source = 0, DateTime? date = null)
        {
            var now = date ?? DateTime.Now;
            var dirName = Path.Combine(RecordPath, now.Year.ToString());
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            // 每月一个文件
            var fileName = Path.Combine(dirName, string.Format("{0:MM}.txt", now));

            File.AppendAllText(fileName,
                string.Format("{0},{1},{2}{3}",
                    DateTime.Now.ToFileTime(),
                    color.ToArgb(),
                    source,
                    Environment.NewLine));
        }

        private static void Migrate()
        {
            // 从老版本 (3.2.5及以前) 的历史记录文件 history.txt 迁移到新的格式
            if (!File.Exists(FullName))
            {
                return;
            }

            foreach (var item in Get(FullName).Where(i => i != null))
            {
                Record(item.Color, item.Source, item.DateTime);
            }

            System.Threading.Thread.Sleep(1000);
            // 移除老版本文件
            File.Delete(FullName);
        }
    }
}
