﻿using MongoDB.Bson;
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
        public static async Task<bool> CheckAuthenticated(AuthTransportRequestModel request)
        {
            bool response = await PGAccess.CheckAuthenticated(request);
            return response;
        }
    }
}
