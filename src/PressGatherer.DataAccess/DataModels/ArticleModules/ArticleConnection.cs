using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PressGatherer.References.Enums;
using System;
using System.Collections.Generic;

namespace PressGatherer.DataAccess
{
    public class ArticleConnection
    {
        [BsonElement("searchGroupId")]
        public string SearchGroupId { get; set; }

        [BsonElement("relevance")]
        public double Relevance { get; set; }
    }
}
