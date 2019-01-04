using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.TransportModels.SearchModules;
using System.Threading.Tasks;

namespace PressGatherer.BusinessLogic.SearchModules
{
    public partial class SearchDriver
    {
        public static async Task<AddUserToSearchGroupTransportResponseModel> AddUserToSearchGroup(AddUserToSearchGroupTransportRequestModel request)
        {
            AddUserToSearchGroupTransportResponseModel response = new AddUserToSearchGroupTransportResponseModel();

            response = await PGAccess.AddUserToSearchGroup(request);

            return response;
        }
    }
}
