using ColorWanted.ext;
using System.Drawing;
using System.Windows;
using System.Windows.Media;

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
        /// 标记鼠标是否按下
        /// </summary>
        private bool mousedown;

        /// <summary>
        /// 当前的绘制
        /// </summary>
        private DrawRecord current;

        /// <summary>
        /// 是否正在编辑，根据编辑层是否可见
        /// </summary>
        private bool Editing => canvasEdit.Visibility == Visibility.Visible;

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

        private void CanvasMask_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Editing)
            {
                return;
            }
            mousedown = true;
            current = new DrawRecord
            {
                Type = DrawTypes.Rectangle,
                Color = Colors.Blue,
                Start = e.GetPosition(e.Source as FrameworkElement)
            };
        }

        private void CanvasMask_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Editing)
            {
                return;
            }
            mousedown = false;
            current.End = e.GetPosition(e.Source as FrameworkElement);
            DrawMask();
        }

        private void CanvasMask_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (Editing || !mousedown)
            {
                return;
            }

            current.End = e.GetPosition(e.Source as FrameworkElement);
            DrawMask();
        }

        private void DrawMask()
        {
            if (current == null)
            {
                return;
            }
            canvasMask.Undo();
            canvasMask.Draw(current);
        }
    }
}
