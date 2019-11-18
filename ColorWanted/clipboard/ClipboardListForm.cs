using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ColorWanted.clipboard
{
    public partial class ClipboardListForm : Form
    {
        private static ClipboardListForm instance;
        private static ClipboardTreeNode TreeData;
        private const int SIZE = 16;

        private int start;
        private TreeNode CurrentNode;

        public static void Open()
        {
            if (instance != null)
            {
                return;
            }
            instance = new ClipboardListForm();
            instance.ShowDialog();
        }
        public ClipboardListForm()
        {
            InitializeComponent();
        }

        private void FillList(TreeNode node, bool clear = true)
        {
            if (node != null && node.Nodes.Count > 0)
            {
                return;
            }
            if (clear)
            {
                start = 0;
                list.Controls.Clear();
            }
            if (node == null)
            {
                return;
            }
            CurrentNode = node;
            btnMore.Enabled = false;
            btnMore.Text = "加载中...";
            var treeData = (ClipboardTreeNode)node.Tag;
            var data = ClipboardManager.Load(treeData.AbsolutePath);

            var items = data.Select(item => new ClipboardCtrl(item)
            {
                OnRemove = RemoveClipboardData
            }).OrderByDescending(ctrl => ctrl.Date).Skip(start).Take(SIZE).ToArray();
            start += SIZE;

            btnMore.Enabled = start < data.Count();
            btnMore.Text = btnMore.Enabled ? "加载更多" : "没有更多了";

            list.Controls.AddRange(items);
            list.Update();
            Application.DoEvents();
            GC.Collect();
        }

        private void ClipboardListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void ClipboardListForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                FillList(treeDate.SelectedNode);
            }
        }

        private void RemoveClipboardData(ClipboardCtrl ctrl, string filename)
        {
            ClipboardManager.Remove(filename);
            list.Controls.Remove(ctrl);
            list.Update();
        }

        private void BtnMore_Click(object sender, System.EventArgs e)
        {
            this.FillList(treeDate.SelectedNode, false);
        }

        private void ClipboardListForm_Load(object sender, EventArgs e)
        {
            // 加载树
            TreeData = new ClipboardTreeNode(ClipboardManager.DataRoot);
            foreach (var item in TreeData.Items)
            {
                var node = new TreeNode(item.Name)
                {
                    Tag = item
                };
                treeDate.Nodes.Add(node);
                RenderTreeNode(item, node);
            }
            if (TreeData.Items.Length == 0)
            {
                return;
            }
            // 打开今天的节点
            var today = DateTime.Now;
            var yearNode = treeDate.Nodes[0];
            if (((ClipboardTreeNode)yearNode.Tag).Value != today.Year)
            {
                return;
            }
            if (yearNode.Nodes.Count == 0)
            {
                return;
            }
            yearNode.ExpandAll();
            var monthNode = yearNode.Nodes[0];

            if (((ClipboardTreeNode)monthNode.Tag).Value != today.Month)
            {
                return;
            }
            if (monthNode.Nodes.Count == 0)
            {
                return;
            }
            monthNode.ExpandAll();
            var dayNode = monthNode.Nodes[0];
            if (((ClipboardTreeNode)dayNode.Tag).Value != today.Day)
            {
                return;
            }
            treeDate.SelectedNode = dayNode;
            this.FillList(dayNode, true);
        }

        private void RenderTreeNode(ClipboardTreeNode cNode, TreeNode tNode)
        {
            foreach (var item in cNode.Items)
            {
                var node = new TreeNode(item.Name)
                {
                    Tag = item
                };
                tNode.Nodes.Add(node);

                RenderTreeNode(item, node);
            }
        }

        private void treeDate_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (CurrentNode == e.Node)
            {
                return;
            }
            // 加载这一天的记录
            this.FillList(e.Node, true);
        }
    }
}
