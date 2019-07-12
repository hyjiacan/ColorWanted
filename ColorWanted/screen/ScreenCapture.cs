using System.Drawing;
using System.Windows.Forms;

namespace ColorWanted.screen
{
    internal static class ScreenCapture
    {
        private static ScreenForm screenForm;
        private static int screenWidth;
        private static int screenHeight;
        private static Bitmap image;

        static ScreenCapture()
        {
            var screen = Screen.PrimaryScreen.Bounds;
            screenWidth = screen.Width;
            screenHeight = screen.Height;
        }

        public static void Capture()
        {
            if (screenForm == null)
            {
                screenForm = new ScreenForm();
            }
            if (image == null)
            {
                image = new Bitmap(screenWidth, screenHeight);
            }
            using (Graphics g = Graphics.FromImage(image))
            {
                g.CopyFromScreen(0, 0, 0, 0, new Size(screenWidth, screenHeight));
            }
            screenForm.Show(image);
        }
    }
}
