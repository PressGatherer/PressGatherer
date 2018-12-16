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
        public static async Task<RefreshAuthenticationTransportResponseModel> RefreshAuthentication(RefreshAuthenticationTransportRequestModel model)
        {
            try
            {
                DbContext db = new DbContext();
                var users = await db.Users.Find(x => x.Id == new ObjectId(model.UserId)).ToListAsync();
                PGUser user = users.Single();

                if (user.Login.RefreshToken == model.RefreshToken && user.Login.RefreshTokenTimeOut >= DateTime.UtcNow)
                {
                    string authtoken = TokenLogics.GetToken();
                    user.Login.AuthenticationToken = authtoken;
                    DateTime authtokentimeout = DateTime.UtcNow.AddMinutes(10);
                    user.Login.AuthenticationTokenTimeOut = authtokentimeout;
                    user.Login.LastRequestDate = DateTime.UtcNow;

                    await db.Users.ReplaceOneAsync(x => x.Id == user.Id, user);
                    return new RefreshAuthenticationTransportResponseModel(authtoken);
                }
                else
                {
                    return new RefreshAuthenticationTransportResponseModel("");
                }
            }
            catch
            {
                return new RefreshAuthenticationTransportResponseModel("");
            }
        }
    }
}
