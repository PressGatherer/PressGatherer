using MongoDB.Bson;
using MongoDB.Driver;
using PressGatherer.References.Logics;
using PressGatherer.References.TransportModels.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressGatherer.DataAccess.DataAccessLayer
{
    public partial class PGAccessForTest
    {
        public static async Task<string> GetRandomUserId(List<string> excludedUsers)
        {
            try
            {
                DbContext db = new DbContext();
                var users = await db.Users.Find(x => !excludedUsers.Exists(y => y == x.Id.ToString())).Limit(1).ToListAsync();

                PGUser user = users.Single();

                return user.Id.ToString();
            }
            catch
            {
                return "";
            }
        }

        public static async Task<string> GetRandomUserId(string excludeUser)
        {
            return await GetRandomUserId(new List<string> { excludeUser });
        }
    }
}
