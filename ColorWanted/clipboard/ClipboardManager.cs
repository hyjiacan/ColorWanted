using System;
using System.IO;
using System.Text;

namespace ColorWanted.clipboard
{
    static class ClipboardManager
    {
        public static bool CopyHistory;
        public static readonly string DataRoot;


        static ClipboardManager()
        {
            DataRoot = Path.Combine(Glob.AppDataPath, "clipboard");
            if (!Directory.Exists(DataRoot))
            {
                Directory.CreateDirectory(DataRoot);
            }
        }

        /// <summary>
        /// 写文件并返回文件名
        /// </summary>
        /// <param name="text"></param>
        /// <param name="hashcode"></param>
        /// <returns></returns>
        public static string Write(string text, int hashcode)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }
            var data = new ClipboardData()
            {
                Data = text,
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            // 文件名为hashcode

            var dir = Path.Combine(DataRoot, DateTime.Now.ToString("yyyy/MM/dd"));
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            var fullname = Path.Combine(dir, hashcode + ".board");

            File.WriteAllText(fullname, data.ToString(), Encoding.UTF8);
            return fullname;
        }

        public static ClipboardData Read(string fullname)
        {
            if (!File.Exists(fullname))
            {
                return null;
            }
            return ClipboardData.Parse(File.ReadAllText(fullname));
        }

        public static void Remove(string fullname)
        {
            if (File.Exists(fullname))
            {
                File.Delete(fullname);
            }
        }

        public static string[] Load(string path)
        {
            return Directory.GetFiles(path, "*.board", SearchOption.TopDirectoryOnly);
        }
    }
}
