using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PressGatherer.References.Enums;
using PressGatherer.References.TransportModels.ArticleModules;
using System;
using System.Collections.Generic;

namespace PressGatherer.DataAccess
{
    public class ArticlePage
    {
        [BsonElement("id")]
        public string PageId { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("link")]
        public string BaseLink { get; set; }

        ArticlePage(ArticlePageTransportModel model)
        {
            this.PageId = model.PageId;
            this.Title = model.Title;
            this.BaseLink = model.BaseLink;
        }
    }

}
