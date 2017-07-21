using System.Net;
using System.Xml;

namespace WebCrawler.Core
{
    public class Request
    {
        public string Url { get; set; }

        public Request(string url)
        {
            Url = url;
        }

        public string DownloadHtml()
        {
            using (WebClient wc = new WebClient())
            {
                return wc.DownloadString(this.Url);
            }
        }
    }
}
