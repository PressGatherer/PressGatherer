using MongoDB.Driver;
using PressGatherer.References.TransportModels.SearchModules;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PressGatherer.DataAccess.DataAccessLayer
{
    public partial class PGAccess
    {
        public static async Task<ModifyUserOnSearchGroupTransportResponseModel> ModifyUserOnSearchGroup(ModifyUserOnSearchGroupTransportRequestModel model)
        {
            try
            {
                DbContext db = new DbContext();

                var group = await db.SearchGroups.Find(x => x.GroupName == model.GroupName).SingleAsync();

                if (group.Users.Where(x => x.UserId == model.UserId).Count() == 1)
                {
                    group.Users
                        .Where(x => x.UserId == model.UserId)
                        .Single()
                        .AccessType = model.UserAccessType;

                    await db.SearchGroups.ReplaceOneAsync(x => x.GroupName == model.GroupName, group);
                }

                return new ModifyUserOnSearchGroupTransportResponseModel(true);
            }
            catch
            {
                return new ModifyUserOnSearchGroupTransportResponseModel();
            }
        }
    }
}
