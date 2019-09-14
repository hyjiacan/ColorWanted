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

        public static void Init()
        {
            screenForm = new ScreenForm();

            screenForm.FormClosing += (sender, e) =>
            {
                Busy = false;
                System.GC.Collect();
            };
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
                throw e;
            }
        }
    }
}
