using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PressGatherer.References.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PressGatherer.DataAccess
{
    public class Page
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("baseLink")]
        public string BaseLink { get; set; }

        [BsonElement("searchLink")]
        public string SearchLink { get; set; }

        [BsonElement("rssLink")]
        public string RssLink { get; set; }

        [BsonElement("addedDate")]
        public DateTime AddedDate { get; set; }
    }
}
