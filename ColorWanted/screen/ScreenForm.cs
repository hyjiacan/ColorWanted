using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ColorWanted
{
    public partial class ScreenForm : Form
    {
        /// <summary>
        /// 截图得到的图片对象
        /// </summary>
        private Image image;
        private Graphics graphics;
        private Stack<GraphicsState> history;
        private Stack<GraphicsState> temp;
        private GraphicsContainer container;
        private Point mousedownLocation;
        private bool mousedown;

        /// <summary>
        /// 是否选择了选区
        /// </summary>
        private bool selected;


        public ScreenForm()
        {
            InitializeComponent();
            history = new Stack<GraphicsState>();
            temp = new Stack<GraphicsState>();
            // 全屏
            var screen = Screen.PrimaryScreen.Bounds;
            //Left = 0;
            //Top = 0;
            //Width = screen.Width;
            //Height = screen.Height;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.TopMost = false;
            this.ControlBox = true;
            this.ShowInTaskbar = true;
        }

        public void Show(Bitmap img)
        {
            image = img;
            picturePreview.BackgroundImage = img;
            if (graphics != null)
            {
                graphics.Dispose();
            }
            graphics = picturePreview.CreateGraphics();
            history.Clear();
            Show();
            BringToFront();
        }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        const int WS_EX_APPWINDOW = 0x40000;
        //        const int WS_EX_TOOLWINDOW = 0x80;
        //        var cp = base.CreateParams;
        //        cp.ExStyle &= (~WS_EX_APPWINDOW); // 不显示在TaskBar
        //        cp.ExStyle |= WS_EX_TOOLWINDOW; // 不显示在Alt-Tab
        //        return cp;
        //    }
        //}

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                var result = util.Util.SetClipboard(Handle, image);
                if (result != null)
                {
                    MessageBox.Show(result);
                }
            }
            Hide();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void PicturePreview_DoubleClick(object sender, EventArgs e)
        {

        }

        private void PicturePreview_MouseDown(object sender, MouseEventArgs e)
        {
            mousedownLocation = e.Location;
            mousedown = true;
            container = graphics.BeginContainer();
        }

        private void PicturePreview_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
            if (graphics == null)
            {
                return;
            }
            graphics.Flush();
            graphics.EndContainer(container);
            history.Push(graphics.Save());
        }

        private void PicturePreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mousedown || graphics == null)
            {
                return;
            }
            if (temp.Count > 0)
            {
                graphics.Restore(temp.Pop());
            }
            graphics.DrawRectangle(Pens.Red, mousedownLocation.X, mousedownLocation.Y,
                e.X - mousedownLocation.X, e.Y - mousedownLocation.Y);
            temp.Push(graphics.Save());
        }

        private void PicturePreview_MouseLeave(object sender, EventArgs e)
        {
            this.PicturePreview_MouseUp(null, null);
        }
    }
}
