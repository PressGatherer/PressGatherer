using MongoDB.Bson;
using MongoDB.Driver;
using PressGatherer.References.Enums;
using PressGatherer.References.Logics;
using PressGatherer.References.TransportModels.ArticleModules;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressGatherer.DataAccess.DataAccessLayer
{
    public partial class PGAccess
    {
        public static async Task<bool> CheckArticle(string pageId, string link)
        {
            try
            {
                DbContext db = new DbContext();

                var articles = await db.Articles
                                        .Find(x => x.Page.PageId == pageId && x.Link == link).ToListAsync();
                return articles.Count > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
