using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using HtmlAgilityPack;
using PressGatherer.BusinessLogic.ArticleModules;
using PressGatherer.References.Exceptions;
using PressGatherer.References.TransportModels.ArticleModules;
using PressGatherer.Services.ServiceEntities;

namespace PressGatherer.Services
{
    public class IndexService : BaseService
    {
        public IndexService () : base("5c4b9ea7def9de06c81eb8a2")
        {}

        public override ArticleToLoad LoadContentFromArticle(ArticleToLoad article)
        {
            var document = new HtmlDocument();
            string innerHtmlContent = "";
            document.LoadHtml(article.HtmlContent);

            var divsWithClass = document.DocumentNode.SelectNodes("//div/@class");
            foreach (var node in divsWithClass)
            {
                if (node.GetAttributeValue("class", "") == "cikk-torzs")
                {
                    document.LoadHtml(node.InnerHtml);

                    document.DocumentNode.Descendants()
                                    .Where(n => n.Name == "SCRIPT" || n.Name == "STYLE" || n.Name == "script" || n.Name == "style" || n.Name == "#comment")
                                    .ToList()
                                    .ForEach(n => n.Remove());
                    innerHtmlContent = document.DocumentNode.InnerHtml;
                    break;
                }
            }

            article.Content = RemoveEmptyLines(StripHTML(innerHtmlContent));
            return article;
        }
    }
}
