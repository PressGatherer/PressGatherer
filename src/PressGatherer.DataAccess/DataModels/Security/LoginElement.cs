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

        [BsonElement("authToken")]
        public string AuthenticationToken { get; set; }

        [BsonElement("authTokenTimeOut")]
        public DateTime AuthenticationTokenTimeOut { get; set; }

        [BsonElement("refToken")]
        public string RefreshToken { get; set; }

        [BsonElement("refTokenTimeOut")]
        public DateTime RefreshTokenTimeOut { get; set; }

        [BsonElement("lastRequestDate")]
        public DateTime LastRequestDate { get; set; }
    }
}
