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

        /// <summary>
        /// 选区的边框 
        /// </summary>
        private System.Windows.Shapes.Rectangle SelectionBorder;

        /// <summary>
        /// 编辑状态改变时的事件
        /// </summary>
        public event EventHandler<AreaEventArgs> AreaSelected;

        /// <summary>
        /// 双击mask层的选区时，表示截图完成，触发此事件
        /// </summary>
        public event EventHandler<DoubleClickEventArgs> Compeleted;

        /// <summary>
        /// 选区被清除时的事件
        /// </summary>
        public event EventHandler AreaCleared;

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
        public Font TextFont
        {
            get => canvasEdit.TextFont;
            set => canvasEdit.TextFont = value;
        }
        public Rectangle Bounds
        {
            get => SelectionBorder == null ? new Rectangle() :
                new Rectangle(SelectionBorder.GetLocation().ToDrawingPoint(),
                    SelectionBorder.GetSize().ToDrawingSize());
        }

        public ImageEditor()
        {
            InitializeComponent();
        }

        public void SetImage(Bitmap image)
        {
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
            canvasMask.EditEnabled = false;

            editBackground.ImageSource = selectArea.Source;
            // 先设置位置，然后再显示出来
            canvasEdit.Width = lastSelectedRect.Width;
            canvasEdit.Height = lastSelectedRect.Height;

            canvasEdit.SetLocation(lastSelectedRect.Location);
            canvasEdit.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// 编辑完成
        /// <returns>返回编辑后的图形</return>
        /// </summary>
        public Bitmap EndEdit()
        {
            canvasMask.EditEnabled = true;
            canvasEdit.CommitTextInput();
            var graphics = Graphics.FromImage(SelectedImage);
            foreach (var item in canvasEdit.History)
            {
                graphics.Draw(item.Record);
            }

            return SelectedImage;
        }

        public void Undo()
        {
            canvasEdit.Undo();
        }

        private void SetBorder()
        {
            const int BORDER_WIDTH = 1;

            if (SelectionBorder == null)
            {
                // 添加边框
                SelectionBorder = new System.Windows.Shapes.Rectangle
                {
                    StrokeThickness = BORDER_WIDTH,
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue)
                };

                canvasMask.Children.Add(SelectionBorder);
            }
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
            SelectionBorder.Width = w;
            SelectionBorder.Height = h;
            SelectionBorder.Visibility = Visibility.Visible;
        }

        private void CanvasMask_OnDraw(object sender, DrawEventArgs e)
        {
            if (e.State == DrawState.Cancel || e.IsEmpty)
            {
                selectArea.Visibility = Visibility.Hidden;
                if (SelectionBorder != null)
                {
                    SelectionBorder.Visibility = Visibility.Hidden;
                }
                AreaCleared.Invoke(this, null);
                return;
            }

            if (e.State == DrawState.Start)
            {
                return;
            }
            var area = e.Area;
            if (area.IsEmpty || area.Width == 0 || area.Height == 0)
            {
                selectArea.Visibility = Visibility.Hidden;
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

            AreaSelected.Invoke(this, new AreaEventArgs(area));
        }
        private void UpdateSelectArea(Rect selectedRect)
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
            SetBorder();
        }

        private void CanvasMask_AreaDoubleClicked(object sender, AreaEventArgs e)
        {
            if (e.Rect.IsEmpty)
            {
                return;
            }
            var image = SelectedImage ?? EndEdit();
            // 截图完成
            Compeleted.Invoke(this, new DoubleClickEventArgs(image));
        }

        public void Reset()
        {
            if (image != null)
            {
                try
                {
                    image.Dispose();
                }
                finally
                {
                    image = null;
                }
            }
            counter = 0;
            if (SelectedImage != null)
            {
                try
                {
                    SelectedImage.Dispose();
                }
                finally
                {
                    SelectedImage = null;
                }
            }
            maskBackground.ImageSource = null;
            selectArea.Source = null;
            editBackground.ImageSource = null;
            if (SelectionBorder != null)
            {
                SelectionBorder.Visibility = Visibility.Hidden;
            }
            try
            {
                canvasMask.Reset();
            }
            catch { }

            try
            {
                canvasEdit.Reset();
            }
            catch { }
            canvasEdit.Visibility = Visibility.Hidden;
            canvasMask.EditEnabled = true;
        }

        private void canvasMask_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            canvasEdit.ExtendedCanvas_MouseUp(sender, e);
        }

        private void canvasMask_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            canvasEdit.OnMouseMove(null, e);
        }
    }
}
