using System.Windows.Forms;

namespace ColorWanted.ext
{
    internal static class PictureBoxExtension
    {
        /// <summary>
        /// 启用控件的双缓冲支持
        /// </summary>
        /// <param name="pictureBox"></param>
        public static void EnableDoubleBuffered(this PictureBox pictureBox)
        {
            pictureBox.GetType().GetProperty("DoubleBuffered",
              System.Reflection.BindingFlags.Instance |
              System.Reflection.BindingFlags.NonPublic)
            .SetValue(pictureBox, true, null);
        }
    }
}
