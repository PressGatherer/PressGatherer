using MongoDB.Bson;
using MongoDB.Driver;
using PressGatherer.References.Enums;
using PressGatherer.References.Exceptions;
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
            if (string.IsNullOrWhiteSpace(model.GroupId))
            {
                throw new MissingSearchGroupException();
            }
            if (string.IsNullOrWhiteSpace(model.UserId))
            {
                throw new MissingUserException();
            }

            DbContext db = new DbContext();

            var group = await db.SearchGroups.Find(x => x.Id == new ObjectId(model.GroupId)).SingleAsync();

            if (!group.Users.Any(x => x.UserId == model.UserId))
            {
                var userToAdd = new SearchGroupAccess
                {
                    UserId = model.UserId,
                    AccessType = UserAccessTypeEnum.View
                };

                var filter = Builders<SearchGroup>.Filter.Eq(e => e.Id, new ObjectId(model.GroupId));
                var update = Builders<SearchGroup>.Update.Push<SearchGroupAccess>(e => e.Users, userToAdd);
                await db.SearchGroups.FindOneAndUpdateAsync(filter, update);
            }
            else
            {
                throw new DuplicateUserException();
            }

            return new AddUserToSearchGroupTransportResponseModel(true);
        }
    }
}
