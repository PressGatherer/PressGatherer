using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PressGatherer.References.Enums;
using System;

namespace PressGatherer.DataAccess
{
    public class PGUser
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("login")]
        public LoginElement Login { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("type")]
        public UserTypeEnum Type { get; set; }

        [BsonElement("validation")]
        public ValidationElement Validation { get; set; }

        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; }

        [BsonElement("lastChangedDate")]
        public DateTime LastChangedDate { get; set; }
    }
}
