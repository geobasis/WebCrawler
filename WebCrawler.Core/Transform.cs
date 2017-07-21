using System.Text;
using System.Xml;

namespace WebCrawler.Core
{
    public class Transform
    {
        public static XmlDocument HtmltoXML(string html)
        {
            //Transform Html content in a XML document well formed
            StringBuilder XMLBuilder = new StringBuilder(html);

            //Delete the head, form, img, br nodes that contains close tags problems
            RemoveTag(XMLBuilder, "head");
            RemoveTag(XMLBuilder, "form");
            RemoveTag(XMLBuilder, "img", false);
            RemoveTag(XMLBuilder, "img", false);
            XMLBuilder.Replace("<br>", string.Empty);
            XMLBuilder.Replace("&nbsp;", " ");

            //Add <?xml version="1.0" encoding="UTF-8"?> declaration to the start of document
            XMLBuilder.Insert(0, "<?xml version=\"1.0\" encoding=\"UTF - 8\"?>");

            //Load XML document
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(XMLBuilder.ToString());
            return xmlDoc;
        }

        private static void RemoveTag(StringBuilder XMLBuilder, string tag, bool withclosetag = true)
        {
            string html = XMLBuilder.ToString();
            int startIndex = html.IndexOf(string.Format("<{0}",tag));
            int endIndex = (withclosetag) ? html.IndexOf(string.Format("</{0}>", tag), startIndex) + (tag.Length + 3) : html.IndexOf(">", startIndex);

            XMLBuilder.Remove(startIndex, (endIndex - startIndex));
        }
    }
}
