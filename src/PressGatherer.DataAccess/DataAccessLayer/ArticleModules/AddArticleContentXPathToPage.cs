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
        public static async Task AddArticleContentXPathToPage(string pageId, string articleContentXPath)
        {
            try
            {                
                DbContext db = new DbContext();

                var pages = await db.Pages.Find(x => x.Id == new ObjectId(pageId)).ToListAsync();
                var page = pages.Single();

                page.PageLoadSettings = new PageLoadSettings(articleContentXPath);

                await db.Pages.ReplaceOneAsync(x => x.Id == page.Id, page);
            }
            catch
            {
            }
        }
    }
}
