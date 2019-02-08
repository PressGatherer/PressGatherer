using PressGatherer.References.TransportModels.ArticleModules;
using System;
using System.Collections.Generic;
using System.Text;

namespace PressGatherer.Services.ServiceEntities
{
    public class XPathValues
    {
        public string ArticleContent { get; set; }


        public XPathValues()
        {
            this.ArticleContent = "";
        }

        public XPathValues(string articleContent)
        {
            this.ArticleContent = articleContent;
        }

        public XPathValues(GetPageForScanResponseModel pageData)
        {
            this.ArticleContent = pageData.ArticleContentXPath;
        }
    }
}