namespace ColorWanted.update.git
{
    internal class TagItem
    {
        public string name { get; set; }
        public string zipball_url { get; set; }
        public string tarball_url { get; set; }
        public CommitItem commit { get; set; }
    }
}
