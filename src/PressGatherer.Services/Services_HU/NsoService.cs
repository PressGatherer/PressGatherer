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
    public class NsoService : BaseService
    {
        public NsoService() : base("5c5a970cf4ab9051ac0ba7f9")
        {}

        public override List<ArticleToLoad> ParseSearchPage()
        {
            List<ArticleToLoad> response = new List<ArticleToLoad>();

            var document = new HtmlDocument();
            document.LoadHtml(this.SearchPageContent.Content);

            var ulsWithClass = document.DocumentNode.SelectNodes("//ul/@class");
            foreach (var node in ulsWithClass)
            {
                if (node.GetAttributeValue("class", "") == "hir24")
                {
                    document.LoadHtml(node.InnerHtml);
                    var hrefs = document.DocumentNode.SelectNodes("//a");
                    foreach (var href in hrefs)
                    {
                        string link = "http://www.nemzetisport.hu" 
                                    + href.GetAttributeValue("href", "");
                        response.Add(new ArticleToLoad(this.PageId, link));
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

            var psWithClass = document.DocumentNode.SelectNodes("//p/@class");
            foreach (var node in psWithClass)
            {
                if (node.GetAttributeValue("class", "") == "lead")
                {
                    article.Description = node.InnerHtml;
                    break;
                }
            }

            var divsWithClass = document.DocumentNode.SelectNodes("//div/@class");
            foreach (var node in divsWithClass)
            {
                if (node.GetAttributeValue("class", "") == "cikkbody clearfix")
                {
                    document.LoadHtml(node.InnerHtml);
                    innerHtmlContent = document.DocumentNode.InnerHtml;
                    break;
                }
            }

            article.Content = RemoveEmptyLines(StripHTML(innerHtmlContent));

            if (article.Content.StartsWith("Hirdetés"))
                article.Content = article.Content.Substring(8);

            return article;
        }
    }
}
