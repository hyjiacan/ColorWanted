using ColorWanted.ext;
using ColorWanted.screenshot.events;
using ColorWanted.util;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace ColorWanted.screenshot
{
    /// <summary>
    /// CanvasControl.xaml 的交互逻辑
    /// </summary>
    public partial class ImageEditor : UserControl
    {
        /// <summary>
        /// 全屏图片对象
        /// </summary>
        private Bitmap image { get; set; }

        /// <summary>
        /// 记录上次的选区
        /// </summary>
        private Rect lastSelectedRect;

        /// <summary>
        /// 渲染计数，用于降低选区大小或位置变化时的渲染频次
        /// </summary>
        private int counter = 0;

        /// <summary>
        /// 渲染频次，每5次请求渲染一次
        /// </summary>
        private const int RENDER_TICK = 3;

        /// <summary>
        /// 选区内的截图（剪裁后的图片）
        /// </summary>
        private Bitmap SelectedImage;

        private ResizeBorder resizeBorder;

        /// <summary>
        /// 编辑状态改变时的事件
        /// </summary>
        public event EventHandler<AreaEventArgs> AreaSelected;

        /// <summary>
        /// 双击mask层的选区时，表示截图完成，触发此事件
        /// </summary>
        public event EventHandler<DoubleClickEventArgs> Compeleted;

        public event EventHandler<HistoryEventArgs> HistoryChange;

        /// <summary>
        /// 选区被清除时的事件
        /// </summary>
        public event EventHandler AreaCleared;

        public bool IsEditing { get; private set; }

        public DrawShapes DrawShape
        {
            get => canvasEdit.DrawShape;
            set => canvasEdit.DrawShape = value;
        }
        public LineStyles LineStyle
        {
            get => canvasEdit.LineStyle;
            set => canvasEdit.LineStyle = value;
        }
        public int DrawWidth
        {
            get => canvasEdit.DrawWidth;
            set => canvasEdit.DrawWidth = value;
        }
        public System.Windows.Media.Color DrawColor
        {
            get => canvasEdit.DrawColor;
            set => canvasEdit.DrawColor = value;
        }
        public DrawModes DrawMode
        {
            get => canvasEdit.DrawMode;
            set => canvasEdit.DrawMode = value;
        }
        public Font TextFont
        {
            get => canvasEdit.TextFont;
            set => canvasEdit.TextFont = value;
        }
        public Rectangle Bounds
        {
            get => new Rectangle(SelectionBorder.GetLocation().ToDrawingPoint(),
                    SelectionBorder.GetSize().ToDrawingSize());
        }

        public ImageEditor()
        {
            InitializeComponent();
        }

        public void SetImage(Bitmap image)
        {
            resizeBorder?.Dispose();

            this.image = image;

            container.SetLocation(0, 0);
            container.Width = image.Width;
            container.Height = image.Height;

            canvasMask.SetLocation(0, 0);
            canvasMask.Width = image.Width;
            canvasMask.Height = image.Height;

            maskBackground.ImageSource = image.AsOpacity(0.8f).AsResource();
        }

        public void BeginEdit()
        {
            // 开始编辑时，隐藏 resize border
            resizeBorder.Dispose();
            canvasMask.EditEnabled = false;

            editBackground.ImageSource = selectArea.Source;
            // 先设置位置，然后再显示出来
            canvasEdit.Width = lastSelectedRect.Width;
            canvasEdit.Height = lastSelectedRect.Height;

            canvasEdit.SetLocation(lastSelectedRect.Location);
            canvasEdit.Visibility = Visibility.Visible;
            IsEditing = true;
        }

        /// <summary>
        /// 编辑完成
        /// <returns>返回编辑后的图形</return>
        /// </summary>
        public Bitmap EndEdit()
        {
            IsEditing = false;
            canvasMask.EditEnabled = true;
            canvasEdit.CommitTextInput();
            var graphics = Graphics.FromImage(SelectedImage);
            foreach (var item in canvasEdit.History)
            {
                graphics.Draw(item.Record);
            }

            return SelectedImage;
        }

        public void CancelEdit()
        {
            resizeBorder?.Dispose();
        }

        public void Undo()
        {
            if (!canvasEdit.EditEnabled)
            {
                return;
            }
            canvasEdit.Undo();
        }

        public void Redo()
        {
            if (!canvasEdit.EditEnabled)
            {
                return;
            }
            canvasEdit.Redo();
        }

        private void SetBorder()
        {
            double BORDER_WIDTH = SelectionBorder.StrokeThickness;
            var x = lastSelectedRect.X - BORDER_WIDTH;
            if (x < 0)
            {
                x = 0;
            }
            var y = lastSelectedRect.Y - BORDER_WIDTH;
            if (y < 0)
            {
                y = 0;
            }

            var size = Util.GetScreenSize();

            var w = lastSelectedRect.Width + BORDER_WIDTH * 2;
            if (w + x > size.Width)
            {
                w = size.Width - x;
            }
            var h = lastSelectedRect.Height + BORDER_WIDTH * 2;
            if (h + y > size.Height)
            {
                h = size.Height - y;
            }
            SelectionBorder.SetLocation(x, y);
            // -1 用于修正 border 边框引起的计算误差
            SelectionBorder.Width = w - 1;
            SelectionBorder.Height = h - 1;
            SelectionBorder.Visibility = Visibility.Visible;
        }

        private void ResizeBorder_Resize(object sender, ResizeEventArgs e)
        {
            var location = SelectionBorder.GetLocation();
            var size = SelectionBorder.GetSize();
            var minSize = 8;
            switch (e.ResizePosition)
            {
                case ResizePositions.North:
                    location.Offset(0, e.OffsetY);
                    size.Height -= e.OffsetY;
                    if (size.Height < minSize)
                    {
                        return;
                    }
                    break;
                case ResizePositions.South:
                    size.Height += e.OffsetY;
                    if (size.Height < minSize)
                    {
                        return;
                    }
                    break;
                case ResizePositions.West:
                    location.Offset(e.OffsetX, 0);
                    size.Width -= e.OffsetX;
                    if (size.Width < minSize)
                    {
                        return;
                    }
                    break;
                case ResizePositions.East:
                    size.Width += e.OffsetX;
                    if (size.Width < minSize)
                    {
                        return;
                    }
                    break;
                case ResizePositions.NorthWest:
                    location.Offset(e.OffsetX, e.OffsetY);
                    size.Width -= e.OffsetX;
                    size.Height -= e.OffsetY;
                    if (size.Width < minSize)
                    {
                        size.Width = minSize;
                    }
                    if (size.Height < minSize)
                    {
                        size.Height = minSize;
                    }
                    break;
                case ResizePositions.SouthWest:
                    location.Offset(e.OffsetX, 0);
                    size.Width -= e.OffsetX;
                    size.Height += e.OffsetY;
                    if (size.Width < minSize)
                    {
                        size.Width = minSize;
                    }
                    if (size.Height < minSize)
                    {
                        size.Height = minSize;
                    }
                    break;
                case ResizePositions.SouthEast:
                    size.Width += e.OffsetX;
                    size.Height += e.OffsetY;
                    if (size.Width < minSize)
                    {
                        size.Width = minSize;
                    }
                    if (size.Height < minSize)
                    {
                        size.Height = minSize;
                    }
                    break;
                case ResizePositions.NorthEast:
                    location.Offset(0, e.OffsetY);
                    size.Width += e.OffsetX;
                    size.Height -= e.OffsetY;
                    if (size.Width < minSize)
                    {
                        size.Width = minSize;
                    }
                    if (size.Height < minSize)
                    {
                        size.Height = minSize;
                    }
                    break;
            }

            // 不能超出画布
            if (location.X < 0)
            {
                return;
            }
            if (location.Y < 0)
            {
                return;
            }
            if (location.X + size.Width > container.Width)
            {
                return;
            }
            if (location.Y + size.Height > container.Height)
            {
                return;
            }
            if (size.Width < 0)
            {
                return;
            }
            if (size.Height < 0)
            {
                return;
            }

            SelectionBorder.SetLocation(location);
            SelectionBorder.SetSize(size);
            canvasMask.UpdateCurrent(location, size);
            resizeBorder.FixPosition();

            var area = new Rect(location, size);
            UpdateSelectArea(area, false);

            if (e.End)
            {
                AreaSelected.Invoke(this, new AreaEventArgs(area));
            }
            else
            {
                AreaCleared.Invoke(this, null);
            }
        }

        private void CanvasMask_OnDraw(object sender, DrawEventArgs e)
        {
            if (e.State == DrawState.Cancel || e.IsEmpty)
            {
                selectArea.Visibility = Visibility.Hidden;
                SelectionBorder.Visibility = Visibility.Hidden;
                resizeBorder?.Dispose();
                AreaCleared.Invoke(this, null);
                return;
            }

            if (e.State == DrawState.Start)
            {
                if (!e.IsEmpty)
                {
                    resizeBorder?.Dispose();
                }
                return;
            }
            var area = e.Area;
            if (area.IsEmpty || area.Width == 0 || area.Height == 0)
            {
                selectArea.Visibility = Visibility.Hidden;
                resizeBorder?.Dispose();
                AreaCleared.Invoke(this, null);
                return;
            }

            if (e.State == DrawState.Move)
            {
                counter++;
                if (counter % RENDER_TICK == 0)
                {
                    UpdateSelectArea(area);
                    AreaCleared.Invoke(this, null);
                }
                return;
            }

            // 肯定是 DrawState.End
            counter = 0;
            // 立即执行
            UpdateSelectArea(area);

            if (e.LeftButtonPressed)
            {
                return;
            }

            AreaSelected.Invoke(this, new AreaEventArgs(area));

            // 异步显示 resize ，以避免选区完成时， resize 被激活
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(300);
                Dispatcher.Invoke(() =>
                {
                    // 显示 resize border
                    if (resizeBorder == null || resizeBorder.IsDisposed)
                    {
                        resizeBorder = new ResizeBorder(container, SelectionBorder);
                        resizeBorder.Resize += ResizeBorder_Resize;
                    }
                    resizeBorder.FixPosition();
                });
            });
        }
        private void UpdateSelectArea(Rect selectedRect, bool updateBorder = true)
        {
            if (lastSelectedRect == selectedRect)
            {
                return;
            }

            lastSelectedRect = selectedRect;
            // 剪裁
            SelectedImage = image.Cut(selectedRect);

            selectArea.Source = SelectedImage.AsResource();
            selectArea.SetLocation(selectedRect.X, selectedRect.Y);
            if (selectArea.Visibility != Visibility.Visible)
            {
                selectArea.Visibility = Visibility.Visible;
            }
            if (updateBorder)
            {
                SetBorder();
            }
        }

        private void CanvasMask_AreaDoubleClicked(object sender, AreaEventArgs e)
        {
            if (e.Rect.IsEmpty)
            {
                return;
            }
            resizeBorder?.Dispose();
            var image = SelectedImage ?? EndEdit();
            // 截图完成
            Compeleted.Invoke(this, new DoubleClickEventArgs(image));
        }

        public void Reset()
        {
            try
            {
                image?.Dispose();
            }
            finally
            {
                image = null;
            }
            counter = 0;
            try
            {
                SelectedImage?.Dispose();
            }
            finally
            {
                SelectedImage = null;
            }
            maskBackground.ImageSource = null;
            selectArea.Source = null;
            editBackground.ImageSource = null;
            SelectionBorder.Visibility = Visibility.Hidden;
            try
            {
                canvasMask.Reset();
            }
            catch (Exception ex)
            {
                Logger.Warn(ex);
            }

            try
            {
                canvasEdit.Reset();
            }
            catch (Exception ex)
            {
                Logger.Warn(ex);
            }
            canvasEdit.Visibility = Visibility.Hidden;
            canvasMask.EditEnabled = true;
        }

        private void canvasMask_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (resizeBorder != null)
            {
                resizeBorder.EndResize();
            }
            canvasEdit.ExtendedCanvas_MouseUp(sender, e);
        }

        private void canvasMask_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            canvasEdit.OnMouseMove(null, e);
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                // 移动选区时，resize border 一起移动
                resizeBorder?.FixPosition();
            }
        }

        private void SelectionBorder_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (resizeBorder != null)
            {
                resizeBorder.EndResize();
            }
        }

        private void container_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (resizeBorder != null)
            {
                resizeBorder.EndResize();
            }
        }

        private void container_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                resizeBorder?.UpdateState(e.GetPosition(container));
            }
        }

        private void canvasEdit_HistoryChange(object sender, HistoryEventArgs e)
        {
            HistoryChange?.Invoke(sender, e);
        }

        private void container_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Z)
            {
                return;
            }
            // 实现  undo  redo
            if (!e.KeyboardDevice.IsKeyDown(System.Windows.Input.Key.LeftCtrl))
            {
                return;
            }

            // ctrl z
            // undo
            if (!e.KeyboardDevice.IsKeyDown(System.Windows.Input.Key.LeftShift))
            {
                this.Undo();
                return;
            }

            // ctrl shift z

            this.Redo();
        }
    }
}
