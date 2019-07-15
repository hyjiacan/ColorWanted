using ColorWanted.ext;
using ColorWanted.screen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ColorWanted
{
    public partial class ScreenForm : Form
    {
        /// <summary>
        /// 截图得到的图片对象
        /// </summary>
        private Bitmap image;
        /// <summary>
        /// 截图得到的图片对象(模糊后的图)
        /// </summary>
        private Bitmap blurImage;
        /// <summary>
        /// 屏幕截图的画布
        /// </summary>
        private Graphics previewGraphics;
        /// <summary>
        /// 选择区域的画布
        /// </summary>
        private Graphics editorGraphics;
        /// <summary>
        /// 标记鼠标是否按下
        /// </summary>
        private bool mousedown;
        /// <summary>
        /// 当前选择的区域
        /// </summary>
        private DrawRecord current;
        /// <summary>
        /// 编辑历史
        /// </summary>
        private Stack<DrawRecord> history;

        private bool editAreaSelected;

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
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            history = new Stack<DrawRecord>();
        }

        public void Show(Bitmap img)
        {
            current = new DrawRecord
            {
                Type = DrawType.Rectangle,
                Color = Color.Blue
            };
            image = img;
            picturePreview.BackgroundImage = img;
            if (previewGraphics == null)
            {
                previewGraphics = picturePreview.CreateGraphics();
            }
            Refresh();
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

        private void PicturePreview_MouseDown(object sender, MouseEventArgs e)
        {
            if (editAreaSelected)
            {
                // 如果已经开始编辑

                // 点击右键时就撤销编辑
                // 一直撤销到没有历史
                // 然后可以重新选择截图区域
                if (e.Button == MouseButtons.Right)
                {
                    if (history.Count > 0)
                    {
                        history.Pop();
                        Redraw();
                    }
                    else
                    {
                        HideEdit();
                    }
                    return;
                }

                // 点击左键 编辑

                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                // 重新选择
                current.Reset();
            }
            else if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (current.HasOffset)
            {
                ShowEdit();
                return;
            }
            mousedown = true;
            // 刷新后再重绘
            Refresh();
            current.Start = e.Location;
        }

        private void PicturePreview_MouseUp(object sender, MouseEventArgs e)
        {
            if (!mousedown || previewGraphics == null || current == null)
            {
                return;
            }
            current.End = e.Location;
            Redraw();
            mousedown = false;
        }

        private void PicturePreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mousedown || previewGraphics == null)
            {
                return;
            }
            current.End = e.Location;
            Redraw();
        }

        private void PicturePreview_MouseLeave(object sender, EventArgs e)
        {
            mousedown = false;
        }

        private void Redraw()
        {
            Refresh();
            if (current != null && current.HasOffset)
            {
                previewGraphics.Draw(current);
            }
            foreach (var record in history)
            {
                previewGraphics.Draw(record);
            }
        }

        private void ScreenForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            this.CloseForm();
        }

        private void CloseForm()
        {
            image = null;
            mousedown = false;
            current = null;
            Hide();
        }

        private void ShowEdit()
        {
            editAreaSelected = true;
            if (blurImage == null)
            {
                blurImage = image.Blur();
            }
            picturePreview.BackgroundImage = blurImage;
            // 画个工作区
            previewGraphics.Draw(current);

            pictureEditor.Bounds = current.Rect;
            pictureEditor.BackgroundImage = image.Cut(current.Rect);
            pictureEditor.Show();
            pictureEditor.BringToFront();
            toolbar.Show();
            toolbar.BringToFront();
        }

        private void HideEdit()
        {
            editAreaSelected = false;
            toolbar.Hide();
            pictureEditor.Hide();
            picturePreview.BackgroundImage = image;
            picturePreview.BringToFront();
        }
    }
}
