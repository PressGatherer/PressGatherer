using MongoDB.Bson;
using MongoDB.Driver;
using PressGatherer.References.Exceptions;
using PressGatherer.References.TransportModels.SearchModules;
using System.Linq;
using System.Threading.Tasks;
using PressGatherer.References.Enums;
using System;

namespace PressGatherer.DataAccess.DataAccessLayer
{
    public partial class PGAccess
    {
        public static async Task<bool> RefreshStatusUpdateInSearchGroup(RefreshStatusUpdateInSearchGroupTransportRequestModel model)
        {
            if (string.IsNullOrWhiteSpace(model.SearchGroupId))
            {
                throw new MissingSearchGroupException();
            }

            DbContext db = new DbContext();

            var refreshStatus = new RefreshStatus
            {
                Rate = (RefreshRateEnum) model.RefreshRateEnum,
                LastRefreshed = DateTime.UtcNow
            };

            var update = Builders<SearchGroup>.Update.Set<RefreshStatus>(x => x.RefreshStatus, refreshStatus);

            await db.SearchGroups.UpdateOneAsync(x => x.Id == new ObjectId(model.SearchGroupId), update);

            return true;
        }
    }
}
