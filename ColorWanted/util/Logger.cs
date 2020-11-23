using System;
using System.Diagnostics;
using System.IO;

namespace ColorWanted.util
{
    internal static class Logger
    {
        private static string DataPath;

        static Logger()
        {
            DataPath = Path.Combine(Glob.AppDataPath, "logs");

            if (Directory.Exists(DataPath)) return;

            try
            {
                Directory.CreateDirectory(DataPath);
            }
            catch
            {
            }
        }

        public static void Write(string level, string message)
        {
            try
            {
                var now = DateTime.Now;
                using (var stream = File.AppendText(Path.Combine(DataPath, now.ToString("yyyy年MM月") + ".log")))
                {
                    stream.WriteLine($"[{now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}");
                    stream.Close();
                }
            }
            catch
            {
                // ignore
                // 写日志失败时，不用提示什么
            }
        }

        private static string GetCaller()
        {
            var method = new StackTrace().GetFrame(2).GetMethod();
            return $"{method.ReflectedType.FullName}.{method.Name}";
        }

        public static void Debug(string message)
        {
#if DEBUG
            Write("DEBUG", message);
#endif
        }

        public static void Info(string message)
        {
            Write("INFO", message);
        }

        public static void Warn(string message)
        {
            Write("WARN", message);
        }

        public static void Warn(Exception exception)
        {
            Warn($"{GetCaller()}\n{exception.Message}\n{exception.StackTrace}");
        }

        public static void Error(string message)
        {
            Write("ERROR", $"{GetCaller()}\n{message}");
        }

        public static void Error(Exception exception)
        {
            Error($"{exception.Message}\n{exception.StackTrace}");
        }

        public static void Fatal(string message)
        {
            Write("FATAL", $"{GetCaller()}\n{message}");
        }

        public static void Fatal(Exception exception)
        {
            Fatal($"{exception.Message}\n{exception.StackTrace}");
        }
    }
}
