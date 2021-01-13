using ColorWanted.screenshot;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace ColorWanted.ext
{
    public static class GraphicsExtension
    {
        public static void Draw(this Graphics graphics, DrawRecord record)
        {
            var width = record.Width;
            var brush = new SolidBrush(record.Color.ToDrawingColor());
            var pen = new Pen(brush, width);
            //pen.StartCap = LineCap.Square;
            //pen.MiterLimit = 0.1f;
            if (record.LineStyle == LineStyles.Dashed)
            {
                pen.DashStyle = DashStyle.Dash;
            }
            else if (record.LineStyle == LineStyles.Dotted)
            {
                pen.DashStyle = DashStyle.Dot;
            }
            switch (record.Shape)
            {
                case DrawShapes.Curve:
                    //pen.EndCap = LineCap.Square;
                    graphics.DrawCurve(pen, record.Points.Select(p => new Point((int)p.X, (int)p.Y)).ToArray());
                    break;
                case DrawShapes.Ellipse:
                    if (record.Mode == DrawModes.Stroke)
                    {
                        graphics.DrawEllipse(pen, record.Rect.ToDrawingRectangle());
                    }
                    else if (record.Mode == DrawModes.Fill)
                    {
                        graphics.FillEllipse(brush, record.Rect.ToDrawingRectangle());
                    }
                    break;
                case DrawShapes.Line:
                    //pen.EndCap = LineCap.Square;
                    graphics.DrawLine(pen, record.Start.ToDrawingPoint(), record.End.ToDrawingPoint());
                    break;
                case DrawShapes.Rectangle:
                    if (record.Mode == DrawModes.Stroke)
                    {
                        graphics.DrawRectangle(pen, record.Rect.ToDrawingRectangle());
                    }
                    else if (record.Mode == DrawModes.Fill)
                    {
                        graphics.FillRectangle(brush, record.Rect.ToDrawingRectangle());
                    }
                    break;
                case DrawShapes.Polygon:
                    if (record.Mode == DrawModes.Stroke)
                    {
                        graphics.DrawPolygon(pen, record.Points.Take(record.Points.Count - 1).Select(p => p.ToDrawingPoint()).ToArray());
                    }
                    else if (record.Mode == DrawModes.Fill)
                    {
                        graphics.FillPolygon(brush, record.Points.Take(record.Points.Count - 1).Select(p => p.ToDrawingPoint()).ToArray());
                    }
                    break;
                case DrawShapes.Text:
                    if (string.IsNullOrWhiteSpace(record.Text))
                    {
                        return;
                    }
                    graphics.DrawString(record.Text, record.TextFont,
                        new SolidBrush(record.Color.ToDrawingColor()), record.Start.ToDrawingPoint());
                    break;
                case DrawShapes.Arrow:
                    int arrowSize;
                    switch (record.Distance)
                    {
                        case 5:
                        case 4:
                            arrowSize = 2;
                            break;
                        case 3:
                        case 2:
                        case 1:
                            arrowSize = 1;
                            break;
                        default:
                            arrowSize = 5;
                            break;
                    }
                    var cap = new AdjustableArrowCap(arrowSize, arrowSize, false);
                    pen.CustomEndCap = cap;
                    graphics.DrawLine(pen, record.Start.ToDrawingPoint(), record.End.ToDrawingPoint());
                    break;
            }
            pen.Dispose();
            brush.Dispose();
            graphics.Flush();
            GC.Collect();
        }
    }
}
