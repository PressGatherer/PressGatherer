using MongoDB.Bson;
using MongoDB.Driver;
using PressGatherer.DataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace PressGatherer.DataAccess.DataAccessLayer
{
    public partial class PGAccess
    {
        public static async Task<PGUser> GetUser (string id)
        {
            PGUser returnvalue = new PGUser();

            DbContext db = new DbContext();
            var users = await db.Users.Find(x => x.Id == new ObjectId(id))
                                        .Project<PGUser>("{name : 1, type : 1}")
                                        .ToListAsync();
            returnvalue = users.Single();

            return returnvalue;
        }
    }
}
