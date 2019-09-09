using ColorWanted.screenshot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ColorWanted.ext
{
    /// <summary>
    /// 扩展的 Canvas 组件
    /// </summary>
    public class ExtendedCanvas : Canvas
    {
        private Stack<FrameworkElement> History { get; set; }

        private bool IsMouseDown;

        public bool EditEnabled { get; set; }

        /// <summary>
        /// 允许的最大图形数量，为0时表示不限制
        /// </summary>
        public int MaxChildren { get; set; }

        /// <summary>
        /// 绘制的图形类型
        /// </summary>
        public DrawShapes DefaultDrawType { get; set; }

        /// <summary>
        /// 当前的绘制
        /// </summary>
        private DrawRecord current;

        /// <summary>
        /// 移动
        /// </summary>
        private bool MoveMode;

        private Point MouseDownPoint;

        /// <summary>
        /// 绘图事件
        /// </summary>
        public event EventHandler<DrawEventArgs> OnDraw;

        public ExtendedCanvas()
        {
            History = new Stack<FrameworkElement>();
            BindEvent();
        }

        private void EmitDrawEvent(DrawState state, bool isEmpty = false)
        {
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
            MouseLeftButtonUp += OnMouseLeftButtonUp;
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
            if (History.Any(item => item.Equals(element)))
            {
                return;
            }
            Children.Add(element);
            History.Push(element);
            GC.Collect();
        }

        /// <summary>
        /// 重做
        /// </summary>
        public void Redo()
        {

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
            Children.Remove(element);
            EmitDrawEvent(DrawState.End, true);
        }

        #region 事件
        private void OnMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!EditEnabled)
            {
                return;
            }
            var point = e.GetPosition(this);
            if (MaxChildren > 0 && History.Count >= MaxChildren)
            {
                // 不在框内按下鼠标，不处理拖动
                if (!current.ElementRect.Contains(point))
                {
                    return;
                }
                MouseDownPoint = point;
                MoveMode = true;
                IsMouseDown = true;
                EmitDrawEvent(DrawState.Start);
                return;
            }

            current = new DrawRecord
            {
                Shape = DefaultDrawType,
                Color = Colors.Blue
            };
            current.Start = point;
            IsMouseDown = true;
            EmitDrawEvent(DrawState.Start);
        }

        private void OnMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!EditEnabled || !IsMouseDown)
            {
                return;
            }
            IsMouseDown = false;
            if (MoveMode)
            {
                current.Move(MouseDownPoint, e.GetPosition(this));
                MoveMode = false;
                EmitDrawEvent(DrawState.End);
                return;
            }
            current.End = e.GetPosition(this);
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
            if (MoveMode)
            {
                current.Move(MouseDownPoint, point);
                EmitDrawEvent(DrawState.Move);
                MouseDownPoint = point;
                return;
            }

            current.End = point;
            Draw(current);
            EmitDrawEvent(DrawState.Move);
        }

        private void On_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // 取消图形
            Undo();
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
        End
    }
}
