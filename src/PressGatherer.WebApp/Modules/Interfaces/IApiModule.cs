using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PressGatherer.References.TransportModels.Security;

namespace PressGatherer.WebApi.Modules.Interfaces
{
    public interface IApiModule
    {
        Task<string> Login(LoginTransportRequestModel credentials);
    }
}
