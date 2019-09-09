using System.Drawing;
using System.Windows.Forms;

namespace ColorWanted.screenshot
{
    public partial class ScreenForm : Form
    {
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

        private void ScreenForm_Load(object sender, System.EventArgs e)
        {
            // 设置工具按钮的背景为图片
            // 以防止选中状态时，背景色不可用
            SetToolstripButtonImage(toolColorBlack);
            SetToolstripButtonImage(toolColorBlue);
            SetToolstripButtonImage(toolColorGreen);
            SetToolstripButtonImage(toolColorPurple);
            SetToolstripButtonImage(toolColorRed);
        }

        private void SetToolstripButtonImage(ToolStripButton button)
        {
            var img = new Bitmap(20, 20);
            var g = Graphics.FromImage(img);
            g.Clear(button.BackColor);
            button.Image = img;
            button.DisplayStyle = ToolStripItemDisplayStyle.Image;
            button.ImageScaling = ToolStripItemImageScaling.None;
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
