using ColorWanted.ext;
using ColorWanted.theme;
using ColorWanted.util;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ColorWanted.history
{
    internal partial class HistoryForm : Form
    {
        i18n.I18nManager resources = new i18n.I18nManager(typeof(HistoryForm));
        public HistoryForm()
        {
            componentsLayout();
            ThemeUtil.Apply(this);

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
            HistoryForm_Load(null, null);
        }

        private void linkReload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HistoryForm_Load(null, null);
        }

        private void LoadTree()
        {
            tree.Nodes.Clear();
            new Thread(() =>
            {
                var years = ColorHistory.GetDateTree().OrderByDescending(i => i.Name);
                foreach (var year in years)
                {
                    var yearNode = new TreeNode(year.Name)
                    {
                        Tag = year
                    };
                    this.InvokeMethod(() =>
                    {
                        tree.Nodes.Add(yearNode);
                    });

                    foreach (var month in ColorHistory.GetDateTree(int.Parse(year.Name))
                        .OrderByDescending(i => i.Name))
                    {
                        var monthNode = new TreeNode(month.Name)
                        {
                            Tag = month
                        };
                        this.InvokeMethod(() =>
                        {
                            yearNode.Nodes.Add(monthNode);
                        });
                    }
                }
                this.InvokeMethod(() =>
                {
                    if (tree.Nodes.Count == 0)
                    {
                        return;
                    }
                    var temp = tree.Nodes[0];
                    temp.ExpandAll();
                    if (temp.Nodes.Count == 0)
                    {
                        return;
                    }
                    temp = temp.Nodes[0];
                    temp.ExpandAll();

                    LoadHistory(temp);
                });
            })
            { IsBackground = true }.Start();
        }

        /// <summary>
        /// 加载历史
        /// </summary>
        private void LoadHistory(TreeNode treeNode)
        {
            if (treeNode == null)
            {
                return;
            }

            var node = (DateTreeNode)treeNode.Tag;
            if (node.ParentYear == 0)
            {
                return;
            }

            list.Clear();

            var history = ColorHistory.Get(node.Path);
            if (history == null || history.Length == 0)
            {
                return;
            }

            new Thread(() =>
            {
                ListViewGroup group = null;
                var groupTime = DateTime.MinValue;
                foreach (var item in history.OrderByDescending(item => item.DateTime))
                {
                    if (group == null || groupTime != item.DateTime.Date)
                    {
                        group = new ListViewGroup(item.DateTime.ToString("yyyy-MM-dd"));
                        this.InvokeMethod(() =>
                        {
                            list.Groups.Add(group);
                        });
                        groupTime = item.DateTime.Date;
                    }
                    this.InvokeMethod(() =>
                    {
                        list.Items.Add(RenderItem(item, group));
                    });
                }
            })
            { IsBackground = true }.Start();
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
                ToolTipText = string.Format(resources.GetString("historyTipTpl"),
                    history.DateTime, '\n', history.Source == 0 ?
                    resources.GetString("screen") : resources.GetString("colorPicker"))
            };
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            LoadTree();
        }

        private void linkHex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var item = sender as LinkLabel;
            // ReSharper disable once PossibleNullReferenceException
            Util.SetClipboard(Handle, item.Text);
        }

        private void linkRgb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var item = sender as LinkLabel;
            // ReSharper disable once PossibleNullReferenceException
            Util.SetClipboard(Handle, item.Text);
        }

        private void tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            LoadHistory(e.Node);
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
