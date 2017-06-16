namespace ColorWanted.update
{
    internal class CommitItem
    {
        public string sha { get; set; }
        public string url { get; set; }
        public FileItem[] files { get; set; }
    }
}
