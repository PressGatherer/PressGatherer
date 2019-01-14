using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PressGatherer.References.TransportModels.SearchModules;
using PressGatherer.References.Enums;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;
using PressGatherer.References.Exceptions;

namespace PressGatherer.DataAccess.DataAccessLayer
{
    public partial class PGAccess
    {
        public static async Task<CreateSearchGroupTransportResponseModel> CreateSearchGroup(CreateSearchGroupTransportRequestModel model)
        {
            if (string.IsNullOrWhiteSpace(model.GroupName))
            {
                throw new MissingTitleException();
            }

            if (string.IsNullOrWhiteSpace(model.UserId))
            {
                throw new MissingUserException();
            }

            DbContext db = new DbContext();

            List<SearchGroupAccess> searchGroupAccessesList = new List<SearchGroupAccess>
            {
                new SearchGroupAccess
                {
                    UserId = model.UserId,
                    AccessType = UserAccessTypeEnum.Admin
                }
            };

            SearchGroup group = new SearchGroup
            {
                CreatedDate = DateTime.UtcNow,
                GroupName = model.GroupName,
                SearchWords = new List<SearchWord>(),
                Users = searchGroupAccessesList,
                Accessibility = SearchGroupAccessibilityEnum.Private,
                RefreshStatus = new RefreshStatus
                {
                    Rate = RefreshRateEnum.EveryDay,
                    LastRefreshed = DateTime.UtcNow
                },
                LastChangedDate = DateTime.UtcNow,
            };

            await db.SearchGroups.InsertOneAsync(group);

            return new CreateSearchGroupTransportResponseModel(group.Id.ToString());
        }
    }
}

