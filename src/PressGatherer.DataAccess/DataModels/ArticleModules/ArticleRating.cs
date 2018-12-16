using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PressGatherer.References.Enums;
using System;
using System.Collections.Generic;

namespace PressGatherer.DataAccess
{
    public class ArticleRating
    {
        [BsonElement("userId")]
        public string UserId { get; set; }

        [BsonElement("userName")]
        public string UserName { get; set; }

        [BsonElement("ratingType")]
        public RatingTypeEnum RatingType { get; set; }

        [BsonElement("value")]
        public int Value { get; set; }
    }
}
