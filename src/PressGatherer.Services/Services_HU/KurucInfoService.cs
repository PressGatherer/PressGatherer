﻿using System;
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
    public class KurucInfoService : BaseService
    {
        public KurucInfoService() : base("5c4d0b81e178ae4ef44dec49")
        {}

        public override ArticleToLoad LoadFullArticle(ArticleToLoad article)
        {
            var encodingInstance = CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(encodingInstance);

            WebClient client = new WebClient();
            client.Encoding = Encoding.GetEncoding("iso-8859-2");
            article.HtmlContent = client.DownloadString(article.Link);

            return article;
        }
    }
}
