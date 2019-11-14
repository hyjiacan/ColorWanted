using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ColorWanted.screenshot
{
    internal static class ScreenShot
    {
        public static readonly int SCREEN_WIDTH;
        public static readonly int SCREEN_HEIGHT;
        private static ScreenForm screenForm;
        private static ScreenRecordForm recordForm;

        /// <summary>
        /// 标记是否正在截图
        /// </summary>
        public static bool Busy { private set; get; }

        static ScreenShot()
        {
            var screen = Screen.PrimaryScreen.Bounds;
            SCREEN_WIDTH = screen.Width;
            SCREEN_HEIGHT = screen.Height;
        }

        public static void Init()
        {
            screenForm = new ScreenForm();

            screenForm.FormClosing += (sender, e) =>
            {
                Busy = false;
                GC.Collect();
            };
        }

        /// <summary>
        /// 获取屏幕指定位置和大小的部分
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Bitmap GetScreen(int x1, int y1, int width, int height)
        {
            var image = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(image))
            {
                g.CopyFromScreen(x1, y1, 0, 0, new Size(width, height));
            }
            return image;
        }

        public static void Capture()
        {
            if (screenForm == null)
            {
                return;
            }
            if (Busy)
            {
                return;
            }
            Busy = true;
            // 获取当前整个屏幕的截图
            var image = GetScreen(0, 0, SCREEN_WIDTH, SCREEN_HEIGHT);
            try
            {
                screenForm.Show(image);
            }
            catch (Exception e)
            {
                Busy = false;
                throw e;
            }
        }

        /// <summary>
        /// 录制工作流程
        /// 1. 绑定快捷键 Alt+R
        /// 2. 打开录制窗口后，显示选项工具条
        /// 3. 设置好选项后，点击【开始】以开始录制
        /// 4. 点击后隐藏工具条，再次按下快捷键停止录制，并显示保存位置选择对话框
        /// 5. 选择保存文件后，合成GIF文件，关闭录制窗口
        /// </summary>
        public static void Record()
        {
            if (Busy)
            {
                if (recordForm != null)
                {
                    // 关闭窗口，此时会停止录制
                    recordForm.Close();
                }
                return;
            }
            Busy = true;
            try
            {
                recordForm = new ScreenRecordForm();
                recordForm.FormClosed += RecordForm_FormClosed;
                recordForm.ShowDialog();
            }
            finally
            {
                Busy = false;
                if (recordForm != null)
                {
                    recordForm.Close();
                    recordForm.Dispose();
                }
            }
        }

        private static void RecordForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Directory.Exists(ScreenRecordOption.CachePath) ||
                Directory.GetFiles(ScreenRecordOption.CachePath).Length == 0)
            {
                return;
            }
            var f = new ScreenRecordSaveForm();
            f.FormClosed += (s, e1) =>
            {
                Busy = false;
                if (Directory.Exists(ScreenRecordOption.CachePath))
                {
                    Directory.Delete(ScreenRecordOption.CachePath, true);
                }
            };
            f.ShowDialog();
            f.Dispose();
        }
    }
}
