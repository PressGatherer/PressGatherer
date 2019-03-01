using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.TransportModels.SearchModules;
using System.Threading.Tasks;

namespace PressGatherer.BusinessLogic.SearchModules
{
    public partial class SearchDriver
    {
        public static async Task<DeleteSearchGroupTransportResponseModel> DeleteSearchGroup(DeleteSearchGroupTransportRequestModel request)
        {
            bool isDeleteSearchGroupSuccessful = await PGAccess.DeleteSearchGroup(request);

            if (isDeleteSearchGroupSuccessful)
            {
                return new DeleteSearchGroupTransportResponseModel(true);
            }
            return new DeleteSearchGroupTransportResponseModel(false);
        }
    }
}
