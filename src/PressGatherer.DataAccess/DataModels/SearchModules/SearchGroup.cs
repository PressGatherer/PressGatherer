using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PressGatherer.References.Enums;
using System;
using System.Collections.Generic;

namespace PressGatherer.DataAccess
{
    public class SearchGroup
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string GroupName { get; set; }

        [BsonElement("accessibility")]
        public SearchGroupAccessibilityEnum Accessibility { get; set; }

        [BsonElement("searchWords")]
        public IEnumerable<SearchWord> SearchWords { get; set; }

        [BsonElement("users")]
        public IEnumerable<SearchGroupAccess> Users { get; set; }

        [BsonElement("refreshStatus")]
        public RefreshStatus RefreshStatus { get; set; }

        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; }

        [BsonElement("lastChangedDate")]
        public DateTime LastChangedDate { get; set; }
    }
}
