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
        public static async Task< RemovePageTransportResponseModel > RemovePage (RemovePageTransportRequestModel model)
        {
            try
            {                
                DbContext db = new DbContext();
               
                await db.Pages.DeleteOneAsync(X => X.Id==new ObjectId(model.PageId));

                return new RemovePageTransportResponseModel(true);
            }
            catch
            {
                return new RemovePageTransportResponseModel(false);
            }
        }
    }
}
