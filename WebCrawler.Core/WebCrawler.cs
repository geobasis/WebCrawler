using System.Collections.Generic;
using System.Xml;
using System.Linq.Dynamic;

namespace WebCrawler.Core
{
    public class WebCrawler
    {
        public XmlDocument Source { get; set; }
        public int CountEntries { get; set; }

        public WebCrawler(XmlDocument source, int countEntries)
        {
            Source = source;
            CountEntries = countEntries;
        }

        private List<Entry> _entries = null;
        public List<Entry> Entries
        {
            get {
                    if(_entries == null)
                    { 
                        _entries = new List<Entry>(CountEntries);
                        XmlNodeList xmlentries = Source.SelectNodes(string.Format("//tr[@class='athing'][position() <= {0}]", CountEntries));

                        foreach (XmlNode entry in xmlentries)
                        {
                            _entries.Add(NodetoEntry(entry));
                        }
                    }
                    return _entries;
                }
        }

        public IEnumerable<Entry> filterEntries(string filterExpression, string sortExpression = null)
        {
            var findEntries = Entries.Where(filterExpression);
            if (!string.IsNullOrEmpty(sortExpression))
                findEntries = findEntries.OrderBy(sortExpression);

            return findEntries;
        }
        private Entry NodetoEntry(XmlNode node)
        {
            string id = node.Attributes["id"].Value;

            string numberOrder = node.SelectSingleNode("*/span[@class='rank']").InnerText;
            string title = node.SelectSingleNode("*/a[@class='storylink']").InnerText;

            XmlNode scoreNode = Source.SelectSingleNode(string.Format("//span[@id='score_{0}']", id));
            string score = (scoreNode == null) ? "0" : scoreNode.InnerText;
            XmlNodeList linknodes = Source.SelectNodes(string.Format("//a[@href='item?id={0}']", id));
            string comments = (linknodes.Count < 2) ? "0" : linknodes[1].InnerText;
            if (!comments.Trim().EndsWith("comments"))
                comments = "0 comments";

            return new Entry(int.Parse(numberOrder.Trim(new char[] { '.' })), title.Trim(), int.Parse(score.Split(' ')[0]), int.Parse(comments.Split(' ')[0]));
        }
    }
}
