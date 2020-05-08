using ColorWanted.ext;
using ColorWanted.util;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ColorWanted.screenshot
{
    internal static class ScreenShot
    {
        private static ScreenForm screenForm;
        private static ScreenRecordForm recordForm;
        private static SaveFileDialog saveImageDialog;
        private static SaveFileDialog saveRecordDialog;

        /// <summary>
        /// 标记是否正在截图
        /// </summary>
        public static bool Busy { private set; get; }

        public static void Init()
        {
            screenForm = new ScreenForm();

            screenForm.FormClosing += (sender, e) =>
            {
                Busy = false;
                GC.Collect();
            };

            saveImageDialog = new SaveFileDialog
            {
                AddExtension = true,
                DefaultExt = "png",
                SupportMultiDottedExtensions = true,
                Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            saveRecordDialog = new SaveFileDialog
            {
                AddExtension = true,
                DefaultExt = "gif",
                SupportMultiDottedExtensions = true,
                Filter = "Gif Image|*.gif",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
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
            try
            {
                new System.Threading.Thread(() =>
                {
                    // 根据配置判断是否使用全屏
                    // 光标所在屏幕

                    var bounds = Util.GetScreenBounds();

                    // 获取当前整个屏幕的截图
                    var image = GetScreen(bounds.X, bounds.Y, bounds.Width, bounds.Height);

                    screenForm.InvokeMethod(() =>
                    {
                        screenForm.Bounds = bounds;
                        screenForm.SetImage(image);
                    });
                })
                { IsBackground = true }.Start();
                screenForm.ShowWindow();
            }
            catch (Exception e)
            {
                Busy = false;
                throw e;
            }
        }

        public static bool SaveImage(Bitmap img)
        {
            saveImageDialog.FileName = string.Format("截图-{0:yyyyMMddHHmmss}", DateTime.Now);
            if (saveImageDialog.ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            img.Save(saveImageDialog.FileName);
            return true;
        }

        public static string SaveRecord()
        {
            saveRecordDialog.FileName = string.Format("录屏-{0:yyyyMMddHHmmss}", DateTime.Now);
            if (saveRecordDialog.ShowDialog() != DialogResult.OK)
            {
                return null;
            }
            return saveRecordDialog.FileName;
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
                // 根据配置判断是否使用全屏
                // 光标所在屏幕

                var bounds = Util.GetScreenBounds();
                recordForm.Left = bounds.X + bounds.Width / 2 - recordForm.Width / 2;
                recordForm.Top = bounds.Y + bounds.Height / 2 - recordForm.Height / 2;

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
