using System;
using System.Collections.Generic;
using System.Text;

namespace PressGatherer.References.TransportModels.ArticleModules
{
    public class CreateArticleTransportResponseModel
    {
        public string ArticleId { get; set; }

        public CreateArticleTransportResponseModel()
        {
            this.ArticleId = "";
        }

        public CreateArticleTransportResponseModel(string articleId)
        {
            this.ArticleId = articleId;
        }

    }
}
