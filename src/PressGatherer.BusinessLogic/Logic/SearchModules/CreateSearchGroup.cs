using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.TransportModels.SearchModules;

namespace PressGatherer.BusinessLogic.ArticleModules
{
    public partial class ArticleDriver
    {
        public static async Task<CreateSearchGroupTransportResponseModel> CreateSearchGroup(CreateSearchGroupTransportRequestModel request)
        {
            CreateSearchGroupTransportResponseModel response = new CreateSearchGroupTransportResponseModel();

            response = await PGAccess.CreateSearchGroup(request);

            return response;
        }
    }
}
