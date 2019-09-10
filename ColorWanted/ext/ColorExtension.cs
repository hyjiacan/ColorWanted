using MediaColor = System.Windows.Media.Color;
using DrawingColor = System.Drawing.Color;

namespace ColorWanted.ext
{
    /// <summary>
    /// 扩展  System.Drawing.Color 
    /// </summary>
    public static class ColorExtension
    {
        public static MediaColor ToMediaColor(this DrawingColor color)
        {
            return MediaColor.FromRgb(color.R, color.G, color.B);
        }
    }
}
