using ColorWanted.ext;
using ColorWanted.setting;
using ColorWanted.util;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ColorWanted.screenshot
{
    internal static class ScreenShot
    {
        private static ScreenShotForm shotForm;
        private static ScreenCastForm castForm;
        private static SaveFileDialog saveImageDialog;
        private static SaveFileDialog saveCastDialog;

        /// <summary>
        /// 标记是否正在截图
        /// </summary>
        public static bool Busy { private set; get; }

        public static void Init()
        {
            shotForm = new ScreenShotForm();

            shotForm.FormClosing += (sender, e) =>
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

            saveCastDialog = new SaveFileDialog
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

            ToggleColorWindows(false);
            try
            {
                using (Graphics g = Graphics.FromImage(image))
                {
                    g.CopyFromScreen(x1, y1, 0, 0, new Size(width, height));
                }
            }
            finally
            {
                ToggleColorWindows(true);
            }
            return image;
        }

        public static void CancelCapture()
        {
            if (shotForm == null)
            {
                return;
            }
            if (!Busy)
            {
                return;
            }

            shotForm.Close();
            Busy = false;
        }

        public static void Capture()
        {
            if (shotForm == null)
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
                // 根据配置判断是否使用全屏
                // 光标所在屏幕

                var bounds = Util.GetScreenBounds();

                // 获取当前整个屏幕的截图
                var image = GetScreen(bounds.X, bounds.Y, bounds.Width, bounds.Height);

                shotForm.Bounds = bounds;
                shotForm.SetImage(image);
                shotForm.ShowWindow();
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

        public static string SaveCast()
        {
            saveCastDialog.FileName = string.Format("录屏-{0:yyyyMMddHHmmss}", DateTime.Now);
            if (saveCastDialog.ShowDialog() != DialogResult.OK)
            {
                return null;
            }
            return saveCastDialog.FileName;
        }

        /// <summary>
        /// 录制工作流程
        /// 1. 绑定快捷键 Alt+R
        /// 2. 打开录制窗口后，显示选项工具条
        /// 3. 设置好选项后，点击【开始】以开始录制
        /// 4. 点击后隐藏工具条，再次按下快捷键停止录制，并显示保存位置选择对话框
        /// 5. 选择保存文件后，合成GIF文件，关闭录制窗口
        /// </summary>
        public static void Cast()
        {
            if (Busy)
            {
                // 关闭窗口，此时会停止录制
                castForm?.Close();
                return;
            }
            Busy = true;
            try
            {
                ToggleColorWindows(false);
                castForm = new ScreenCastForm();
                castForm.FormClosing += (sender, e) =>
                {
                    ToggleColorWindows(true);
                };

                // 根据配置判断是否使用全屏
                // 光标所在屏幕

                var bounds = Util.GetScreenBounds();
                castForm.Left = bounds.X + bounds.Width / 2 - castForm.Width / 2;
                castForm.Top = bounds.Y + bounds.Height / 2 - castForm.Height / 2;

                castForm.FormClosed += CastForm_FormClosed;
                castForm.ShowDialog();
            }
            finally
            {
                Busy = false;
                if (castForm != null)
                {
                    castForm.Close();
                    castForm.Dispose();
                }
            }
        }

        private static void CastForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Directory.Exists(ScreenCastOption.CachePath) ||
                Directory.GetFiles(ScreenCastOption.CachePath).Length == 0)
            {
                return;
            }
            var f = new ScreenCastSavingForm();
            f.FormClosed += (s, e1) =>
            {
                Busy = false;
                if (Directory.Exists(ScreenCastOption.CachePath))
                {
                    Directory.Delete(ScreenCastOption.CachePath, true);
                }
            };
            f.ShowDialog();
            f.Dispose();
        }

        /// <summary>
        /// 切换主窗口和预览窗口 隐藏/显示
        /// </summary>
        private static void ToggleColorWindows(bool visible)
        {
            if (!Settings.Shoot.HideColorWindows)
            {
                return;
            }

            var mainForm = MainForm.Instance;

            if (mainForm != null && Settings.Main.Display != mode.DisplayMode.Hidden)
            {
                mainForm.InvokeMethod(() =>
                {
                    mainForm.Visible = visible;
                });
            }

            var previewForm = Application.OpenForms["PreviewForm"];
            if (previewForm != null && Settings.Preview.Visible)
            {
                previewForm.InvokeMethod(() =>
                {
                    previewForm.Visible = visible;
                });
            }

            Application.DoEvents();
        }
    }
}
