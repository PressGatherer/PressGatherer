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
        public static async Task<LoginTransportResponseModel> AuthenticateUser(string userName)
        {
            try
            {
                DbContext db = new DbContext();
                var users = await db.Users.Find(x => x.Login.LoginName == userName).ToListAsync();

                PGUser user = users.Single();
                string authtoken = TokenLogics.GetToken();
                string refreshtoken = TokenLogics.GetToken();
                DateTime authtokentimeout = DateTime.UtcNow.AddMinutes(10);
                DateTime refreshtokentimeout = DateTime.UtcNow.AddHours(168);

                user.Login.AuthenticationToken = authtoken;
                user.Login.AuthenticationTokenTimeOut = authtokentimeout;
                user.Login.RefreshToken = refreshtoken;
                user.Login.RefreshTokenTimeOut = refreshtokentimeout;
                user.Login.LastRequestDate = DateTime.UtcNow;

                await db.Users.ReplaceOneAsync(x => x.Id == user.Id, user);

                return new LoginTransportResponseModel(user.Id.ToString(), user.Name, user.Type, authtoken, refreshtoken);
            }
            catch
            {
                return new LoginTransportResponseModel();
            }
        }
    }
}
