using System;
using NUnit.Framework;
using System.Xml;

namespace WebCrawler.Core.Tests
{
    public class RequestTest
    {
        [TestCase("https://news.ycombinator.com/")]
        public void TestDownloadHtml(string url)
        {
            var request = new Request(url);
            string content = request.DownloadHtml();
            Console.WriteLine(content);
            Assert.That(content, !Is.Empty);
        }
    }
}