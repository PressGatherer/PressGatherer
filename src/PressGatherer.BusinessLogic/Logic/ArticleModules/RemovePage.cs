using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.TransportModels.ArticleModules;

namespace PressGatherer.BusinessLogic.ArticleModules
{
    public partial class ArticleDriver
    {
        public static async Task<RemovePageTransportResponseModel> RemovePage(RemovePageTransportRequestModel model)
        {
            RemovePageTransportResponseModel response = await PGAccess.RemovePage(model);

            return response;
        }
    }
}
