using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PressGatherer.References.TransportModels.Security;

namespace PressGatherer.WebApi.ServiceClients.Interfaces
{
    public interface IApiServiceClient
    {
        Task<LoginTransportResponseModel> Login(LoginTransportRequestModel credential);
    }
}
