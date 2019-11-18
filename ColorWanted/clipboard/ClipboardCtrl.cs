using System;
using System.Windows.Forms;

namespace ColorWanted.clipboard
{
    public delegate void RemoveDelegete(ClipboardCtrl ctrl, string filename);
    public partial class ClipboardCtrl : UserControl
    {
        public string Date { get; set; }
        public RemoveDelegete OnRemove;

        public ClipboardCtrl()
        {
            InitializeComponent();
        }

        public ClipboardCtrl(string name)
        {
            InitializeComponent();

            var data = ClipboardManager.Read(name);
            FileName = name;
            Date = lbTime.Text = data.Date;
            tbContent.Text = data.Data;
        }

        public string FileName { get; }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            ClipboardManager.CopyHistory = true;
            Clipboard.SetText(tbContent.Text);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            OnRemove?.Invoke(this, FileName);
        }

        private void tbContent_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            var height = e.NewRectangle.Height + 40;
            if (height > 80)
            {
                Height = 80;
            }
            Height = height;
            Update();
        }

        private void ClipboardCtrl_MouseHover(object sender, EventArgs e)
        {
            btnCopy.Visible = btnRemove.Visible = true;
        }

        private void ClipboardCtrl_MouseLeave(object sender, EventArgs e)
        {
            var point = PointToClient(MousePosition);
            // 4 是个偏移量
            var onContyrol = point.X >= 0 && point.Y >= 0 && point.X < Width - 4 && point.Y < Height - 4;
            btnCopy.Visible = btnRemove.Visible = onContyrol;
        }
    }
}
