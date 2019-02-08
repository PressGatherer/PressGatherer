using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using HtmlAgilityPack;
using PressGatherer.BusinessLogic.ArticleModules;
using PressGatherer.References.Exceptions;
using PressGatherer.References.TransportModels.ArticleModules;
using PressGatherer.Services.ServiceEntities;

namespace PressGatherer.Services
{
    public abstract class BaseService
    {
        public string PageId { get; set; }
        public Rss RssContent { get; set; }
        public SearchPage SearchPageContent { get; set; }
        public XPathValues XPathValues { get; set; }

        public BaseService()
        {
        }

        public BaseService(string pageId)
        {
            this.PageId = pageId;
            RssContent = new Rss();
            SearchPageContent = new SearchPage();
        }

        public virtual async Task LoadNews ()
        {
            if (String.IsNullOrWhiteSpace(this.PageId))
                throw new MissingPageException();

            GetPageForScanResponseModel pageData = await ArticleDriver.GetPageForScan(this.PageId);
            this.XPathValues = new XPathValues(pageData);

            if (!pageData.OnLoad)
            {
                await OnLoadSetToTrue();

                if (!String.IsNullOrWhiteSpace(pageData.RssLink))
                    this.GetRssContent(pageData.RssLink);
                else
                    this.GetSearchPageContent(pageData.SearchLink);

                List<ArticleToLoad> articles = new List<ArticleToLoad>();

                if (!String.IsNullOrEmpty(this.RssContent.Content))
                {
                    articles = ParseRssFile();
                }
                else
                {
                    articles = ParseSearchPage();
                }

                foreach (var a in articles)
                {
                    if (!await ArticleDriver.CheckArticle(this.PageId, a.Link))
                    {
                        var article = LoadFullArticle(a);
                        article = LoadMetaFromArticle(article);
                        article = LoadContentFromArticle(article);
                        CreateArticleTransportRequestModel request = new CreateArticleTransportRequestModel(article.Title, article.Description, article.Link, article.Category, article.Content, article.HtmlContent, article.Culture, article.ImageLink);
                        await ArticleDriver.CreateArticle(request);
                    }
                }

                await SetLastScan();
                await OnLoadSetToFalse();
            }
        }

        public async Task OnLoadSetToTrue()
        {
            await ArticleDriver.SetPageOnLoad(this.PageId, true);
        }

        public async Task OnLoadSetToFalse()
        {
            await ArticleDriver.SetPageOnLoad(this.PageId, false);
        }

        public async Task SetLastScan()
        {
            await ArticleDriver.SetLastScan(this.PageId);
        }

        public virtual void GetRssContent (string rssLink)
        {
            WebClient client = new WebClient();
            this.RssContent = new Rss(client.DownloadString(rssLink));
        }

        public virtual void GetSearchPageContent(string searchPageLink)
        {
            WebClient client = new WebClient();
            this.SearchPageContent = new SearchPage(client.DownloadString(searchPageLink));
        }

        public virtual List<ArticleToLoad> ParseRssFile()
        {
            List<ArticleToLoad> response = new List<ArticleToLoad>();
            XmlDocument rssXmlDoc = new XmlDocument();
            rssXmlDoc.LoadXml(this.RssContent.Content);
            
            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

            foreach (XmlNode rssNode in rssNodes)
            {
                XmlNode rssSubNode = rssNode.SelectSingleNode("link");
                string link = rssSubNode != null ? HttpUtility.HtmlDecode(rssSubNode.InnerText) : "";
                link = link.Split('#')[0];

                rssSubNode = rssNode.SelectSingleNode("title");
                string title = rssSubNode != null ? HttpUtility.HtmlDecode(rssSubNode.InnerText) : "";

                rssSubNode = rssNode.SelectSingleNode("description");
                string description = rssSubNode != null ? HttpUtility.HtmlDecode(rssSubNode.InnerText) : "";

                rssSubNode = rssNode.SelectSingleNode("category");
                string category = rssSubNode != null ? HttpUtility.HtmlDecode(rssSubNode.InnerText) : "";

                rssSubNode = rssNode.SelectSingleNode("pubDate");
                string pubDate = rssSubNode != null ? HttpUtility.HtmlDecode(rssSubNode.InnerText) : "";
                string parseFormat = "ddd, dd MMM yyyy HH:mm:ss zzz";
                DateTime pubDateAsDateTime = DateTime.MinValue;
                try
                {
                    pubDateAsDateTime = DateTime.ParseExact(pubDate, parseFormat, CultureInfo.InvariantCulture);
                }
                catch
                {
                    pubDateAsDateTime = DateTime.UtcNow;
                }

                ArticleToLoad article = new ArticleToLoad(this.PageId, link, title, description, category, pubDateAsDateTime);
                response.Add(article);
            }

            return response;
        }

        public virtual List<ArticleToLoad> ParseSearchPage()
        {
            List<ArticleToLoad> response = new List<ArticleToLoad>();

            return response;
        }

        public virtual ArticleToLoad LoadFullArticle (ArticleToLoad article)
        {
            WebClient client = new WebClient();
            article.HtmlContent = client.DownloadString(article.Link);
            return article;
        }

        public virtual ArticleToLoad LoadMetaFromArticle(ArticleToLoad article)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(article.HtmlContent);

            var list = doc.DocumentNode.SelectNodes("//meta/@content/@property");
            foreach (var node in list)
            {
                if (node.GetAttributeValue("property", "") == "og:title")
                    article.Title = HttpUtility.HtmlDecode(node.GetAttributeValue("content", ""));
                if (node.GetAttributeValue("property", "") == "og:description")
                    article.Description = HttpUtility.HtmlDecode(node.GetAttributeValue("content", ""));
                if (node.GetAttributeValue("property", "") == "og:image")
                    article.ImageLink = node.GetAttributeValue("content", "");
            }
            return article;
        }

        public virtual ArticleToLoad LoadContentFromArticle(ArticleToLoad article)
        {
            var document = new HtmlDocument();
            string innerHtmlContent = "";
            document.LoadHtml(article.HtmlContent);

            var divsWithClass = document.DocumentNode.SelectNodes(this.XPathValues.ArticleContent);
            if (divsWithClass == null)
                return article;

            var node = divsWithClass.First();
            document.LoadHtml(node.InnerHtml);

            document.DocumentNode.Descendants()
                            .Where(n => n.Name == "img" || n.Name == "footer" || n.Name == "SCRIPT" || n.Name == "STYLE" || n.Name == "script" || n.Name == "style" || n.Name == "#comment")
                            .ToList()
                            .ForEach(n => n.Remove());
            innerHtmlContent = document.DocumentNode.InnerHtml;

            article.Content = HttpUtility.HtmlDecode(RemoveEmptyLines(StripHTML(innerHtmlContent))).Trim();
            return article;
        }

        public virtual string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        public virtual string RemoveEmptyLines(string lines)
        {
            string text = Regex.Replace(lines, @"^\s*$\n|\r", " ", RegexOptions.Multiline).TrimEnd();
            text = text.Replace("\n", " ");
            text = text.Replace("&nbsp;", " ");
            text = text.Replace(".", ". ");

            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            text = regex.Replace(text, " ");

            return text;
        }
    }
}
