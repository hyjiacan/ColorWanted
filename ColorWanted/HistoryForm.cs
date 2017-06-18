using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ColorWanted
{
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void MouseDownEventHandler(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, NativeMethods.WM_SYSCOMMAND,
                    new IntPtr(NativeMethods.SC_MOVE + NativeMethods.HTCAPTION), IntPtr.Zero);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void linkFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!File.Exists(ColorHistory.FullName))
            {
                File.Create(ColorHistory.FullName).Close();
            }

            Process.Start(ColorHistory.FullName);
        }

        private void linkClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!File.Exists(ColorHistory.FullName))
            {
                return;
            }

            File.WriteAllText(ColorHistory.FullName, "");
            LoadHistory();
        }

        private void linkReload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadHistory();
        }

        /// <summary>
        /// 加载历史
        /// </summary>
        private void LoadHistory()
        {
            list.Clear();

            var history = ColorHistory.Get();
            if (history == null || history.Length == 0)
            {
                return;
            }

            ListViewGroup group = null;
            var groupTime = DateTime.MinValue;
            foreach (var item in history.OrderByDescending(item => item.DateTime))
            {
                if (group == null || groupTime != item.DateTime.Date)
                {
                    group = new ListViewGroup(item.DateTime.ToString("yyyy-MM-dd"));

                    list.Groups.Add(group);
                    groupTime = item.DateTime.Date;
                }
                list.Items.Add(RenderItem(item, group));
            }
        }

        private ListViewItem RenderItem(ColorHistory history, ListViewGroup group)
        {
            return new ListViewItem(group)
            {
                BackColor = history.Color,
                ForeColor = ColorUtil.GetContrastColor(history.Color),
                Text = string.Format("#{0:X2}{1:X2}{2:X2}",
                    history.Color.R,
                    history.Color.G,
                    history.Color.B),
                Tag = history.Color,
                ToolTipText = history.DateTime.ToString("yyyy-MM-dd HH:mm:ss")
            };
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            LoadHistory();
        }

        private void linkHex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var item = sender as LinkLabel;
            Util.SetClipboard(Handle, item.Text);
        }

        private void linkRgb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var item = sender as LinkLabel;
            Util.SetClipboard(Handle, item.Text);
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = list.SelectedItems;

            var color = item.Count == 0 ? Color.Black : (Color)item[0].Tag;

            linkHex.Text = string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
            linkRgb.Text = string.Format("RGB({0},{1},{2})", color.R, color.G, color.B);
        }
    }
}
