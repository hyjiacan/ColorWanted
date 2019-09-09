using ColorWanted.ext;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ColorWanted.screenshot
{
    public class DrawRecord
    {
        public Guid Id { get; private set; }
        /// <summary>
        /// 绘制类型
        /// </summary>
        public DrawShapes Shape { get; set; }

        /// <summary>
        /// 起点坐标
        /// </summary>
        public Point Start
        {
            get
            {
                return Points.FirstOrDefault();
            }
            set
            {
                Points.Clear();
                Points.Add(value);
            }
        }

        /// <summary>
        /// 终点坐标
        /// </summary>
        public Point End
        {
            get
            {
                return Points.Count > 1 ? Points.Last() : new Point();
            }
            set
            {
                Points.Add(value);
                GetElement();
            }
        }

        /// <summary>
        /// 当 Type 为 Text ，输入的文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 绘制颜色
        /// </summary>
        public Color Color { get; set; }
        /// <summary>
        /// 线样式
        /// </summary>
        public LineStyles LineStyle { get; set; }
        /// <summary>
        /// 绘制线宽
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 文字样式
        /// </summary>
        public System.Drawing.Font TextFont { get; set; }
        /// <summary>
        /// 鼠标移动的点集合
        /// </summary>
        public PointCollection Points { get; set; }
        /// <summary>
        /// 是否偏移(起点终点是否相同)
        /// </summary>
        public bool HasOffset => Start != End || (Shape == DrawShapes.Curve && Points.Any());

        /// <summary>
        /// 区域大小
        /// </summary>
        public Size Size
        {
            get
            {
                var size = new Size();
                if (Points.Count > 1)
                {
                    size.Width = Math.Abs(End.X - Start.X);
                    size.Height = Math.Abs(End.Y - Start.Y);
                }

                return size;
            }
        }

        public Rect Rect
        {
            get
            {
                var size = Size;
                return new Rect(Math.Min(Start.X, End.X),
                    Math.Min(Start.Y, End.Y), size.Width, size.Height);
            }
        }

        private Shape shape;
        private TextBlock textBlock;

        /// <summary>
        /// 获取绘制的图形/文本控件
        /// </summary>
        /// <returns></returns>
        public FrameworkElement GetElement()
        {
            switch (Shape)
            {
                case DrawShapes.Curve:
                    if (shape == null)
                    {
                        shape = new Polyline();
                    }
                    ((Polyline)shape).Points = Points;
                    shape.SetLocation(Start);
                    break;
                case DrawShapes.Ellipse:
                    if (shape == null)
                    {
                        shape = new Ellipse();
                    }

                    shape.Width = Size.Width;
                    shape.Height = Size.Height;
                    shape.SetLocation(Rect.X, Rect.Y);
                    break;
                case DrawShapes.Line:
                    if (shape == null)
                    {
                        shape = new Line();
                    }
                    var l = (Line)shape;
                    l.X1 = Start.X;
                    l.Y1 = Start.Y;
                    l.X2 = End.Y;
                    l.Y2 = End.Y;
                    shape.SetLocation(Start);
                    break;
                case DrawShapes.Rectangle:
                    if (shape == null)
                    {
                        shape = new Rectangle();
                    }
                    shape.Width = Size.Width;
                    shape.Height = Size.Height;
                    shape.SetLocation(Rect.X, Rect.Y);
                    break;
                //case DrawShapes.Arrow:
                //    var cap = new AdjustableArrowCap(5, 5, false);
                //    pen.CustomEndCap = cap;
                //    graphics.DrawLine(pen, Start, End);
                //    break;
                case DrawShapes.Text:
                    if (string.IsNullOrWhiteSpace(Text))
                    {
                        return null;
                    }
                    if (textBlock == null)
                    {
                        textBlock = new TextBlock();
                    }
                    textBlock.Text = Text;
                    shape.SetLocation(Start);
                    // TODO 设置文本样式
                    GC.Collect();
                    return textBlock;
                default:
                    return null;
            }
            shape.StrokeThickness = Width;
            shape.Stroke = new SolidColorBrush(Color);
            return shape;
        }

        public FrameworkElement Element
        {
            get
            {
                FrameworkElement element = null;
                if (shape != null)
                {
                    element = shape;
                }
                else if (textBlock != null)
                {
                    element = textBlock;
                }
                return element;
            }
        }

        public void Move(Point from, Point to)
        {
            var offset = to - from;

            FrameworkElement element = Element;
            if (element == null)
            {
                return;
            }

            var l = Canvas.GetLeft(shape) + offset.X;
            var t = Canvas.GetTop(shape) + offset.Y;

            // 边界限制
            if (l < 0)
            {
                l = 0;
            }
            if (t < 0)
            {
                t = 0;
            }
            var maxAllowWidth = ScreenShot.SCREEN_WIDTH - element.Width;
            if (l > maxAllowWidth)
            {
                l = maxAllowWidth;
            }
            var maxAllowHeight = ScreenShot.SCREEN_HEIGHT - element.Height;
            if (t > maxAllowHeight)
            {
                t = maxAllowHeight;
            }

            shape.SetLocation(l, t);
        }

        public Rect ElementRect
        {
            get
            {
                var element = Element;
                if (element == null)
                {
                    return Rect.Empty;
                }
                var l = Canvas.GetLeft(element);
                var t = Canvas.GetTop(element);
                var w = element.Width;
                var h = element.Height;

                return new Rect(l, t, w, h);
            }
        }

        /// <summary>
        /// 起点与终点的距离
        /// </summary>
        public int Distance => (int)Math.Sqrt(Math.Abs(Start.X - End.X) * Math.Abs(Start.X - End.X) + Math.Abs(Start.Y - End.Y) * Math.Abs(Start.Y - End.Y));

        public DrawRecord()
        {
            Id = Guid.NewGuid();
            Points = new PointCollection();
            Width = 1;
            Color = Colors.Red;
            LineStyle = LineStyles.Solid;
            TextFont = System.Drawing.SystemFonts.DefaultFont;
        }

        public static DrawRecord Make(DrawShapes type)
        {
            return new DrawRecord { Shape = type };
        }

        public void Reset()
        {
            Points.Clear();
            Text = string.Empty;
            shape = null;
            textBlock = null;
        }

        public DrawRecord Copy(int offsetStartX = 0, int offsetStartY = 0, int offsetEndX = 0, int offsetEndY = 0)
        {
            var temp = new DrawRecord
            {
                Shape = Shape,
                Color = Color,
                Width = Width,
                Points = Points.Clone()
            };

            if (temp.Points.Count > 0)
            {
                temp.Points.First().Offset(offsetStartX, offsetStartY);
            }
            if (temp.Points.Count > 1)
            {
                temp.Points.Last().Offset(offsetEndX, offsetEndY);
            }
            return temp;
        }

        public override string ToString()
        {
            return $"X={Rect.X}, Y={Rect.Y}, Width={Rect.Width}, Height={Rect.Height}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DrawRecord other))
            {
                return false;
            }
            return Id.Equals(other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
