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
        public static async Task<GetPageForScanResponseModel> GetPageForScan(string id)
        {
            try
            {
                DbContext db = new DbContext();

                var pages = await db.Pages.Find(x => x.Id == new ObjectId(id)).ToListAsync();
                var page = pages.Single();

                var response = new GetPageForScanResponseModel
                {
                    PageId = id,
                    RssLink = page.RssLink,
                    SearchLink = page.SearchLink,
                    LastScan = page.LastScanDate,
                    OnLoad = page.OnLoad,
                };

                return response;
            }
            catch
            {
                return new GetPageForScanResponseModel();
            }
        }
    }
}
