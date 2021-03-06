﻿using MongoDB.Bson;
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
        public static async Task SetLastScan(string id, DateTime date)
        {             
            DbContext db = new DbContext();

            var filter = Builders<Page>.Filter.Eq(e => e.Id, new ObjectId(id));
            var update = Builders<Page>.Update.Set(e => e.LastScanDate, date);
            await db.Pages.FindOneAndUpdateAsync(filter, update);
        }
    }
}
