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
    public class HvgService : BaseService
    {
        public HvgService() : base("5c5ad6873206f7235c0397f0")
        {}

        public override ArticleToLoad LoadContentFromArticle(ArticleToLoad article)
        {
            var document = new HtmlDocument();
            string innerHtmlContent = "";
            document.LoadHtml(article.HtmlContent);

            var divsWithClass = document.DocumentNode.SelectNodes("//div/@class");
            if (divsWithClass == null)
                return article;

            foreach (var node in divsWithClass)
            {
                if (node.GetAttributeValue("class", "") == "article-content entry-contents")
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
