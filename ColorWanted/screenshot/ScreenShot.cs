using System.Drawing;
using System.Windows.Forms;

namespace ColorWanted.screenshot
{
    internal static class ScreenShot
    {
        private static ScreenForm screenForm;
        private static int screenWidth;
        private static int screenHeight;
        private static Bitmap image;

        /// <summary>
        /// 标记是否正在截图
        /// </summary>
        public static bool Busy { private set; get; }

        static ScreenShot()
        {
            var screen = Screen.PrimaryScreen.Bounds;
            screenWidth = screen.Width;
            screenHeight = screen.Height;
        }

        public static void Capture()
        {
            Busy = true;
            screenForm = new ScreenForm();
            image = new Bitmap(screenWidth, screenHeight);
            using (Graphics g = Graphics.FromImage(image))
            {
                g.CopyFromScreen(0, 0, 0, 0, new Size(screenWidth, screenHeight));
            }
            screenForm.Show(image);
            Busy = false;
            screenForm = null;
            System.GC.Collect();
        }
    }
}
