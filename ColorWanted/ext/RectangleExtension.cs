using WpfRectangle = System.Windows.Rect;
using DrawingRectangle = System.Drawing.Rectangle;

namespace ColorWanted.ext
{
    /// <summary>
    /// 扩展  Rectangle
    /// </summary>
    public static class RectangleExtension
    {
        /// <summary>
        /// 将颜色从 DrawingRectangle 转换到 WpfRectangle
        /// </summary>
        /// <param name="Rectangle"></param>
        /// <returns></returns>
        public static WpfRectangle ToWpfRectangle(this DrawingRectangle Rectangle)
        {
            return new WpfRectangle(Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
        }

        /// <summary>
        /// 将颜色从 WpfRectangle 转换到 DrawingRectangle
        /// </summary>
        /// <param name="Rectangle"></param>
        /// <returns></returns>
        public static DrawingRectangle ToDrawingRectangle(this WpfRectangle Rectangle)
        {
            return new DrawingRectangle((int)Rectangle.X, (int)Rectangle.Y, (int)Rectangle.Width, (int)Rectangle.Height);
        }
    }
}
