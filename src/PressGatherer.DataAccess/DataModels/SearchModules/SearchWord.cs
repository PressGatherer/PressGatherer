using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PressGatherer.References.Enums;
using System;

namespace PressGatherer.DataAccess
{
    public class SearchWord
    {
        [BsonElement("word")]
        public string Word { get; set; }

        [BsonElement("order")]
        public int Order { get; set; }
    }
}
