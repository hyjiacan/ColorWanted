using ColorWanted.ext;
using ColorWanted.screenshot.events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ColorWanted.screenshot
{
    class ResizeBorder : IDisposable
    {
        private Canvas canvas;
        private Rectangle border;
        private Polyline nw;
        private Polyline n;
        private Polyline ne;
        private Polyline e;
        private Polyline se;
        private Polyline s;
        private Polyline sw;
        private Polyline w;

        private PolylineState currentState;
        private Dictionary<ResizePositions, PolylineState> polylineState;

        private static Color color = Colors.Black;
        private static Color activeColor = Colors.Red;

        public event EventHandler<ResizeEventArgs> Resize;

        public bool IsDisposed { get; private set; }


        class PolylineState
        {
            public Polyline Line { get; set; }
            public ResizePositions Position { get; set; }
            public bool MouseDown { get; set; }
            public Point MouseDownPosition { get; set; }
        }

        public void Dispose()
        {
            this.IsDisposed = true;

            if (this.polylineState != null)
            {
                foreach (var item in polylineState)
                {
                    this.canvas.Children.Remove(item.Value.Line);
                }
                this.polylineState.Clear();
                this.polylineState = null;
            }

            this.canvas = null;
            this.border = null;
            this.nw = null;
            this.n = null;
            this.ne = null;
            this.e = null;
            this.se = null;
            this.s = null;
            this.sw = null;
            this.w = null;
            this.currentState = null;
            this.Resize = null;
        }


        public ResizeBorder(Canvas canvas, Rectangle border)
        {
            this.canvas = canvas;
            this.border = border;

            polylineState = new Dictionary<ResizePositions, PolylineState>();

            this.nw = InitPolyline(Cursors.SizeNWSE, ResizePositions.NorthWest);
            this.n = InitPolyline(Cursors.SizeNS, ResizePositions.North);
            this.ne = InitPolyline(Cursors.SizeNESW, ResizePositions.NorthEast);
            this.e = InitPolyline(Cursors.SizeWE, ResizePositions.East);
            this.se = InitPolyline(Cursors.SizeNWSE, ResizePositions.SouthEast);
            this.s = InitPolyline(Cursors.SizeNS, ResizePositions.South);
            this.sw = InitPolyline(Cursors.SizeNESW, ResizePositions.SouthWest);
            this.w = InitPolyline(Cursors.SizeWE, ResizePositions.West);
        }

        public void UpdateState(Point newPosition)
        {
            if (currentState == null)
            {
                return;
            }
            if (!currentState.MouseDown)
            {
                return;
            }
            currentState.Line.Stroke = new SolidColorBrush(activeColor);
            var oldPosition = currentState.MouseDownPosition;
            currentState.MouseDownPosition = newPosition;
            canvas.Cursor = currentState.Line.Cursor;
            this.Resize.Invoke(currentState.Line, new ResizeEventArgs
            {
                ResizePosition = currentState.Position,
                OffsetX = newPosition.X - oldPosition.X,
                OffsetY = newPosition.Y - oldPosition.Y
            });
        }

        public void EndResize()
        {
            if (canvas != null)
            {
                canvas.Cursor = Cursors.Arrow;
            }
            if (currentState == null)
            {
                return;
            }
            currentState.Line.Stroke = new SolidColorBrush(color);
            currentState.MouseDown = false;
        }

        public void Hide()
        {
            foreach (var item in polylineState)
            {
                item.Value.Line.Visibility = Visibility.Hidden;
            }
        }

        public void Show()
        {
            foreach (var item in polylineState)
            {
                item.Value.Line.Visibility = Visibility.Visible;
            }
        }

        private Polyline InitPolyline(Cursor cursor, ResizePositions resizePosition)
        {
            var line = new Polyline
            {
                StrokeThickness = 2,
                Stroke = new SolidColorBrush(color),
                Cursor = cursor
            };

            polylineState.Add(resizePosition, new PolylineState()
            {
                Line = line,
                Position = resizePosition
            });

            line.MouseDown += (sender, e) =>
            {
                currentState = polylineState[resizePosition];
                currentState.MouseDown = true;
                currentState.MouseDownPosition = e.GetPosition(canvas);
                currentState.Line.Stroke = new SolidColorBrush(activeColor);
            };

            line.MouseEnter += (sender, e) =>
            {
                line.Stroke = new SolidColorBrush(activeColor);
            };

            line.MouseLeave += (sender, e) =>
            {
                line.Stroke = new SolidColorBrush(color);
            };

            line.MouseUp += (sender, e) =>
            {
                if (!polylineState[resizePosition].MouseDown)
                {
                    return;
                }
                polylineState[resizePosition].MouseDown = false;
            };

            //line.MouseMove += (sender, e) =>
            //{
            //    this.UpdateState(e.GetPosition(canvas));
            //};

            canvas.Children.Add(line);

            return line;
        }

        public void FixPosition()
        {
            if (this.IsDisposed)
            {
                return;
            }
            var location = this.border.GetLocation();
            var size = this.border.GetSize();

            var x = location.X;
            var y = location.Y;
            var width = size.Width;
            var height = size.Height;

            // resize 最大值为 20，最小值为 3
            var factor = 0.08;
            var hLen = Math.Max(Math.Min(width * factor, 20), 3);
            var vLen = Math.Max(Math.Min(height * factor, 20), 3);

            nw.Points = new PointCollection {
                new Point(x, y + vLen),
                new Point(x, y),
                new Point(x  +hLen, y),
            };

            n.Points = new PointCollection
            {
                new Point(x  + width / 2 -hLen / 2, y),
                new Point(location.X  + width / 2 + hLen, y),
            };

            ne.Points = new PointCollection {
                new Point(x + width - hLen, y),
                new Point(x + width, y),
                new Point(x + width, y + vLen),
            };

            e.Points = new PointCollection
            {
                new Point(x  + width, y + height / 2 - vLen / 2),
                new Point(x  + width, y + height / 2  + vLen),
            };

            se.Points = new PointCollection {
                new Point(x + width, y + height - vLen),
                new Point(x + width, y + height),
                new Point(x + width - hLen, y + height),
            };

            s.Points = new PointCollection
            {
                new Point(x  + width / 2 - hLen/ 2, y + height),
                new Point(x  + width / 2 + hLen, y + height),
            };

            sw.Points = new PointCollection {
                new Point(x, y + height - vLen),
                new Point(x, y + height),
                new Point(x + hLen, y + height),
            };

            w.Points = new PointCollection
            {
                new Point(x, y + height / 2 - vLen / 2),
                new Point(x, y + height / 2  + vLen),
            };
        }
    }
}
