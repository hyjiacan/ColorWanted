using System.Drawing;

namespace ColorWanted.screenshot
{
    internal static class ScreenShot
    {
        public static readonly int SCREEN_WIDTH;
        public static readonly int SCREEN_HEIGHT;
        private static ScreenshotWindow screenshotWindow;

        /// <summary>
        /// 标记是否正在截图
        /// </summary>
        public static bool Busy { private set; get; }

        static ScreenShot()
        {
            SCREEN_WIDTH = (int)System.Windows.SystemParameters.PrimaryScreenWidth;
            SCREEN_HEIGHT = (int)System.Windows.SystemParameters.PrimaryScreenHeight;
        }

        public static void Capture()
        {
            Busy = true;
            if (screenshotWindow != null)
            {
                screenshotWindow = null;
            }
            screenshotWindow = new ScreenshotWindow();
            screenshotWindow.Closed += (sender, e) =>
            {
                Busy = false;
                screenshotWindow = null;
                System.GC.Collect();
            };
            var image = new Bitmap(SCREEN_WIDTH, SCREEN_HEIGHT);
            using (Graphics g = Graphics.FromImage(image))
            {
                g.CopyFromScreen(0, 0, 0, 0, new Size(SCREEN_WIDTH, SCREEN_HEIGHT));
            }
            try
            {
                screenshotWindow.Show(image, SCREEN_WIDTH, SCREEN_HEIGHT);
            }
            catch (System.Exception e)
            {
                Busy = false;
                if (screenshotWindow != null)
                {
                    screenshotWindow.Close();
                }
                throw e;
            }
        }
    }
}
