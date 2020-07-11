using System;
using System.Collections.Generic;
using System.Drawing;

namespace ColorWanted.viewer
{
    /// <summary>
    /// 线段
    /// </summary>
    class LineSpan : IEquatable<LineSpan>
    {
        public int FromX { get; set; }
        public int FromY { get; set; }
        public int ToX { get; set; }
        public int ToY { get; set; }

        /// <summary>
        /// 方向
        /// </summary>
        public Orientions Oriention => FromX == ToX ? Orientions.Vertical : Orientions.Horizontal;

        /// <summary>
        /// 长度
        /// </summary>
        public int Length => Oriention == Orientions.Vertical ? ToY - FromY : ToX - FromX;

        /// <summary>
        /// 把线段重置为一个点
        /// </summary>
        /// <param name="point"></param>
        public void Reset(Point point)
        {
            FromX = ToX = point.X;
            FromY = ToY = point.Y;
        }

        /// <summary>
        /// 判断两条垂直线段是否相交
        /// </summary>
        /// <param name="span"></param>
        /// <returns></returns>
        public bool Intersect(LineSpan span)
        {
            // 平行线
            if (span.Oriention == Oriention)
            {
                return false;
            }

            // 允许2个像素的误差
            var offset = 10;

            // 当前线是水平的
            if (Oriention == Orientions.Horizontal)
            {
                // 另一条线是垂直的

                // 如果当前线的y在另条线内，另条线的x在当前线内
                // 那么这两条线就相交的
                return FromY >= span.FromY - offset && FromY <= span.ToY + offset &&
                    span.FromX >= FromX - offset && span.FromX <= ToX + offset;
            }

            // 如果当前线的x在另条线内，另条线的y在当前线内
            // 那么这两条线就相交的
            return FromX >= span.FromX - offset && FromX <= span.ToX + offset &&
                span.FromY >= FromY - offset && span.FromY <= ToY + offset;
        }

        public override bool Equals(object obj)
        {
            var that = obj as LineSpan;
            if (that == null)
            {
                return false;
            }
            return FromX == that.FromX && FromY == that.FromY && ToX == that.ToX && ToY == that.ToY;
        }

        public bool Equals(LineSpan other)
        {
            return other != null &&
                   FromX == other.FromX &&
                   FromY == other.FromY &&
                   ToX == other.ToX &&
                   ToY == other.ToY;
        }

        public override int GetHashCode()
        {
            var hashCode = -1870172418;
            hashCode = hashCode * -1521134295 + FromX.GetHashCode();
            hashCode = hashCode * -1521134295 + FromY.GetHashCode();
            hashCode = hashCode * -1521134295 + ToX.GetHashCode();
            hashCode = hashCode * -1521134295 + ToY.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(LineSpan span1, LineSpan span2)
        {
            return EqualityComparer<LineSpan>.Default.Equals(span1, span2);
        }

        public static bool operator !=(LineSpan span1, LineSpan span2)
        {
            return !(span1 == span2);
        }

        public override string ToString()
        {
            return string.Format("From=({0},{1}), To=({2},{3}),Length={4},Oriention={5}",
                FromX, FromY, ToX, ToY, Length, Oriention);
        }
    }
}
