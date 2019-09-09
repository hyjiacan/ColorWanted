using ColorWanted.ext;
using ColorWanted.screenshot.events;
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
        /// 编辑状态改变时的事件
        /// </summary>
        public event EventHandler<AreaSelectedEventArgs> AreaSelected;

        /// <summary>
        /// 选区被清除时的事件
        /// </summary>
        public event EventHandler AreaCleared;

        public ImageEditor()
        {
            InitializeComponent();
        }

        public void SetImage(Bitmap image)
        {
            this.image = image;

            canvasEdit.Width = canvasMask.Width = Width;
            canvasEdit.Height = canvasMask.Height = Height;

            //Topmost = true;
            maskBackground.ImageSource = image.AsOpacity(0.7f).AsResource();
        }

        /// <summary>
        /// 获取当前的编辑
        /// </summary>
        /// <returns></returns>
        public DrawRecord GetCurrentRecord()
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// 获取编辑结果
        /// </summary>
        /// <returns></returns>
        public Bitmap GetResult()
        {
            throw new NotImplementedException();
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

            AreaSelected.Invoke(this, new AreaSelectedEventArgs(area));
        }
        private void UpdateSelectArea(Rect selectedRect)
        {
            if (lastSelectedRect == selectedRect)
            {
                return;
            }
            lastSelectedRect = selectedRect;

            var img = image.Cut(selectedRect).AsResource();

            selectArea.Source = img;
            selectArea.SetLocation(selectedRect.X, selectedRect.Y);
            selectArea.Visibility = Visibility.Visible;
        }
    }
}
