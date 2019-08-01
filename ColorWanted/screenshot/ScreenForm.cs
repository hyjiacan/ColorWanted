using System.Drawing;
using System.Windows.Forms;

namespace ColorWanted.screenshot
{
    public partial class ScreenForm : Form
    {
        /// <summary>
        /// 截图得到的图片对象
        /// </summary>
        private Bitmap image;
        public ScreenForm()
        {
            InitializeComponent();
            // 全屏
            var screen = Screen.PrimaryScreen.Bounds;
            Left = 0;
            Top = 0;
            Width = screen.Width;
            Height = screen.Height;

            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        //const int WS_EX_APPWINDOW = 0x40000;
        //        const int WS_EX_TOOLWINDOW = 0x80;
        //        var cp = base.CreateParams;
        //        //cp.ExStyle &= (~WS_EX_APPWINDOW); // 不显示在TaskBar
        //        cp.ExStyle |= WS_EX_TOOLWINDOW; // 不显示在Alt-Tab
        //        return cp;
        //    }
        //}
    }
}
