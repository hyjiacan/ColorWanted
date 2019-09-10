using ColorWanted.ext;
using ColorWanted.screenshot.events;
using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

        public ImageEditor()
        {
            InitializeComponent();
        }

        public void SetImage(Bitmap image)
        {
            this.image = image;

            container.SetLocation(0, 0);
            container.Width = ScreenShot.SCREEN_WIDTH;
            container.Height = ScreenShot.SCREEN_HEIGHT;

            canvasMask.SetLocation(0, 0);
            canvasMask.Width = ScreenShot.SCREEN_WIDTH;
            canvasMask.Height = ScreenShot.SCREEN_HEIGHT;

            //Topmost = true;
            maskBackground.ImageSource = image.AsOpacity(0.7f).AsResource();
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
            var renderer = new RenderTargetBitmap(
                (int)canvasEdit.Width,
                (int)canvasEdit.Height,
                96,
                96,
                PixelFormats.Pbgra32
                );
            renderer.Render(canvasEdit);
            var encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create((BitmapSource)selectArea.Source));
            encoder.Frames.Add(BitmapFrame.Create(renderer));
            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                return new Bitmap(stream);
            }
        }

        private void CanvasMask_OnDraw(object sender, DrawEventArgs e)
        {
            if (e.IsEmpty)
            {
                selectArea.Visibility = Visibility.Hidden;
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
            selectArea.Visibility = Visibility.Visible;
        }

        private void CanvasMask_AreaDoubleClicked(object sender, AreaEventArgs e)
        {
            // 截图完成
            Compeleted.Invoke(this, new DoubleClickEventArgs(SelectedImage));
        }
    }
}
