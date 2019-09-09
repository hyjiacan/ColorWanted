using System.Drawing;
using System.Windows.Forms;

namespace ColorWanted.screenshot
{
    internal static class ScreenShot
    {
        public static readonly int SCREEN_WIDTH;
        public static readonly int SCREEN_HEIGHT;
        private static ScreenForm screenForm;

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
            var image = new Bitmap(SCREEN_WIDTH, SCREEN_HEIGHT);
            using (Graphics g = Graphics.FromImage(image))
            {
                g.CopyFromScreen(0, 0, 0, 0, new Size(SCREEN_WIDTH, SCREEN_HEIGHT));
            }
            try
            {
                screenForm.Show(image);
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
