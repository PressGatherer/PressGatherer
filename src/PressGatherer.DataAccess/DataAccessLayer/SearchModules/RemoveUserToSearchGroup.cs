using MongoDB.Driver;
using PressGatherer.References.Enums;
using PressGatherer.References.TransportModels.SearchModules;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PressGatherer.DataAccess.DataAccessLayer
{
    public partial class PGAccess
    {
        public static async Task<RemoveUserToSearchGroupTransportResponseModel> RemoveUserToSearchGroup(RemoveUserToSearchGroupTransportRequestModel model)
        {
            try
            {
                DbContext db = new DbContext();
                var group = await db.SearchGroups.Find(x => x.GroupName == model.GroupName).SingleAsync();
                group.Users=group.Users.Where(u => u.UserId != model.UserId).ToList();
                group.LastChangedDate = DateTime.UtcNow;
                await db.SearchGroups.ReplaceOneAsync(x => x.GroupName == model.GroupName, group);

                return new RemoveUserToSearchGroupTransportResponseModel(true);
            }
            catch
            {
                return new RemoveUserToSearchGroupTransportResponseModel();
            }
        }
    }
}
