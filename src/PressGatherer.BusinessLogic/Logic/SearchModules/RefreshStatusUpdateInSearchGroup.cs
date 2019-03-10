using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.TransportModels.SearchModules;
using System.Threading.Tasks;

namespace PressGatherer.BusinessLogic.SearchModules
{
    public partial class SearchDriver
    {
        public static async Task<RefreshStatusUpdateInSearchGroupTransportResponseModel> RefreshStatusUpdateInSearchGroup (RefreshStatusUpdateInSearchGroupTransportRequestModel request)
        {
            bool isRemoveWordSuccessfull = await PGAccess.RefreshStatusUpdateInSearchGroup(request);

            if (isRemoveWordSuccessfull)
            {
                return new RefreshStatusUpdateInSearchGroupTransportResponseModel(true);
            }
            return new RefreshStatusUpdateInSearchGroupTransportResponseModel(false);
        }
    }
}
