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
        public static async Task<bool> CheckArticle(string pageId, string link)
        {
            return await PGAccess.CheckArticle(pageId, link);
        }
    }
}
