using NUnit.Framework;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using System;

namespace WebCrawler.Core.Tests
{
    public class WebCrawlerTest
    {
        [TestCase("https://news.ycombinator.com/",10)]
        public void TestExtractEntries(string url, int countentries)
        {
            var request = new Request(url);
            string html = request.DownloadHtml();
            XmlDocument XmlDoc = Transform.HtmltoXML(html);
            var webCrawler = new WebCrawler(XmlDoc, countentries);
            int ExtractedEntries = webCrawler.Entries.Count;
            Console.WriteLine(string.Format("{0} ExtractEntries", ExtractedEntries));
            Assert.That(ExtractedEntries, Is.EqualTo(countentries));
        }

        [TestCase("https://news.ycombinator.com/", 30, "WordsinTitle > 5", "Comments Asc")]
        [TestCase("https://news.ycombinator.com/", 50, "WordsinTitle <= 5", "Score Desc")]
        public void TestFilterEntries(string url, int countentries, string filterExpression, string sortExpression)
        {
            var request = new Request(url);
            string html = request.DownloadHtml();
            XmlDocument XmlDoc = Transform.HtmltoXML(html);
            var webCrawler = new WebCrawler(XmlDoc, countentries);
            IEnumerable<Entry> filterEntries = webCrawler.filterEntries(filterExpression, sortExpression);

            foreach (Entry entry in filterEntries)
            {
                Console.WriteLine(string.Format("NumberOrder: {0} Title: {1} Points: {2} Comments: {3}", entry.NumberOrder, entry.Title, entry.Score, entry.Comments));
            }
            
            Assert.That(filterEntries, !Is.Null);
        }
    }
}