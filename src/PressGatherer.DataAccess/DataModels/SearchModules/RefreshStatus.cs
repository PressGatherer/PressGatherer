using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PressGatherer.References.Enums;
using System;

namespace PressGatherer.DataAccess
{
    public class RefreshStatus
    {
        [BsonElement("lastRefreshed")]
        public DateTime LastRefreshed { get; set; }

        [BsonElement("rate")]
        public RefreshRateEnum Rate { get; set; }
    }
}
