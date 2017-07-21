# WebCrawler
Project that download, transform, extract and filter News Entries from de web

The process of search news from web https://news.ycombinator.com/ contains the next steps:
1. Download Html as String using WebClient
2. Transform Html to XML, deleting and replacing the tags content with problems to load Html in a XML document
3. Extract data and create entries, navigating in the document with the XPath
4. FilterEntries with use of System.Linq.Dynamic dll, that can use filter and Sort Expressions as string input.
