using ColorWanted.screen;
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
        private Stack<DrawRecord> history;
        private DrawRecord currentShape;
        private Point mousedownLocation;
        private bool mousedown;

        /// <summary>
        /// 是否选择了选区
        /// </summary>
        private bool selected;


        public ScreenForm()
        {
            InitializeComponent();
            history = new Stack<DrawRecord>();
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
            DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        public void Show(Bitmap img)
        {
            image = img;
            picturePreview.BackgroundImage = img;
            if (graphics == null)
            {
                graphics = picturePreview.CreateGraphics();
            }
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
            if (e.Button == MouseButtons.Right)
            {
                if (history.Count > 0)
                {
                    // 撤销
                    history.Pop();
                    Redraw();
                }
                return;
            }
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            mousedownLocation = e.Location;
            mousedown = true;
            currentShape = DrawRecord.Make(DrawType.Rectange);
            currentShape.Start = e.Location;
        }

        private void PicturePreview_MouseUp(object sender, MouseEventArgs e)
        {
            if (!mousedown || graphics == null || currentShape == null)
            {
                return;
            }
            mousedown = false;
            currentShape.End = e.Location;
            if(currentShape.HasOffset)
            {
                history.Push(currentShape);
            }
            currentShape = null;
            Redraw();
        }

        private void PicturePreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mousedown || graphics == null || currentShape == null)
            {
                return;
            }
            currentShape.End = e.Location;
            Redraw();
        }

        private void PicturePreview_MouseLeave(object sender, EventArgs e)
        {
            currentShape = null;
            mousedown = false;
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //}

        private void Redraw()
        {
            Refresh();
            if (currentShape != null && currentShape.HasOffset)
            {
                Draw(currentShape);
            }
            foreach (var record in history)
            {
                Draw(record);
            }
        }

        private void Draw(DrawRecord record)
        {
            var pen = new Pen(record.Color);
            switch (record.Type)
            {
                case DrawType.Circle:
                    break;
                case DrawType.Ellipse:
                    break;
                case DrawType.Line:
                    graphics.DrawLine(pen, record.Start, record.End);
                    break;
                case DrawType.Rectange:
                    graphics.DrawRectangle(pen, record.Rect);
                    break;
                case DrawType.Text:
                    graphics.DrawString(record.Text, SystemFonts.DefaultFont, new SolidBrush(record.Color), record.Start);
                    break;
            }
        }
    }
}
