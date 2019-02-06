using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using HtmlAgilityPack;
using PressGatherer.BusinessLogic.ArticleModules;
using PressGatherer.References.Exceptions;
using PressGatherer.References.TransportModels.ArticleModules;
using PressGatherer.Services.ServiceEntities;

namespace PressGatherer.Services
{
    public class BlikkService : BaseService
    {
        public BlikkService() : base("5c5aaf05f4ab9051ac0ba7fa")
        {}

        public override void GetSearchPageContent(string searchPageLink)
        {
            WebClient client = new WebClient();

            string date = DateTime.UtcNow.ToString("yyyy-MM-dd");

            searchPageLink = String.Format(searchPageLink, date);

            this.SearchPageContent = new SearchPage(client.DownloadString(searchPageLink));
        }

        public override List<ArticleToLoad> ParseSearchPage()
        {
            List<ArticleToLoad> response = new List<ArticleToLoad>();

            var document = new HtmlDocument();
            document.LoadHtml(this.SearchPageContent.Content);

            var divsWithClass = document.DocumentNode.SelectNodes("//div/@class");
            foreach (var node in divsWithClass)
            {
                if (node.GetAttributeValue("class", "") == "archiveBlock")
                {
                    document.LoadHtml(node.InnerHtml);
                    var spansWithClass = document.DocumentNode.SelectNodes("//span/@class");
                    foreach (var node2 in spansWithClass)
                    {
                        if (node2.GetAttributeValue("class", "") == "archiveText")
                        {
                            var document2 = new HtmlDocument();
                            document2.LoadHtml(node2.InnerHtml);
                            var hrefs = document2.DocumentNode.SelectNodes("//a");
                            foreach (var href in hrefs)
                            {
                                string link = href.GetAttributeValue("href", "");
                                response.Add(new ArticleToLoad(this.PageId, link));
                            }

                        }
                    }
                    break;
                }
            }

            return response;
        }

        public override ArticleToLoad LoadContentFromArticle(ArticleToLoad article)
        {
            var document = new HtmlDocument();
            string innerHtmlContent = "";
            document.LoadHtml(article.HtmlContent);

            var divsWithClass = document.DocumentNode.SelectNodes("//div/@itemprop");
            foreach (var node in divsWithClass)
            {
                if (node.GetAttributeValue("itemprop", "") == "articleBody")
                {
                    document.LoadHtml(node.InnerHtml);
                    innerHtmlContent = document.DocumentNode.InnerHtml;
                    break;
                }
            }

            article.Content = RemoveEmptyLines(StripHTML(innerHtmlContent));

            return article;
        }
    }
}
