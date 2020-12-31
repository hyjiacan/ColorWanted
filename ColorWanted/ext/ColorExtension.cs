using MediaColor = System.Windows.Media.Color;
using DrawingColor = System.Drawing.Color;

namespace ColorWanted.ext
{
    /// <summary>
    /// 扩展  Color 
    /// </summary>
    public static class ColorExtension
    {
        /// <summary>
        /// 将颜色从 DrawingColor 转换到 MediaColor
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static MediaColor ToMediaColor(this DrawingColor color)
        {
            return MediaColor.FromArgb(color.A, color.R, color.G, color.B);
        }

        /// <summary>
        /// 将颜色从 MediaColor 转换到 DrawingColor
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static DrawingColor ToDrawingColor(this MediaColor color)
        {
            return DrawingColor.FromArgb(color.A, color.R, color.G, color.B);
        }
    }
}
