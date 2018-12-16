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
        public static async Task<CreatePageTransportResponseModel> CreatePage (CreatePageTransportRequestModel model)
        {
            try
            {                
                DbContext db = new DbContext();

                Page page = new Page
                {
                    AddedDate = DateTime.UtcNow,
                    BaseLink = model.BaseLink,
                    Name = model.Name,
                    RssLink = model.RssLink,
                    SearchLink = model.SearchLink
                };

                await db.Pages.InsertOneAsync(page);

                return new CreatePageTransportResponseModel(page.Id.ToString());
            }
            catch
            {
                return new CreatePageTransportResponseModel();
            }
        }
    }
}
