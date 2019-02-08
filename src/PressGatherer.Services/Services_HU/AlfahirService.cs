using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
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
    public class AlfahirService : BaseService
    {
        public AlfahirService() : base("5c5d4ea9e001eb0860ac92b5")
        {}

        public override ArticleToLoad LoadMetaFromArticle(ArticleToLoad article)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(article.HtmlContent);

            var list = doc.DocumentNode.SelectNodes("//meta/@content/@property");
            foreach (var node in list)
            {
                if (node.GetAttributeValue("property", "") == "og:title")
                    article.Title = HttpUtility.HtmlDecode(node.GetAttributeValue("content", ""));
                if (node.GetAttributeValue("property", "") == "og:image")
                    article.ImageLink = node.GetAttributeValue("content", "");
            }
            return article;
        }
    }
}
