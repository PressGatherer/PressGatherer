using MongoDB.Bson;
using MongoDB.Driver;
using PressGatherer.References.Exceptions;
using PressGatherer.References.TransportModels.SearchModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressGatherer.DataAccess.DataAccessLayer
{
    public partial class PGAccess
    {
        public static async Task<bool> RemoveSearchWordFromSearchGroup(RemoveSearchWordFromSearchGroupTransportRequestModel model)
        {

            if (string.IsNullOrWhiteSpace(model.SearchGroupId))
            {
                throw new MissingSearchGroupException();
            }
            if (string.IsNullOrWhiteSpace(model.Word))
            {
                throw new MissingWordException();
            }


            DbContext db = new DbContext();

            var filter = Builders<SearchGroup>.Filter.Eq(e => e.Id, new ObjectId(model.SearchGroupId));

            if (filter != null)
            {
                var update = Builders<SearchGroup>.Update.PullFilter<SearchWord>(p => p.SearchWords, model.Word);
                await db.SearchGroups.FindOneAndUpdateAsync(filter, update);
                return true;
            }

            return false;



        }
    }
}
