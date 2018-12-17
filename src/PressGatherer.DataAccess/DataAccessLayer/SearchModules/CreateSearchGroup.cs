using System;
using System.Threading.Tasks;
using PressGatherer.References.TransportModels.SearchModules;

namespace PressGatherer.DataAccess.DataAccessLayer
{
    public partial class PGAccess
    {

        public static async Task<CreateSearchGroupTransportResponseModel> CreateSearchGroup(CreateSearchGroupTransportRequestModel model)
        {
            try
            {
                DbContext db = new DbContext();

                SearchGroup group = new SearchGroup

                {
                    CreatedDate = DateTime.UtcNow,
                    GroupName = model.GroupName,
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

