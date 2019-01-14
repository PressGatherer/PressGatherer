using System.Threading.Tasks;
using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.TransportModels.SearchModules;

namespace PressGatherer.BusinessLogic.SearchModules
{
    public partial class SearchDriver
    {
        public static async Task<ModifyUserOnSearchGroupTransportResponseModel> ModifyUserOnSearchGroup(ModifyUserOnSearchGroupTransportRequestModel request)
        {
            var response = new ModifyUserOnSearchGroupTransportResponseModel();

            response = await PGAccess.ModifyUserOnSearchGroup(request);

            return response;
        }
    }
}
