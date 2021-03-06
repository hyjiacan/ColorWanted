﻿using ColorWanted.ext;
using ColorWanted.screenshot.events;
using ColorWanted.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ColorWanted.screenshot
{
    /// <summary>
    /// 扩展的 Canvas 组件
    /// </summary>
    public class ExtendedCanvas : Canvas
    {
        public Stack<DrawHistoryItem> History { get; private set; }
        public Stack<DrawHistoryItem> RedoHistory { get; private set; }

        private bool IsMouseLeftButtonDown;

        public bool EditEnabled { get; set; }

        /// <summary>
        /// 是否仅用于创建选区
        /// </summary>
        public bool MakeSelectionOnly { get; set; }

        private DrawShapes drawShape;
        public DrawModes DrawMode { get; set; }
        public DrawShapes DrawShape
        {
            get => drawShape;
            set
            {
                CommitTextInput();
                drawShape = value;
                // 如果多边形还没有画完，那么就重置
                if (current != null && current.Shape == DrawShapes.Polygon && !current.PolygonClosed)
                {
                    current.Reset();
                }
            }
        }
        public Color DrawColor { get; set; }

        public LineStyles LineStyle { get; set; }
        public int DrawWidth { get; set; }
        public System.Drawing.Font TextFont { get; set; }
        public event EventHandler<HistoryEventArgs> HistoryChange;

        /// <summary>
        /// 当前的绘制
        /// </summary>
        private DrawRecord current;

        /// <summary>
        /// 移动
        /// </summary>
        private bool MoveMode;

        private Point MouseDownPoint;
        private TextBox Textbox;
        private Ellipse polygonPoint;

        public void Reset()
        {
            foreach (var item in History)
            {
                Children.Remove(item.Element);
            }
            History.Clear();
            RedoHistory.Clear();
            IsMouseLeftButtonDown = false;
            current = null;
            MoveMode = false;
        }

        /// <summary>
        /// 绘图事件
        /// </summary>
        public event EventHandler<DrawEventArgs> OnDraw;

        /// <summary>
        /// 选区被双击时的事件
        /// </summary>
        public event EventHandler<AreaEventArgs> AreaDoubleClicked;

        public ExtendedCanvas()
        {
            History = new Stack<DrawHistoryItem>();
            RedoHistory = new Stack<DrawHistoryItem>();
            DrawMode = DrawModes.Stroke;
            BindEvent();
        }

        private void EmitDrawEvent(DrawState state, bool isEmpty = false)
        {
            if (OnDraw == null)
            {
                return;
            }
            if (current == null)
            {
                return;
            }
            OnDraw.Invoke(this, new DrawEventArgs()
            {
                DrawType = current.Shape,
                Shape = current.Element as Shape,
                IsEmpty = isEmpty,
                Area = current.ElementRect,
                State = state,
                LeftButtonPressed = IsMouseLeftButtonDown
            });
        }

        private void BindEvent()
        {
            MouseLeftButtonDown += OnMouseLeftButtonDown;
            MouseRightButtonDown += ExtendedCanvas_MouseRightButtonDown;
            MouseLeftButtonUp += ExtendedCanvas_MouseUp;
            MouseLeave += ExtendedCanvas_MouseLeave;
            MouseMove += OnMouseMove;
        }

        /// <summary>
        /// 绘制图形
        /// </summary>
        /// <param name="record"></param>
        public void Draw(DrawRecord record)
        {
            var element = record.GetElement();
            if (element == null)
            {
                return;
            }
            if (History.Any(item => item.Element.Equals(element)))
            {
                return;
            }
            Children.Add(element);
            History.Push(new DrawHistoryItem
            {
                Element = element,
                Record = record
            });
            RedoHistory.Clear();
            HistoryChange?.Invoke(this, new HistoryEventArgs(History.Count, RedoHistory.Count));
            GC.Collect();
        }

        /// <summary>
        /// 重做
        /// </summary>
        public void Redo()
        {
            if (RedoHistory.Count == 0)
            {
                return;
            }
            var element = RedoHistory.Pop();
            Children.Add(element.Element);
            History.Push(element);
            EmitDrawEvent(DrawState.End, true);

            HistoryChange?.Invoke(this, new HistoryEventArgs(History.Count, RedoHistory.Count));
        }

        /// <summary>
        /// 撤消
        /// </summary>
        public void Undo()
        {
            if (History.Count == 0)
            {
                return;
            }
            var element = History.Pop();
            Children.Remove(element.Element);
            RedoHistory.Push(element);
            EmitDrawEvent(DrawState.End, true);

            HistoryChange?.Invoke(this, new HistoryEventArgs(History.Count, RedoHistory.Count));
        }

        private void CreateTextBox()
        {
            if (Textbox == null)
            {
                Textbox = new TextBox
                {
                    AcceptsReturn = true,
                    AcceptsTab = true,
                    TextWrapping = TextWrapping.Wrap,
                    Background = new SolidColorBrush(Color.FromArgb(20, 255, 255, 255)),
                    Visibility = Visibility.Hidden,
                    BorderThickness = new Thickness(2),
                    Padding = new Thickness(5),
                    ToolTip = "提示\n按下 ESC 取消编辑\n按下 Ctrl Enter 完成编辑"
                };
                Textbox.KeyDown += (sender, e) =>
                  {
                      // 在输入框内按下 ESC 时，取消输入
                      if (e.Key == Key.Escape)
                      {
                          Textbox.Visibility = Visibility.Hidden;
                          Textbox.Clear();
                          e.Handled = true;
                          return;
                      }

                      if (e.Key == Key.Enter && (
                      e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) ||
                      e.KeyboardDevice.IsKeyDown(Key.RightCtrl)))
                      {
                          CommitTextInput();
                          e.Handled = true;
                      }
                  };
                Children.Add(Textbox);
            }
            Textbox.Width = 0;
            Textbox.Height = 0;
            Textbox.FontFamily = new FontFamily(TextFont.FontFamily.Name);
            Textbox.FontSize = TextFont.SizeInPoints;
            Textbox.FontStyle = TextFont.Italic ? FontStyles.Italic : FontStyles.Normal;
            Textbox.FontWeight = TextFont.Bold ? FontWeights.Bold : FontWeights.Normal;

            var brush = new SolidColorBrush(DrawColor);

            Textbox.Foreground = brush;
            Textbox.BorderBrush = brush;
            Textbox.CaretBrush = brush;
        }

        public void CommitTextInput()
        {
            Keyboard.ClearFocus();
            if (Textbox == null)
            {
                return;
            }
            Textbox.Visibility = Visibility.Hidden;
            var text = Textbox.Text;
            Textbox.Clear();
            if (!string.IsNullOrWhiteSpace(text))
            {
                current.Text = text;
                Draw(current);
            }
            current = MakeNewRecord();
        }

        public void UpdateCurrent(Point location, Size size)
        {
            if (current == null)
            {
                return;
            }
            current.Points[0] = location;
            current.Points[current.Points.Count - 1] = new Point(location.X + size.Width, location.Y + size.Height);
            current.GetElement();
        }

        private DrawRecord MakeNewRecord()
        {
            return new DrawRecord
            {
                Shape = DrawShape,
                Color = DrawColor,
                Width = DrawWidth,
                LineStyle = LineStyle,
                TextFont = TextFont,
                Mode = DrawMode
            };
        }

        #region 事件
        private void OnMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (polygonPoint != null)
            {
                this.Children.Remove(polygonPoint);
                polygonPoint = null;
            }
            if (!EditEnabled)
            {
                return;
            }
            var point = e.GetPosition(this);
            MouseDownPoint = point;
            if (current != null && MakeSelectionOnly && History.Count > 0)
            {
                // 不在框内按下鼠标，不处理拖动
                if (!current.ElementRect.Contains(point))
                {
                    return;
                }
                if (e.ClickCount == 2)
                {
                    // 双击图形，触发双击事件
                    AreaDoubleClicked.Invoke(this, new AreaEventArgs(current.ElementRect));
                    return;
                }
                MoveMode = true;
                IsMouseLeftButtonDown = true;
                EmitDrawEvent(DrawState.Start);
                return;
            }
            if (DrawShape == DrawShapes.Text)
            {
                if (Textbox != null && Textbox.Visibility == Visibility.Visible)
                {
                    // 已经显示起了，此时提交输入
                    CommitTextInput();
                }

                current = MakeNewRecord();
                current.SetStart(point);
                IsMouseLeftButtonDown = true;

                CreateTextBox();

                Textbox.SetLocation(point);
                Textbox.Visibility = Visibility.Visible;
                return;
            }
            if (drawShape == DrawShapes.Polygon && current != null && current.Points.Any())
            {
                if (current.Points.Count > 3 && current.Distance < 3)
                {
                    // 起点和终点距离小于3时，自动关闭图形
                    current.IsPolygonEditing = false;
                    current.SetEnd(new Point(current.Start.X, current.Start.Y));

                    Draw(current);
                    EmitDrawEvent(DrawState.End);
                    current = null;
                    return;
                }
                // 追加点
                current.AppendPoint(point);
            }
            else
            {
                current = MakeNewRecord();
                current.SetStart(point);
                if (drawShape == DrawShapes.Polygon)
                {
                    current.IsPolygonEditing = true;
                }
            }
            IsMouseLeftButtonDown = true;
            EmitDrawEvent(DrawState.Start);
        }

        private void ExtendedCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            current?.Reset();
        }

        public void ExtendedCanvas_MouseUp(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if ((DrawShape != DrawShapes.Polygon || current == null || current.PolygonClosed) && (!EditEnabled || !IsMouseLeftButtonDown))
            {
                return;
            }
            IsMouseLeftButtonDown = false;
            var point = FixPoint(e.GetPosition(this));
            if (MoveMode)
            {
                current.Move(this, MouseDownPoint, point);
                MoveMode = false;
                EmitDrawEvent(DrawState.End);
                return;
            }
            if (DrawShape == DrawShapes.Text)
            {
                if (MouseDownPoint != point)
                {
                    current.AppendPoint(point);
                    Textbox.SetLocation(current.Rect.Location);
                    Textbox.Width = current.Size.Width;
                    Textbox.Height = current.Size.Height;
                }
                Textbox.Focus();
                return;
            }
            if (current.Points.Count > 1)
            {
                current.SetEnd(point);
                Draw(current);
                EmitDrawEvent(DrawState.End);
            }
            else
            {
                current.Reset();
                EmitDrawEvent(DrawState.Cancel);
            }
            if (!MakeSelectionOnly && drawShape != DrawShapes.Polygon)
            {
                current = MakeNewRecord();
            }
        }

        private void ExtendedCanvas_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if ((DrawShape != DrawShapes.Polygon || current == null || current.PolygonClosed) && (!EditEnabled || !IsMouseLeftButtonDown))
            {
                return;
            }
            var point = FixPoint(e.GetPosition(this));
            if (MoveMode)
            {
                current.Move(this, MouseDownPoint, point);
                MoveMode = false;
                EmitDrawEvent(DrawState.End);
                return;
            }
            if (DrawShape == DrawShapes.Text)
            {
                if (MouseDownPoint != point)
                {
                    current.AppendPoint(point);
                    Textbox.SetLocation(current.Rect.Location);
                    Textbox.Width = current.Size.Width;
                    Textbox.Height = current.Size.Height;
                }
                Textbox.Focus();
                return;
            }
            if (current.Points.Count > 1)
            {
                current.SetEnd(point);
                Draw(current);
                EmitDrawEvent(DrawState.End);
            }
            else
            {
                current.Reset();
                EmitDrawEvent(DrawState.Cancel);
            }
            if (!MakeSelectionOnly && drawShape != DrawShapes.Polygon)
            {
                current = MakeNewRecord();
            }
        }

        public void OnMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if ((DrawShape != DrawShapes.Polygon || current == null || current.PolygonClosed) &&
                (!EditEnabled || !IsMouseLeftButtonDown))
            {
                return;
            }

            if (MakeSelectionOnly && e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }

            var point = FixPoint(e.GetPosition(this));
            if (MouseDownPoint == point)
            {
                return;
            }
            if (MoveMode)
            {
                current.Move(this, MouseDownPoint, point);
                EmitDrawEvent(DrawState.Move);
                MouseDownPoint = point;
                return;
            }


            if (DrawShape == DrawShapes.Text)
            {
                current.AppendPoint(point);
                Textbox.SetLocation(current.Rect.Location);
                Textbox.Width = current.Size.Width;
                Textbox.Height = current.Size.Height;
                return;
            }

            if (DrawShape == DrawShapes.Polygon)
            {
                current.SetEnd(point);

                if (current.Points.Count > 3 && current.Distance < 3)
                {
                    // 高亮起点
                    if (polygonPoint == null)
                    {
                        polygonPoint = new Ellipse
                        {
                            StrokeThickness = 1,
                            Fill = new SolidColorBrush(DrawColor),
                            Stroke = new SolidColorBrush(ColorUtil.GetContrastColor(DrawColor.ToDrawingColor()).ToMediaColor()),
                            ToolTip = "点击此处完成多边形编辑"
                        };
                        polygonPoint.SetSize(new Size(10, 10));
                        polygonPoint.SetLocation(new Point(current.Start.X - 5, current.Start.Y - 5));
                        this.Children.Add(polygonPoint);
                    }
                }
                else
                {
                    if (polygonPoint != null)
                    {
                        this.Children.Remove(polygonPoint);
                        polygonPoint = null;
                    }
                }
            }
            else
            {
                current.AppendPoint(point);
            }
            Draw(current);
            EmitDrawEvent(DrawState.Move);
        }
        #endregion

        /// <summary>
        /// 如果按下了 Shift 键，那么结束点为距离较大的边
        /// 用于画出正方形/正圆/水平线/垂直线
        /// </summary>
        /// <param name="point"></param>
        private Point FixPoint(Point point)
        {
            FixPointBoundary(ref point);

            if (!Glob.IsShiftKeyDown)
            {
                return point;
            }

            if (current.Shape == DrawShapes.Curve || current.Shape == DrawShapes.Text)
            {
                return point;
            }

            var offsetX = point.X - current.Start.X;
            var offsetY = point.Y - current.Start.Y;

            if (offsetX == offsetY)
            {
                return point;
            }

            double newX, newY;
            if (Math.Abs(offsetX) > Math.Abs(offsetY))
            {
                newX = current.Start.X + offsetX;
                newY = current.Start.Y + offsetX;
                switch (current.Shape)
                {
                    case DrawShapes.Arrow:
                    case DrawShapes.Line:
                        return new Point(newX, current.Start.Y);
                    case DrawShapes.Rectangle:
                    case DrawShapes.Ellipse:
                        FixBoudary2(ref newX, ref newY);
                        return new Point(newX, newY);
                }
            }
            else
            {
                newX = current.Start.X + offsetY;
                newY = current.Start.Y + offsetY;
                FixBoudary2(ref newX, ref newY);
                switch (current.Shape)
                {
                    case DrawShapes.Arrow:
                    case DrawShapes.Line:
                        return new Point(current.Start.X, newY);
                    case DrawShapes.Rectangle:
                    case DrawShapes.Ellipse:
                        FixBoudary2(ref newX, ref newY);
                        return new Point(newX, newY);
                }
            }
            return point;
        }

        private void FixPointBoundary(ref Point point)
        {
            // 保证线不会画出界
            if (point.X < 0)
            {
                point.X = 0;
            }
            else if (point.X > Width)
            {
                point.X = Width;
            }
            if (point.Y < 0)
            {
                point.Y = 0;
            }
            else if (point.Y > Height)
            {
                point.Y = Height;
            }
        }

        private void FixBoudary2(ref double newX, ref double newY)
        {
            if (newX > Width)
            {
                newX = Width;
                newY = current.Start.Y + newX - current.Start.X;
            }
            else if (newX < 0)
            {
                newX = 0;
                newY = current.Start.Y + newX - current.Start.X;
            }
            if (newY > Height)
            {
                newY = Height;
                newX = current.Start.X + newY - current.Start.Y;
            }
            else if (newY < 0)
            {
                newY = 0;
                newX = current.Start.X + newY - current.Start.Y;
            }
        }
    }

    public class DrawEventArgs : EventArgs
    {
        public bool IsEmpty { get; set; }
        public DrawShapes DrawType { get; set; }
        public Shape Shape { get; set; }
        public Rect Area { get; set; }
        public DrawState State { get; set; }
        public bool LeftButtonPressed { get; set; }
    }

    public enum DrawState
    {
        Start,
        Move,
        End,
        Cancel
    }
}
