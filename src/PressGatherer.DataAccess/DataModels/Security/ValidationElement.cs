using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PressGatherer.DataAccess
{
    public class ValidationElement
    {
        [BsonElement("validationToken")]
        public string ValidationToken { get; set; }

        [BsonElement("validated")]
        public bool Validated { get; set; }
    }
}
