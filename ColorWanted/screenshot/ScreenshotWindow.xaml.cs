using ColorWanted.ext;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
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

        private FrameworkElement selectArea;

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
            current = new DrawRecord
            {
                Type = DrawTypes.Rectangle,
                Color = Colors.Blue,
                Start = e.GetPosition(canvasMask)
            };
            mousedown = true;
        }

        private void CanvasMask_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Editing)
            {
                return;
            }
            mousedown = false;
            current.End = e.GetPosition(canvasMask);
            DrawMask();
        }

        private void CanvasMask_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (Editing || !mousedown)
            {
                return;
            }

            current.End = e.GetPosition(canvasMask);
            DrawMask();
        }
        bool a = false;
        private void DrawMask()
        {
            if (a)
            {
                a = false;
                return;
            }
            a = true;
            if (current == null)
            {
                return;
            }

            System.Console.WriteLine(current.ToString());
            if (selectArea == null)
            {
                selectArea = current.GetDrawElement();
                canvasMask.Children.Add(selectArea);
                return;
            }
            //canvasMask.Undo();
            //canvasMask.Draw(current);

            selectArea.SetValue(Canvas.LeftProperty, current.Rect.X);
            selectArea.SetValue(Canvas.TopProperty, current.Rect.Y);
            selectArea.Width = current.Size.Width;
            selectArea.Height = current.Size.Height;
            //System.Console.WriteLine("Children:" + canvasMask.Children.Count);
        }
    }
}
