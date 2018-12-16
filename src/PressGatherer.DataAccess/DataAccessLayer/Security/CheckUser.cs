using MongoDB.Bson;
using MongoDB.Driver;
using PressGatherer.References.Logics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressGatherer.DataAccess.DataAccessLayer
{
    public partial class PGAccess
    {
        public static async Task<bool> CheckUser (string userName, string hashedPassword)
        {
            try
            {
                DbContext db = new DbContext();
                var users = await db.Users.Find(x => x.Login.LoginName == userName && x.Validation.Validated)
                                            .Project<PGUser>("{login.hashedPassword : 1, login.salt : 1}")
                                            .ToListAsync();

                PGUser user = users.Single();

                if (HashLogics.ConfirmPassword(
                        hashedPassword, 
                        Encoding.UTF8.GetBytes(user.Login.HashedPassword), 
                        user.Login.Salt
                        )
                   )
                {
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
