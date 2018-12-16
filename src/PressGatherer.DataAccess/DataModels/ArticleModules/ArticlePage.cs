using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PressGatherer.References.Enums;
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
    }
}
