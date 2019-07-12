using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorWanted
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
        }

        public void Show(Bitmap img)
        {
            picturePreview.BackgroundImage = img;
            BringToFront();
            // TODO 是否要隐藏取色窗口与预览窗口
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_APPWINDOW = 0x40000;
                const int WS_EX_TOOLWINDOW = 0x80;
                var cp = base.CreateParams;
                cp.ExStyle &= (~WS_EX_APPWINDOW); // 不显示在TaskBar
                cp.ExStyle |= WS_EX_TOOLWINDOW; // 不显示在Alt-Tab
                return cp;
            }
        }
    }
}
