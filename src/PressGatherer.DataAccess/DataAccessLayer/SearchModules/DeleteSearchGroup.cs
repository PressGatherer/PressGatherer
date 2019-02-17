using MongoDB.Bson;
using MongoDB.Driver;
using PressGatherer.References.Exceptions;
using PressGatherer.References.TransportModels.SearchModules;
using System.Linq;
using System.Threading.Tasks;

namespace PressGatherer.DataAccess.DataAccessLayer
{
    public partial class PGAccess
    {
        public static async Task<bool> DeleteSearchGroup(DeleteSearchGroupTransportRequestModel model)
        {

            if (string.IsNullOrWhiteSpace(model.SearchGroupId))
            {
                throw new MissingSearchGroupException();
            }

            DbContext db = new DbContext();

            try
            {
                SearchGroup group = (await db.SearchGroups.Find(x => x.Id == new ObjectId(model.SearchGroupId)).ToListAsync()).Single();
                await db.SearchGroups.DeleteOneAsync(x => x.Id == group.Id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
