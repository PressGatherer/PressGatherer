using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.TransportModels.SearchModules;
using System.Threading.Tasks;

namespace PressGatherer.BusinessLogic.SearchModules
{
    public partial class SearchDriver
    {
        public static async Task<RemoveSearchWordFromSearchGroupTransportResponseModel> RemoveSearchWordFromSearchGroup(RemoveSearchWordFromSearchGroupTransportRequestModel request)
        {
            bool isRemoveWordSuccessfull = await PGAccess.RemoveSearchWordFromSearchGroup(request);

            if (isRemoveWordSuccessfull)
            {
                return new RemoveSearchWordFromSearchGroupTransportResponseModel(true);
            }
            return new RemoveSearchWordFromSearchGroupTransportResponseModel(false);
        }
    }
}
