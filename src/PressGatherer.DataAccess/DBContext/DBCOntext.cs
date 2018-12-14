using MongoDB.Driver;
using PressGatherer.DataAccess;

namespace PressGatherer.DataAccess
{
    public class DbContext
    {
        public const string DATABASE_NAME = "pg";
        public const string USERS_COLLECTION_NAME = "pgusers";

        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;

        static DbContext()
        {
            var connectionString = "mongodb://localhost:27017";
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(DATABASE_NAME);
        }

        public IMongoClient Client
        {
            get { return _client; }
        }

        public IMongoCollection<PGUser> Users
        {
            get { return _database.GetCollection<PGUser>(USERS_COLLECTION_NAME); }
        }
    }
}