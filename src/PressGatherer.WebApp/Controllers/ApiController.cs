using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PressGatherer.References.TransportModels.Security;
using PressGatherer.WebApi.Modules.Implementations;
using PressGatherer.WebApi.Modules.Interfaces;
using PressGatherer.WebApi.ServiceClients.Implementations;

namespace PressGatherer.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IApiModule _pressGathererModule;

        //public ApiController(IApiModule pressGathererModule)
        public ApiController()
        {
            //_pressGathererModule = pressGathererModule;
            _pressGathererModule = new ApiModule(new ApiServiceClient());
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<string> Login([FromBody]LoginTransportRequestModel credentials)
        {
            return await _pressGathererModule.Login(credentials);
        }
    }
}