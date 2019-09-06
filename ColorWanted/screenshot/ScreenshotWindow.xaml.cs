using ColorWanted.ext;
using System.Drawing;
using System.Windows;

namespace ColorWanted.screenshot
{
    /// <summary>
    /// Screenshot.xaml 的交互逻辑
    /// </summary>
    public partial class ScreenshotWindow : Window
    {
        /// <summary>
        /// 截图得到的图片对象
        /// </summary>
        private Bitmap image;

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
        /// 是否正在编辑，根据编辑层是否可见
        /// </summary>
        public bool Editing => canvasEdit.Visibility == Visibility.Visible;

        public ScreenshotWindow()
        {
            InitializeComponent();
        }
        public void Show(Bitmap img, int screenWidth, int screenHeight)
        {
            Left = 0;
            Top = 0;
            Width = screenWidth;
            Height = screenHeight;
            //Topmost = true;

            image = img;

            maskBackground.ImageSource = img.AsOpacity(0.7f).AsResource();

            //new Thread(InitEditorToolbar) { IsBackground = true }.Start();

            //Refresh();
            Show();
        }
        private void CanvasMask_OnDraw(object sender, DrawEventArgs e)
        {
            if (e.IsEmpty)
            {
                selectArea.Visibility = Visibility.Hidden;
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
                return;
            }

            if (e.State == DrawState.Move)
            {
                counter++;
                if (counter % RENDER_TICK == 0)
                {
                    UpdateSelectArea(area);
                }
                return;
            }

            // 肯定是 DrawState.End
            counter = 0;
            // 立即执行
            UpdateSelectArea(area);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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
