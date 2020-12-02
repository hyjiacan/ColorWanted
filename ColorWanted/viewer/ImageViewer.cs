using ColorWanted.ext;
using ColorWanted.setting;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ColorWanted.viewer
{
    public partial class ImageViewer : Form
    {
        private Timer timer;
        /// <summary>
        /// 定时器运行中的最近一次鼠标位置
        /// </summary>
        private Point LastMousePosition;
        /// <summary>
        /// 一次获取尺寸的位置
        /// </summary>
        private Point LastSizePosition;
        /// <summary>
        /// 拖到窗口的图片路径
        /// </summary>
        private string dragPic;
        /// <summary>
        /// 图片拖动到窗口上，再离开后，需要恢复成原图
        /// </summary>
        private Image oldImage;
        /// <summary>
        /// 因为计算大小时，会修改原图片，所以在这里保存原图片，以便恢复之用
        /// </summary>
        private Image originImage;
        /// <summary>
        /// 当前鼠标左键是否按下
        /// </summary>
        private bool LeftMouseButtonDown;
        /// <summary>
        /// 当前鼠标右键是否按下
        /// </summary>
        private bool RightMouseButtonDown;
        // 用来实现拖动功能
        private Point oldLocation;
        /// <summary>
        /// 目录下的图片列表
        /// </summary>
        private static string[] PicList;

        private static int _index;

        public string CurrentImageName { get; private set; }

        /// <summary>
        /// 当前显示的图片索引
        /// </summary>
        int ShowIndex
        {
            get
            {
                return _index;
            }
            set
            {
                lbPicIndex.Text = $"{value + 1}/{PicList.Length}";
                _index = value;
            }
        }
        public ImageViewer(string filename)
        {
            InitializeComponent();

            timer = new Timer
            {
                Interval = 100
            };
            timer.Tick += Timer_Tick;
            timer.Start();

            CurrentImageName = filename;
        }
        public ImageViewer() : this(null)
        {
        }

        /// <summary>
        /// 自动调整图片控件，以适应图片的大小
        /// </summary>
        public void FixSize()
        {
            // 可用区域大小
            var size = pnContainer.Size;

            var img = pictureBox.Image;

            // 图片为空时，啥也不做
            if (img == null)
            {
                return;
            }

            var imgWidth = ImageCache.Width;
            var imgHeight = ImageCache.Height;

            pictureBox.Width = imgWidth;
            pictureBox.Height = imgHeight;

            // 图片小于或等于可用区域大小
            if (imgWidth <= size.Width && imgHeight <= size.Height)
            {
                var paddingLeft = (size.Width - imgWidth) / 2;
                var paddingTop = (size.Height - imgHeight) / 2;

                // 设置图片的位置
                pictureBox.Left = paddingLeft;
                pictureBox.Top = paddingTop;
                return;
            }

            pictureBox.Left = 0;
            pictureBox.Top = 0;
        }

        public static string SelectFile()
        {
            var dialog = new OpenFileDialog
            {
                // { ".png", ".jpg", ".jpeg", ".bmp" };
                Filter = "图片文件|" + string.Join(";", ViewerUtil.SUPPORTED_IMAGES_TYPES.Select(type => $"*{type}"))
            };
            if (DialogResult.OK != dialog.ShowDialog())
            {
                dialog.Dispose();
                return null;
            }
            var filename = dialog.FileName;
            dialog.Dispose();
            return filename;
        }

        public static void OpenImage(string filename)
        {
            var singleton = Settings.Viewer.Singleton;
            ImageViewer viewer = null;
            // 如果存在同文件窗口，直接激活
            foreach (Form form in Application.OpenForms)
            {
                if (!(form is ImageViewer))
                {
                    continue;
                }

                var v = (ImageViewer)form;
                // 单实例时就使用这一个窗口
                if (singleton)
                {
                    viewer = v;
                    viewer.LoadImage(filename);
                    break;
                }

                // 有相同的文件名，重用此窗口
                if (filename.Equals(v.CurrentImageName, StringComparison.OrdinalIgnoreCase))
                {
                    viewer = v;
                    break;
                }
            }
            if (viewer == null)
            {
                // 运行到这里时，表示未找到窗口，新建一个
                viewer = new ImageViewer(filename);
            }
            if (viewer.WindowState == FormWindowState.Minimized)
            {
                viewer.WindowState = FormWindowState.Maximized;
            }
            viewer.Show();
            viewer.FixSize();

            // 延迟将窗口显示到最前，以确保鼠标点击窗口的动作已经完成
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(100);
                viewer.InvokeMethod(() =>
                {
                    viewer.BringToFront();
                });
            });
        }

        #region 图片拖到窗口上加载功能支持
        private void ImageViewer_DragEnter(object sender, DragEventArgs e)
        {
            string[] ps = (string[])e.Data.GetData("FileDrop");
            if (ps.Length == 0)
            {
                return;
            }
            dragPic = ps[0];
            string ext = Path.GetExtension(dragPic).ToLower();
            if (!ViewerUtil.SUPPORTED_IMAGES_TYPES.Contains(ext))
            {
                dragPic = null;
                return;
            }
            e.Effect = DragDropEffects.Link;
            oldImage = pictureBox.Image;
            LoadImage(dragPic);
        }

        private void ImageViewer_DragOver(object sender, DragEventArgs e)
        {
            if (!string.IsNullOrEmpty(dragPic))
            {

            }
        }

        private void ImageViewer_DragLeave(object sender, EventArgs e)
        {
            LoadImage(oldImage);
        }

        private void ImageViewer_DragDrop(object sender, DragEventArgs e)
        {
            LoadImage(dragPic);
        }

        public void LoadImage(string filename)
        {
            // 加载后再说其它的
            var path = Path.GetDirectoryName(filename);

            PicList = Directory.GetFiles(path).Where(file => ViewerUtil.SUPPORTED_IMAGES_TYPES.Contains(Path.GetExtension(file))).ToArray();
            ShowIndex = Array.IndexOf(PicList, filename);

            // 读取出数据，以便释放图片句柄
            var data = File.ReadAllBytes(filename);
            var img = Image.FromStream(new MemoryStream(data));

            Text = string.Format("{0} ({1}x{2})", Path.GetFileName(filename), img.Width, img.Height);
            LoadImage(img);

            CurrentImageName = filename;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var image = (string)e.Argument;
            // 加载后再说其它的
            var path = Path.GetDirectoryName(image);

            PicList = Directory.GetFiles(path).Where(file => ViewerUtil.SUPPORTED_IMAGES_TYPES.Contains(Path.GetExtension(file))).ToArray();
            ShowIndex = Array.IndexOf(PicList, image);
        }

        void LoadImage(Bitmap image)
        {
            LoadImage(image as Image);
        }
        void LoadImage(Image image)
        {
            ImageCache.SetImage(image as Bitmap);
            pictureBox.Image = image;
            originImage = null;
            if (!pictureBox.Visible)
            {
                lbTip.Visible = pictureBox.Visible = true;
                lbTip.BringToFront();
            }
        }
        #endregion

        #region 图片移动支持

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                LeftMouseButtonDown = true;
                Cursor = Cursors.SizeAll;
            }
            else if (e.Button == MouseButtons.Right)
            {
                RightMouseButtonDown = true;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                LeftMouseButtonDown = false;
                oldLocation.X = oldLocation.Y = 0;
                Cursor = Cursors.Cross;
            }
            else if (e.Button == MouseButtons.Right)
            {
                RightMouseButtonDown = false;
            }
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            LeftMouseButtonDown = false;
            RightMouseButtonDown = false;
            oldLocation.X = oldLocation.Y = 0;
            HideSizeLabel();
            Cursor = Cursors.Cross;
        }

        void MovePicture()
        {
            var mousePos = MousePosition;
            var winPos = Location;

            var pos = new Point(mousePos.X - winPos.X, mousePos.Y - winPos.Y);

            if (oldLocation.IsEmpty)
            {
                oldLocation = pos;
                return;
            }

            var offset = new Point(pos.X - oldLocation.X, pos.Y - oldLocation.Y);

            if (pictureBox.Bottom < 10 ||
                pictureBox.Left + 10 > Width ||
                pictureBox.Top + 10 > Height ||
                pictureBox.Right < 10)
            {
                return;
            }

            pictureBox.Left += offset.X;
            pictureBox.Top += offset.Y;

            oldLocation = pos;
        }

        #endregion

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            // 鼠标左键按下时，执行移动图片功能
            if (LeftMouseButtonDown)
            {
                MovePicture();
                return;
            }
            // TODO: 右键没有按下时不计算
            //if (!RightMouseButtonDown)
            //{
            //    return;
            //}
            // 鼠标没有按下时，执行计算区域大小功能
            if (pictureBox.Image != null && !lbTip.Visible)
            {
                lbTip.Visible = true;
                lbTip.BringToFront();
            }
            if (e.Location == LastMousePosition)
            {
                return;
            }
            LastMousePosition = e.Location;
        }
        private void ImageViewer_Resize(object sender, EventArgs e)
        {
            //FixSize();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (LeftMouseButtonDown)
            {
                HideSizeLabel();
                return;
            }
            if (LastSizePosition == LastMousePosition)
            {
                return;
            }
            LastSizePosition = LastMousePosition;
            GetSize(LastSizePosition.X, LastSizePosition.Y);
        }
        void HideSizeLabel()
        {
            if (lbTip.Visible)
            {
                lbTip.Visible = false;
            }
        }
        void GetSize(int x, int y)
        {
            if (pictureBox.Image == null)
            {
                lbTip.Visible = false;
                return;
            }
            if (originImage == null)
            {
                originImage = pictureBox.Image;
            }
            else
            {
                pictureBox.Image = originImage;
            }

            var tipText = "";
            var img = new Bitmap(pictureBox.Image);
            var rect = ImageUtil.GetNearestArea(img, x, y, menuCenterLine.Checked, menuBorder.Checked);
            pictureBox.Image = img;

            // 为啥要 + 1 ？
            // 比如，图片宽度为 10，实际存储为 0到9，也就是说，得到的尺寸是 9-0 ，结果为9，会有1个差
            // 所以。。
            lbTip.Text = $"位置 ({rect.X},{rect.Y})\n尺寸 ({rect.Width + 1},{rect.Height + 1})" + tipText;

            var mousePosition = MousePosition;

            var left = mousePosition.X - Left;
            if (left + lbTip.Width > Width)
            {
                left = left - lbTip.Width - 12;
            }
            else if (left < 0)
            {
                left = 0;
            }
            else
            {
                left -= 6;
            }
            lbTip.Left = left;
            var top = mousePosition.Y - Top;
            // status bar 的高度
            var barHeight = pnBar.Height;
            if (top + lbTip.Height > Height - barHeight)
            {
                top = top - barHeight - lbTip.Height - 12;
            }
            else if (top < 0)
            {
                top = 0;
            }
            else
            {
                top -= 12;
            }
            lbTip.Top = top;
            // 及时回收内存
            GC.Collect();
        }

        private void menuPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                var img = Clipboard.GetImage();
                ImageCache.SetImage(img as Bitmap);
                Text = string.Format("图片查看器 - 来自剪贴板 ({0}x{1})", ImageCache.Width, ImageCache.Height);
                LoadImage(img);
                return;
            }

            if (Clipboard.ContainsFileDropList())
            {
                var file = Clipboard.GetFileDropList().Cast<string>()
                    .Where(f => ViewerUtil.SUPPORTED_IMAGES_TYPES.Contains(Path.GetExtension(f))).FirstOrDefault();
                if (file == null)
                {
                    return;
                }
                LoadImage(file);
            }
        }

        private void ImageViewer_Load(object sender, EventArgs e)
        {
            btnBgColor.BackColor = BackColor = Settings.Viewer.BackColor;

            menuCenterLine.Checked = Settings.Viewer.DrawCenterLine;
            menuBorder.Checked = Settings.Viewer.DrawBorder;

            BringToFront();
            Activate();

            if (CurrentImageName == null)
            {
                return;
            }
            LoadImage(CurrentImageName);
        }

        private void rangeBar_Scroll(object sender, EventArgs e)
        {
            lbRange.Text = rangeBar.Value.ToString();
            ImageUtil.Range = rangeBar.Value;
        }

        private void menuDelete_Click(object sender, EventArgs e)
        {
            pictureBox.Hide();
            pictureBox.Image = null;
            lbTip.Hide();
            ImageCache.Clear();
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            var filename = SelectFile();
            if (filename != null)
            {
                LoadImage(filename);
            }
        }

        private void menuReset_Click(object sender, EventArgs e)
        {
            FixSize();
        }

        private void lkPrev_LinkClicked(object sender, EventArgs e)
        {
            ShowPrev();
        }

        private void lkNext_LinkClicked(object sender, EventArgs e)
        {
            ShowNext();
        }

        private void ImageViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageUp)
            {
                ShowPrev();
                return;
            }
            if (e.KeyCode == Keys.PageDown)
            {
                ShowNext();
                return;
            }
            if (e.KeyCode == Keys.Home)
            {
                ShowFirst();
                return;
            }
            if (e.KeyCode == Keys.End)
            {
                ShowLast();
                return;
            }
        }

        private void ShowPrev()
        {
            if (ShowIndex > 0)
            {
                ShowIndex--;
                LoadImage(PicList[ShowIndex]);
                return;
            }
            ShowLast();
        }

        private void ShowNext()
        {
            if (ShowIndex < PicList.Length - 1)
            {
                ShowIndex++;
                LoadImage(PicList[ShowIndex]);
                return;
            }
            ShowFirst();
        }

        private void ShowFirst()
        {
            LoadImage(PicList[0]);
        }

        private void ShowLast()
        {
            LoadImage(PicList[PicList.Length - 1]);
        }

        private void btnBgColor_Click(object sender, EventArgs e)
        {
            var dialog = new ColorDialog
            {
                Color = Settings.Viewer.BackColor
            };
            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            Settings.Viewer.BackColor = btnBgColor.BackColor = BackColor = dialog.Color;
        }

        private void menuBorder_Click(object sender, EventArgs e)
        {
            Settings.Viewer.DrawBorder = menuBorder.Checked = !menuBorder.Checked;
        }

        private void menuCenterLine_Click(object sender, EventArgs e)
        {
            Settings.Viewer.DrawCenterLine = menuCenterLine.Checked = !menuCenterLine.Checked;
        }
    }
}
