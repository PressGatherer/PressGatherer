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

            var group = await db.SearchGroups.Find(x => x.Id == new ObjectId(model.SearchGroupId)).SingleAsync();

            group.SearchWords = group.SearchWords.Where(x => x.Word != model.Word);

            await db.SearchGroups.ReplaceOneAsync(x => x.Id == new ObjectId(model.SearchGroupId), group);
            return true;

        }
    }
}
