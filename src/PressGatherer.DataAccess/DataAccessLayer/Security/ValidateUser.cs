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
        public static async Task<ValidateTransportResponseModel> ValidateUser(ValidateTransportRequestModel model)
        {
            try
            {
                DbContext db = new DbContext();
                var users = await db.Users.Find(x => x.Login.LoginName == model.UserName).ToListAsync();

                PGUser user = users.Single();

                if (user.Validation.Validated)
                    return new ValidateTransportResponseModel(false);

                if (user.Validation.ValidationToken == model.ValidationToken)
                {
                    user.Validation.Validated = true;
                    await db.Users.ReplaceOneAsync(x => x.Id == user.Id, user);
                    return new ValidateTransportResponseModel(true);
                }
                else
                {
                    return new ValidateTransportResponseModel(false);
                }
            }
            catch
            {
                return new ValidateTransportResponseModel(false);
            }
        }
    }
}
