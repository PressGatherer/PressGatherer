using System.Threading.Tasks;
using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.TransportModels.SearchModules;

namespace PressGatherer.BusinessLogic.SearchModules
{
    public partial class SearchDriver
    {
        public static async Task<AddSearchWordToSearchGroupTransportResponseModel> AddSearchWord(AddSearchWordToSearchGroupTransportRequestModel request)
        {
            bool IsAddWordSuccessful = await PGAccess.AddSearchWord(request);

            if (IsAddWordSuccessful)
            {
                return new AddSearchWordToSearchGroupTransportResponseModel(true);
            }
            return new AddSearchWordToSearchGroupTransportResponseModel(false);
        }
    }
}