using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PressGatherer.References.TransportModels.SearchModules;
using PressGatherer.References.Enums;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;

namespace PressGatherer.DataAccess.DataAccessLayer
{
    public partial class PGAccess
    {
        public static async Task<CreateSearchGroupTransportResponseModel> CreateSearchGroup(CreateSearchGroupTransportRequestModel model)
        {
            try
            {
                DbContext db = new DbContext();

                List<SearchGroupAccess> groupAccesseList = new List<SearchGroupAccess>
                {
                    new SearchGroupAccess
                    {
                        AccessType = UserAccessTypeEnum.Admin,
                        UserId = model.UserId,
                        UserName = model.UserName
                    }
                };

                List<SearchWord> searchWordList = new List<SearchWord>
                {
                    new SearchWord
                    {
                        Word = model.Word,
                        Order = model.Order,
                    }
                };

                SearchGroup group = new SearchGroup
                {
                    CreatedDate = DateTime.UtcNow,
                    SearchWords = searchWordList,
                    Users = groupAccesseList,
                    LastChangedDate = DateTime.UtcNow,
                };

                await db.SearchGroups.InsertOneAsync(group);

                return new CreateSearchGroupTransportResponseModel(group.Id.ToString());
            }
            catch
            {
                return new CreateSearchGroupTransportResponseModel();
            }
        }
    }
}

