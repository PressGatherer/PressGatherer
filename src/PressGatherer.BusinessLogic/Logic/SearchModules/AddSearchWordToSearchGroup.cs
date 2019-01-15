using System.Threading.Tasks;
using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.TransportModels.SearchModules;

namespace PressGatherer.BusinessLogic.SearchModules
{
    public partial class SearchDriver
    {
        public static async Task<AddSearchWordToSearchGroupTransportResponseModel> AddSearchWordToSearchGroup(AddSearchWordToSearchGroupTransportRequestModel request)
        {
            bool IsAddWordSuccessful = await PGAccess.AddSearchWordToSearchGroup(request);

            if (IsAddWordSuccessful)
            {
                return new AddSearchWordToSearchGroupTransportResponseModel(true);
            }
            return new AddSearchWordToSearchGroupTransportResponseModel(false);
        }
    }
}