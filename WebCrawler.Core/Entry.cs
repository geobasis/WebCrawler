namespace WebCrawler.Core
{
    public struct Entry
    {
        public int NumberOrder { get; set; }
        public string Title { get; set; }
        public int Comments { get; set; }
        public int Score { get; set; }

        private static char[] wordSeparators = new char[] { ' ', '-' };
        public int WordsinTitle => Title.Split(wordSeparators).Length;
        public Entry(int numberOrder, string title, int score, int comments)
        {
            NumberOrder = numberOrder;
            Title = title;
            Score = score;
            Comments = comments;
        }
    }
}
