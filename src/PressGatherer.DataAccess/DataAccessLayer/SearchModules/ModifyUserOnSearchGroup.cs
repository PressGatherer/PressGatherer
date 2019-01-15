using MongoDB.Bson;
using MongoDB.Driver;
using PressGatherer.References.Exceptions;
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
            var response = new ModifyUserOnSearchGroupTransportResponseModel();

            if (string.IsNullOrWhiteSpace(model.GroupId))
            {
                throw new MissingSearchGroupException();
            }

            if (string.IsNullOrWhiteSpace(model.UserId))
            {
                throw new MissingUserException();
            }

            DbContext db = new DbContext();

            var objectId = new ObjectId(model.GroupId);
            var find = await db.SearchGroups.FindAsync(x => x.Id.Equals(objectId));
            var group = await find.SingleOrDefaultAsync();

            if (group != null)
            {
                if (group.Users.Count(x => x.UserId == model.UserId) == 1)
                {
                    group.Users
                        .Where(x => x.UserId == model.UserId)
                        .Single()
                        .AccessType = model.UserAccessType;

                    await db.SearchGroups.ReplaceOneAsync(x => x.GroupName == model.GroupId, group);
                    response.Success = true;
                }                
            }

            return response;
        }
    }
}
