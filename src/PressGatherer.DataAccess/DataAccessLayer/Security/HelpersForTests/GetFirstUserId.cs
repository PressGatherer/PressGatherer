using MongoDB.Bson;
using MongoDB.Driver;
using PressGatherer.References.Logics;
using PressGatherer.References.TransportModels.Security;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressGatherer.DataAccess.DataAccessLayer
{
    public partial class PGAccessForTest
    {
        public static async Task<string> GetFirstUserId()
        {
            try
            {
                DbContext db = new DbContext();
                var users = await db.Users.Find(x => 1 == 1).Limit(1).ToListAsync();

                PGUser user = users.Single();

                return user.Id.ToString();
            }
            catch
            {
                return "";
            }
        }
    }
}
