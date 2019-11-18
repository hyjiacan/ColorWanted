using System.IO;
using System.Linq;

namespace ColorWanted.clipboard
{
    class ClipboardTreeNode
    {
        public string Name { get; private set; }
        public int Value { get; set; }
        public string AbsolutePath { get; private set; }
        public ClipboardTreeNode[] Items { get; private set; }
        public int Level { get; set; }

        public ClipboardTreeNode(string path) : this(path, 0)
        {
        }

        private ClipboardTreeNode(string path, int level)
        {
            this.AbsolutePath = path;
            this.Level = level;
            this.Name = Path.GetFileName(path);
            int.TryParse(this.Name, out int v);
            this.Value = v;
            switch (level)
            {
                case 1:
                    this.Name += "年";
                    break;
                case 2:
                    this.Name += "月";
                    break;
                case 3:
                    this.Name += "日";
                    break;
            }
            var dirs = Directory.GetDirectories(path);
            if (dirs.Length == 0)
            {
                this.Items = new ClipboardTreeNode[0];
                return;
            }
            this.Items = dirs.Select(dir => new ClipboardTreeNode(dir, level + 1))
                .OrderByDescending(node => node.Name).ToArray();
        }
    }
}
