using System.Drawing;
using System.Windows.Forms;

namespace ColorWanted.screenshot
{
    internal static class ScreenShot
    {
        private static int screenWidth;
        private static int screenHeight;
        private static ScreenForm screenForm;

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
            if (screenForm != null)
            {
                screenForm = null;
            }
            screenForm = new ScreenForm();
            screenForm.FormClosed += (sender, e) =>
            {
                Busy = false;
                screenForm = null;
                System.GC.Collect();
            };
            var image = new Bitmap(screenWidth, screenHeight);
            using (Graphics g = Graphics.FromImage(image))
            {
                g.CopyFromScreen(0, 0, 0, 0, new Size(screenWidth, screenHeight));
            }
            try
            {
                screenForm.Show(image, screenWidth, screenHeight);
            }
            catch (System.Exception e)
            {
                Busy = false;
                if (screenForm != null)
                {
                    screenForm.Close();
                }
                throw e;
            }
        }
    }
}
