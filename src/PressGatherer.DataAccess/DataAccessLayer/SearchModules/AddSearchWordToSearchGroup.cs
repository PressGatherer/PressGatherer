using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using PressGatherer.References.TransportModels.SearchModules;

namespace PressGatherer.DataAccess.DataAccessLayer
{
    public partial class PGAccess
    {
        public static async Task<bool> AddSearchWordToSearchGroup(AddSearchWordToSearchGroupTransportRequestModel model)
        {
            try
            {
                DbContext db = new DbContext();

                SearchWord wordToAdd = new SearchWord { Word = model.Word, Order = model.Order };

                var filter = Builders<SearchGroup>.Filter.Eq(e => e.Id, new ObjectId(model.SearchGroupId));
                var update = Builders<SearchGroup>.Update.Push<SearchWord>(e => e.SearchWords, wordToAdd);
                await db.SearchGroups.FindOneAndUpdateAsync(filter, update);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
