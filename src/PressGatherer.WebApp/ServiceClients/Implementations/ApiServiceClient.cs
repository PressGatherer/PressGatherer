using System;
using System.Security.Authentication;
using System.Threading.Tasks;
using PressGatherer.References.TransportModels.Security;
using PressGatherer.WebApi.ServiceClients.Interfaces;
using PressGatherer.BusinessLogic.Security;

namespace PressGatherer.WebApi.ServiceClients.Implementations
{
    public class ApiServiceClient : IApiServiceClient
    {
        public async Task<LoginTransportResponseModel> Login(LoginTransportRequestModel credential)
        {
            try
            {
                return await SecurityDriver.LoginUser(credential);
            }
            catch (Exception)
            {
                throw new AuthenticationException();
            }
            
        }
    }
}