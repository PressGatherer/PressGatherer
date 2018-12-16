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
    public partial class PGAccess
    {
        public static async Task<bool> CheckAuthenticated(AuthTransportRequestModel model)
        {
            try
            {
                DbContext db = new DbContext();
                var users = await db.Users.Find(x => x.Id == new ObjectId(model.UserId)).ToListAsync();
                PGUser user = users.Single();

                if (user.Login.AuthenticationToken == model.AuthToken && user.Login.AuthenticationTokenTimeOut >= DateTime.UtcNow)
                {
                    user.Login.LastRequestDate = DateTime.UtcNow;
                    await db.Users.ReplaceOneAsync(x => x.Id == user.Id, user);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
