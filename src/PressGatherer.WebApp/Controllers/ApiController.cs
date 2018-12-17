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
        private readonly IApiModule _apiModule;

        public ApiController(IApiModule pressGathererModule)
        {
            _apiModule = pressGathererModule;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<string> Login([FromBody]LoginTransportRequestModel credentials)
        {
            return await _apiModule.Login(credentials);
        }
    }
}