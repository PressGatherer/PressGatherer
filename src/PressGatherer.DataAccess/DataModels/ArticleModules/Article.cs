using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PressGatherer.References.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PressGatherer.DataAccess
{
    public class Article
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("link")]
        public string Link { get; set; }

        [BsonElement("pictures")]
        public IEnumerable<ArticlePicture> Pictures { get; set; }

        [BsonElement("category")]
        public string Category { get; set; }

        [BsonElement("content")]
        public string Content { get; set; }

        [BsonElement("htmlContent")]
        public string HtmlContent { get; set; }

        [BsonElement("culture")]
        public string Culture { get; set; }

        [BsonElement("page")]
        public ArticlePage Page { get; set; }

        [BsonElement("connections")]
        public IEnumerable<ArticleConnection> ArticleConnections { get; set; }

        [BsonElement("ratings")]
        public IEnumerable<ArticleRating> ArticleRatings { get; set; }

        [BsonElement("addedDate")]
        public DateTime AddedDate { get; set; }
    }
}
