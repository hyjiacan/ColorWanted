using ColorWanted.screenshot;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ColorWanted.ext
{
    internal static class GraphicsExtension
    {
        public static void Draw(this Graphics graphics, DrawRecord record)
        {
            var width = record.Width;
            using (var pen = new Pen(record.Color, width))
            {
                pen.StartCap = LineCap.Round;
                pen.MiterLimit = 0.1f;
                if (record.LineStyle == LineStyles.Dashed)
                {
                    pen.DashStyle = DashStyle.Dash;
                }
                else if (record.LineStyle == LineStyles.Dotted)
                {
                    pen.DashStyle = DashStyle.Dot;
                }
                switch (record.Type)
                {
                    case DrawTypes.Pen:
                        graphics.DrawCurve(pen, record.PointSet.ToArray());
                        break;
                    case DrawTypes.Circle:
                        graphics.DrawEllipse(pen, record.Start.X, record.Start.Y, record.Distance, record.Distance);
                        break;
                    case DrawTypes.Ellipse:
                        graphics.DrawEllipse(pen, record.Rect);
                        break;
                    case DrawTypes.Line:
                        graphics.DrawLine(pen, record.Start, record.End);
                        break;
                    case DrawTypes.Rectangle:
                        graphics.DrawRectangle(pen, record.Rect);
                        break;
                    case DrawTypes.Text:
                        graphics.DrawString(record.Text, record.TextFont, new SolidBrush(record.Color), record.Start);
                        break;
                    case DrawTypes.Arrow:
                        var cap = new AdjustableArrowCap(5, 5, false);
                        pen.CustomEndCap = cap;
                        graphics.DrawLine(pen, record.Start, record.End);
                        break;
                }
            }
            graphics.Flush();
            GC.Collect();
        }
    }
}
