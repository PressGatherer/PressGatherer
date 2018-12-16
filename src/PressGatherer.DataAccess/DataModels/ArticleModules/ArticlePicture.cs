using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PressGatherer.References.Enums;
using System;
using System.Collections.Generic;

namespace PressGatherer.DataAccess
{
    public class ArticlePicture
    {
        [BsonElement("link")]
        public string Link { get; set; }
    }
}
