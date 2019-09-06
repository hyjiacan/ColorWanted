using System.Windows;
using System.Windows.Controls;

namespace ColorWanted.ext
{
    /// <summary>
    /// 扩展  FrameworkElement
    /// </summary>
    public static class ElementExtension
    {
        /// <summary>
        /// 设置元素在Canvas内的位置
        /// </summary>
        /// <param name="element"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        public static void SetLocation(this FrameworkElement element, double left, double top)
        {
            Canvas.SetLeft(element, left);
            Canvas.SetTop(element, top);
        }

        /// <summary>
        /// 设置元素在Canvas内的位置
        /// </summary>
        /// <param name="element"></param>
        public static void SetLocation(this FrameworkElement element, Point point)
        {
            element.SetLocation(point.X, point.Y);
        }

        /// <summary>
        /// 获取元素在Canvas内的位置
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static Point GetLocation(this FrameworkElement element)
        {
            return new Point(Canvas.GetLeft(element), Canvas.GetTop(element));
        }
    }
}
