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
        public static async Task SetLastScan(string id)
        {
            await SetLastScan(id, DateTime.UtcNow);
        }

        public static async Task SetLastScan(string id, DateTime date)
        {
            await PGAccess.SetLastScan(id, date);
        }
    }
}
