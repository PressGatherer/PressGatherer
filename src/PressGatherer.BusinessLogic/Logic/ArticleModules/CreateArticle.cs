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
        public static async Task<CreateArticleTransportResponseModel> CreateArticle(CreateArticleTransportRequestModel request)
        {
            CreateArticleTransportResponseModel response = new CreateArticleTransportResponseModel();

            response = await PGAccess.CreateArticle(request);

            return response;
        }
    }
}
