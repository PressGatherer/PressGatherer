using MongoDB.Driver;
using PressGatherer.DataAccess;

namespace PressGatherer.DataAccess
{
    public class DbContext
    {
        public const string DATABASE_NAME = "pg";
        public const string USERS_COLLECTION_NAME = "pgusers";
        public const string SEARCHGROUPS_COLLECTION_NAME = "searchgroups";
        public const string ARTICLES_COLLECTION_NAME = "articles";
        public const string PAGES_COLLECTION_NAME = "pages";

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

        public IMongoCollection<SearchGroup> SearchGroups
        {
            get { return _database.GetCollection<SearchGroup>(SEARCHGROUPS_COLLECTION_NAME); }
        }

        public IMongoCollection<Article> Articles
        {
            get { return _database.GetCollection<Article>(ARTICLES_COLLECTION_NAME); }
        }

        public IMongoCollection<Page> Pages
        {
            get { return _database.GetCollection<Page>(PAGES_COLLECTION_NAME); }
        }
    }
}