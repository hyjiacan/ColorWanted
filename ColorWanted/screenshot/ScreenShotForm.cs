using ColorWanted.util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ColorWanted.screenshot
{
    public partial class ScreenShotForm : Form
    {
        private bool IsActive;

        private bool IsMouseDown;
        private Point MouseDownPosition;

        public ScreenShotForm()
        {
            InitializeComponent();
            // 全屏
            var screen = Util.GetScreenSize();
            Left = 0;
            Top = 0;
            Width = screen.Width;
            Height = screen.Height;

            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            // 设置工具按钮的背景为图片
            // 以防止选中状态时，背景色不可用
            SetToolstripButtonImage(toolColorBlack);
            SetToolstripButtonImage(toolColorBlue);
            SetToolstripButtonImage(toolColorGreen);
            SetToolstripButtonImage(toolColorPurple);
            SetToolstripButtonImage(toolColorRed);

            BindEditorEvents();

            IsActive = true;
        }

        private void ScreenForm_Load(object sender, System.EventArgs e)
        {
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

        private void ScreenForm_Enter(object sender, System.EventArgs e)
        {
            IsActive = true;
        }

        private void ScreenForm_Leave(object sender, System.EventArgs e)
        {
            IsActive = false;
        }

        private void toolbar_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            MouseDownPosition = MousePosition;
            Cursor = Cursors.Hand;
        }

        private void toolbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsMouseDown)
            {
                return;
            }

            var offset = new Point(
                toolPanel.Left + MousePosition.X - MouseDownPosition.X,
                toolPanel.Top + MousePosition.Y - MouseDownPosition.Y
            );

            toolPanel.Left = offset.X;
            toolPanel.Top = offset.Y;

            toolPanel_LocationChanged(null, null);

            MouseDownPosition = MousePosition;
        }

        private void toolbar_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            IsMouseDown = false;
        }

        private void toolPanel_MouseLeave(object sender, System.EventArgs e)
        {
            Cursor = Cursors.Default;
            IsMouseDown = false;
        }

        private void toolPanel_LocationChanged(object sender, EventArgs e)
        {
            var rect = Util.GetScreenBounds();

            var location = new Point(toolPanel.Location.X, toolPanel.Location.Y);

            if (location.X < 0)
            {
                location.X = 0;
            }
            else if (location.X + toolPanel.Width > rect.Width)
            {
                location.X = rect.Width - toolPanel.Width;
            }

            if (location.Y < 0)
            {
                location.Y = 0;
            }
            else if (location.Y + toolPanel.Height > rect.Height)
            {
                location.Y = rect.Height - toolPanel.Height;
            }

            toolPanel.Location = location;

            toolPanel.Update();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                //const int WS_EX_APPWINDOW = 0x40000;
                const int WS_EX_TOOLWINDOW = 0x80;
                var cp = base.CreateParams;
                //cp.ExStyle &= (~WS_EX_APPWINDOW); // 不显示在TaskBar
                cp.ExStyle |= WS_EX_TOOLWINDOW; // 不显示在Alt-Tab
                return cp;
            }
        }
    }
}
