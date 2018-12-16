using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PressGatherer.References.TransportModels.Security;
using PressGatherer.WebApi.Modules.Interfaces;
using PressGatherer.WebApi.ServiceClients.Interfaces;


namespace PressGatherer.WebApi.Modules.Implementations
{
    public class ApiModule : IApiModule
    {
        private readonly IApiServiceClient _apiServiceClient;

        public ApiModule(IApiServiceClient apiServiceClient)
        {
            _apiServiceClient = apiServiceClient;
        }

        public async Task<string> Login(LoginTransportRequestModel credentials)
        {
            if (string.IsNullOrWhiteSpace(credentials.HashedPassword) ||
                string.IsNullOrWhiteSpace(credentials.HashedPassword))
            {
                throw new AuthenticationException("Invalid credentials.");
            }
            var loginResponse = await _apiServiceClient.Login(credentials);

            if (string.IsNullOrWhiteSpace(loginResponse.AuthenticationToken))
            {
                throw new AuthenticationException("Invalid credentials.");
            }

            return JsonConvert.SerializeObject(loginResponse);
        }
    }
}
