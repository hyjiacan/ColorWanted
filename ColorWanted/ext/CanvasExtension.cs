using ColorWanted.screenshot;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ColorWanted.ext
{
    public static class CanvasExtension
    {
        public static void Draw(this Canvas canvas, DrawRecord record)
        {
            //var width = record.Width;
            //var brush = new DrawingBrush();
            //brush.colo
            //var pen = new Pen(record.Color, width)
            //{
            //    pen.StartCap = LineCap.Round;
            //    pen.MiterLimit = 0.1f;
            //    if (record.LineStyle == LineStyles.Dashed)
            //    {
            //        pen.DashStyle = DashStyle.Dash;
            //    }
            //    else if (record.LineStyle == LineStyles.Dotted)
            //    {
            //        pen.DashStyle = DashStyle.Dot;
            //    }

            //}
            //graphics.Flush();
            Shape shape = null;
            switch (record.Type)
            {
                case DrawTypes.Pen:
                    shape = new Polyline
                    {
                        Points = record.Points
                    };
                    break;
                case DrawTypes.Ellipse:
                    shape = new Ellipse
                    {
                        Width = record.Size.Width,
                        Height = record.Size.Height
                    };
                    break;
                case DrawTypes.Line:
                    shape = new Line
                    {
                        X1 = record.Start.X,
                        Y1 = record.Start.Y,
                        X2 = record.End.Y,
                        Y2 = record.End.Y
                    };
                    break;
                case DrawTypes.Rectangle:
                    shape = new Rectangle
                    {
                        Width = record.Size.Width,
                        Height = record.Size.Height
                    };
                    break;
                //case DrawTypes.Arrow:
                //    var cap = new AdjustableArrowCap(5, 5, false);
                //    pen.CustomEndCap = cap;
                //    graphics.DrawLine(pen, record.Start, record.End);
                //    break;
                case DrawTypes.Text:
                    if (string.IsNullOrWhiteSpace(record.Text))
                    {
                        return;
                    }
                    var text = new TextBlock();
                    Canvas.SetLeft(text, record.Start.X);
                    Canvas.SetTop(text, record.Start.Y);
                    canvas.Children.Add(text);
                    break;
                default:
                    return;
            }
            shape.StrokeThickness = record.Width;
            shape.Stroke = new SolidColorBrush(record.Color);

            Canvas.SetLeft(shape, record.Start.X);
            Canvas.SetTop(shape, record.Start.Y);
            canvas.Children.Add(shape);
            GC.Collect();
        }
    }
}
