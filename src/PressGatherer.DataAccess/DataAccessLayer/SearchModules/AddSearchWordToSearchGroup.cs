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
        public static async Task<bool> AddSearchWord(AddSearchWordToSearchGroupTransportRequestModel model)
        {
            try
            {
                DbContext db = new DbContext();

                string Id = "";

                var findSearchGroup = await db.SearchGroups.Find(x => x.Id == new ObjectId(Id)).ToListAsync();

                var response = findSearchGroup.Single();

                List<SearchWord> searchWords = response.SearchWords.ToList();
                searchWords.Add(new SearchWord { Word = model.Word, Order = model.Order });
                response.SearchWords = searchWords;

                await db.SearchGroups.ReplaceOneAsync(x => x.Id == new ObjectId(Id), response);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
