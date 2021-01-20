using WpfPoint = System.Windows.Point;
using DrawingPoint = System.Drawing.Point;
using System;

namespace ColorWanted.ext
{
    /// <summary>
    /// 扩展  Point
    /// </summary>
    public static class PointExtension
    {
        /// <summary>
        /// 将颜色从 DrawingPoint 转换到 WpfPoint
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static WpfPoint ToWpfPoint(this DrawingPoint point)
        {
            return new WpfPoint(point.X, point.Y);
        }

        /// <summary>
        /// 将颜色从 WpfPoint 转换到 DrawingPoint
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static DrawingPoint ToDrawingPoint(this WpfPoint point)
        {
            return new DrawingPoint((int)point.X, (int)point.Y);
        }

        /// <summary>
        /// 计算两个 WPF Point 间的绝对距离
        /// </summary>
        /// <param name="point"></param>
        /// <param name="another"></param>
        /// <returns></returns>
        public static int DistanceTo(this WpfPoint point, WpfPoint another)
        {
            return (int)Math.Sqrt((Math.Abs(point.X - another.X) * Math.Abs(point.X - another.X))
                + Math.Abs(point.Y - another.Y) * Math.Abs(point.Y - another.Y));
        }
    }
}
