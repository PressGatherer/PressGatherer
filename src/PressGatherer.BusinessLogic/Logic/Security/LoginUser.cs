using MongoDB.Bson;
using MongoDB.Driver;
using PressGatherer.DataAccess;
using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.TransportModels.Security;
using System.Linq;
using System.Threading.Tasks;

namespace PressGatherer.BusinessLogic.Security
{
    public partial class SecurityDriver
    {
        public static async Task<LoginTransportResponseModel> LoginUser (LoginTransportRequestModel request)
        {
            var response = new LoginTransportResponseModel();

            if (await PGAccess.CheckUser(request.UserName, request.HashedPassword))
            {
                response = await PGAccess.AuthenticateUser(request.UserName);
            }

            return response;
        }
    }
}
