using ColorWanted.screenshot;
using System;
using System.Drawing;

namespace ColorWanted.ext
{
    internal static class GraphicsExtension
    {
        public static void Draw(this Graphics graphics, DrawRecord record)
        {
            var width = record.Width;
            var pen = new Pen(record.Color, width);
            switch (record.Type)
            {
                case DrawType.Circle:
                    break;
                case DrawType.Ellipse:
                    break;
                case DrawType.Line:
                    graphics.DrawLine(pen, record.Start, record.End);
                    break;
                case DrawType.Rectangle:
                    graphics.DrawRectangle(pen, record.Rect);
                    break;
                case DrawType.Text:
                    graphics.DrawString(record.Text, SystemFonts.DefaultFont, new SolidBrush(record.Color), record.Start);
                    break;
            }
            GC.Collect();
        }
    }
}
