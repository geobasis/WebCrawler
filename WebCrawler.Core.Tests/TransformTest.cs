using System;
using NUnit.Framework;
using System.Xml;

namespace WebCrawler.Core.Tests
{
    public class TransformTest
    {
        [TestCase("https://news.ycombinator.com/")]
        public void TestTransformHtmltoXML(string url)
        {
            var request = new Request(url);
            string html = request.DownloadHtml();
            XmlDocument XmlDoc = Transform.HtmltoXML(html);
            Assert.That(XmlDoc, !Is.Null);
        }
    }
}