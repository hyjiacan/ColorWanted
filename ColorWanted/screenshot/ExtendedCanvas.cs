using ColorWanted.ext;
using ColorWanted.screenshot.events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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

        private bool IsMouseDown;

        public bool EditEnabled { get; set; }

        /// <summary>
        /// 是否仅用于创建选区
        /// </summary>
        public bool MakeSelectionOnly { get; set; }

        private DrawShapes drawShape;

        public DrawShapes DrawShape
        {
            get => drawShape;
            set
            {
                CommitTextInput();
                drawShape = value;
            }
        }
        public Color DrawColor { get; set; }

        public LineStyles LineStyle { get; set; }
        public int DrawWidth { get; set; }
        public System.Drawing.Font TextFont { get; set; }

        /// <summary>
        /// 当前的绘制
        /// </summary>
        private DrawRecord current;

        /// <summary>
        /// 移动
        /// </summary>
        private bool MoveMode;

        private Point MouseDownPoint;
        private TextBox TextBox;

        public void Reset()
        {
            foreach (var item in History)
            {
                Children.Remove(item.Element);
            }
            History.Clear();
            IsMouseDown = false;
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
            BindEvent();
        }

        private void EmitDrawEvent(DrawState state, bool isEmpty = false)
        {
            if (OnDraw == null)
            {
                return;
            }
            OnDraw.Invoke(this, new DrawEventArgs()
            {
                DrawType = current.Shape,
                Shape = current.Element as Shape,
                IsEmpty = isEmpty,
                Area = current.ElementRect,
                State = state
            });
        }

        private void BindEvent()
        {
            MouseLeftButtonDown += OnMouseLeftButtonDown;
            MouseLeftButtonUp += ExtendedCanvas_MouseLeaveOrUp;
            MouseLeave += ExtendedCanvas_MouseLeaveOrUp; ;
            MouseMove += OnMouseMove;
            MouseRightButtonDown += On_MouseRightButtonDown;
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
            GC.Collect();
        }

        /// <summary>
        /// 重做
        /// </summary>
        public void Redo()
        {
            throw new NotImplementedException();
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
            EmitDrawEvent(DrawState.End, true);
        }

        private void CreateTextBox()
        {
            if (TextBox == null)
            {
                TextBox = new TextBox
                {
                    AcceptsReturn = true,
                    AcceptsTab = true,
                    TextWrapping = TextWrapping.Wrap,
                    Background = Brushes.Transparent,
                    Visibility = Visibility.Hidden
                };
                TextBox.KeyDown += (sender, e) =>
                  {
                      // 在输入框内按下 ESC 时，取消输入
                      if (e.Key == System.Windows.Input.Key.Escape)
                      {
                          TextBox.Visibility = Visibility.Hidden;
                          TextBox.Clear();
                      }
                  };
                Children.Add(TextBox);
            }
            TextBox.Width = 160;
            TextBox.Height = 60;
            TextBox.FontFamily = new FontFamily(TextFont.FontFamily.Name);
            TextBox.FontSize = TextFont.SizeInPoints;
            TextBox.FontStyle = TextFont.Italic ? FontStyles.Italic : FontStyles.Normal;
            TextBox.FontWeight = TextFont.Bold ? FontWeights.Bold : FontWeights.Normal;
            TextBox.Foreground = new SolidColorBrush(DrawColor);

            current.End = new Point(current.Start.X + 160, current.Start.Y + 60);
        }

        public void CommitTextInput()
        {
            if (TextBox == null)
            {
                return;
            }
            TextBox.Visibility = Visibility.Hidden;
            var text = TextBox.Text;
            TextBox.Clear();
            if (!string.IsNullOrWhiteSpace(text))
            {
                current.Text = text;
                Draw(current);
            }
            current = MakeNewRecord();
        }

        private DrawRecord MakeNewRecord()
        {
            return new DrawRecord
            {
                Shape = DrawShape,
                Color = DrawColor,
                Width = DrawWidth,
                LineStyle = LineStyle,
                TextFont = TextFont
            };
        }

        #region 事件
        private void OnMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
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
                    AreaDoubleClicked.Invoke(this, new AreaEventArgs(current.Rect));
                    return;
                }
                MoveMode = true;
                IsMouseDown = true;
                EmitDrawEvent(DrawState.Start);
                return;
            }
            if (DrawShape == DrawShapes.Text)
            {
                if (TextBox != null && TextBox.Visibility == Visibility.Visible)
                {
                    // 已经显示起了，此时提交输入
                    CommitTextInput();
                }

                current = MakeNewRecord();

                current.Start = point;
                IsMouseDown = true;

                CreateTextBox();

                TextBox.SetLocation(point);
                TextBox.Visibility = Visibility.Visible;
                TextBox.Focus();
                return;
            }

            current = MakeNewRecord();
            current.Start = point;
            IsMouseDown = true;
            EmitDrawEvent(DrawState.Start);
        }

        private void ExtendedCanvas_MouseLeaveOrUp(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!EditEnabled || !IsMouseDown)
            {
                return;
            }
            IsMouseDown = false;
            var point = e.GetPosition(this);

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
                    current.End = e.GetPosition(this);
                }
                return;
            }
            current.End = point;
            Draw(current);
            EmitDrawEvent(DrawState.End);
        }

        private void OnMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!EditEnabled || !IsMouseDown)
            {
                return;
            }

            var point = e.GetPosition(this);
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

            current.End = point;

            if (DrawShape == DrawShapes.Text)
            {
                TextBox.Width = current.Size.Width;
                TextBox.Height = current.Size.Height;
                return;
            }
            Draw(current);
            EmitDrawEvent(DrawState.Move);
        }

        private void On_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // 取消图形
            Undo();
            EmitDrawEvent(DrawState.Cancel, true);
        }
        #endregion
    }

    public class DrawEventArgs : EventArgs
    {
        public bool IsEmpty { get; set; }
        public DrawShapes DrawType { get; set; }
        public Shape Shape { get; set; }
        public Rect Area { get; set; }
        public DrawState State { get; set; }

    }

    public enum DrawState
    {
        Start,
        Move,
        End,
        Cancel
    }
}
