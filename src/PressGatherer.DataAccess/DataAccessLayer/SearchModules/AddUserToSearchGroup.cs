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
        public static async Task<AddUserToSearchGroupTransportResponseModel> AddUserToSearchGroup(AddUserToSearchGroupTransportRequestModel model)
        {
            try
            {
                DbContext db = new DbContext();

                var group = await db.SearchGroups.Find(x => x.GroupName == model.GroupName).SingleAsync();

                if (!group.Users.Any(x => x.UserId == model.UserId))
                {
                    var user = new SearchGroupAccess
                    {
                        UserId = model.UserId,
                        AccessType = UserAccessTypeEnum.View
                    };

                    group.Users.Append(user);
                    group.LastChangedDate = DateTime.UtcNow;

                    await db.SearchGroups.ReplaceOneAsync(x => x.GroupName == model.GroupName, group);
                }

                return new AddUserToSearchGroupTransportResponseModel(true); //still true if already exists?
            }
            catch
            {
                return new AddUserToSearchGroupTransportResponseModel();
            }
        }
    }
}
