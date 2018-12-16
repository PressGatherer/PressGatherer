using MongoDB.Bson;
using MongoDB.Driver;
using PressGatherer.References.Enums;
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
        public static async Task<RegisterTransportResponseModel> RegisterUser (RegisterTransportRequestModel model)
        {
            try
            {
                string salt = TokenLogics.GetToken();
                string hashedPassword = Encoding.UTF8.GetString(HashLogics.Hash(model.HashedPassword, salt));
                string validationtoken = TokenLogics.GetToken();
                PGUser user = new PGUser
                {
                    CreatedDate = DateTime.UtcNow,
                    Email = model.Email,
                    LastChangedDate = DateTime.UtcNow,
                    Name = model.Name,
                    Type = UserTypeEnum.Basic,
                    Login = new LoginElement
                    {
                        LoginName = model.UserName,
                        HashedPassword = hashedPassword,
                        Salt = salt,
                        AuthenticationToken = "",
                        RefreshToken = "",
                        AuthenticationTokenTimeOut = DateTime.UtcNow,
                        RefreshTokenTimeOut = DateTime.UtcNow,
                        LastRequestDate = DateTime.UtcNow,
                    },
                    Validation = new ValidationElement
                    {
                        Validated = false,
                        ValidationToken = validationtoken
                    }
                };

                DbContext db = new DbContext();

                await db.Users.InsertOneAsync(user);

                RegisterTransportResponseModel response = new RegisterTransportResponseModel(user.Id.ToString());
                return response;
            }
            catch
            {
                return new RegisterTransportResponseModel();
            }
        }
    }
}
