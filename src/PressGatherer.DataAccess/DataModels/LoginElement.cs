using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PressGatherer.DataAccess
{
    public class LoginElement
    {
        [BsonElement("loginName")]
        public string LoginName { get; set; }

        [BsonElement("hashedPassword")]
        public string HashedPassword { get; set; }

        [BsonElement("salt")]
        public string Salt { get; set; }

        [BsonElement("lastLogonDate")]
        public DateTime LastLogonDate { get; set; }
    }
}
