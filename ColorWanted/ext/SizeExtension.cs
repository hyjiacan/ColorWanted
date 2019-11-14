using WpfSize = System.Windows.Size;
using DrawingSize = System.Drawing.Size;

namespace ColorWanted.ext
{
    /// <summary>
    /// 扩展  Size
    /// </summary>
    public static class SizeExtension
    {
        /// <summary>
        /// 将颜色从 DrawingSize 转换到 WpfSize
        /// </summary>
        /// <param name="Size"></param>
        /// <returns></returns>
        public static WpfSize ToWpfSize(this DrawingSize size)
        {
            return new WpfSize(size.Width, size.Height);
        }

        /// <summary>
        /// 将颜色从 WpfSize 转换到 DrawingSize
        /// </summary>
        /// <param name="Size"></param>
        /// <returns></returns>
        public static DrawingSize ToDrawingSize(this WpfSize size)
        {
            return new DrawingSize((int)size.Width, (int)size.Height);
        }
    }
}
