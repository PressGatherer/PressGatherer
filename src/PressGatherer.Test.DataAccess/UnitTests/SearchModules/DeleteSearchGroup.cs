using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.TransportModels.SearchModules;
using System.Threading.Tasks;
using PressGatherer.References.Exceptions;

namespace PressGatherer.Test.DataAccess
{
    [TestClass]
    public class DeleteSearchGroup
    {

        [TestMethod]
        public async Task DeleteSearchGroup_Successful()
        {

            string searchGroupId = await GetSearchGroupId();

            var deleteSearchGroup = new DeleteSearchGroupTransportRequestModel(searchGroupId);
            bool result = await PGAccess.DeleteSearchGroup(deleteSearchGroup);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task DeleteSearchGroup_MissingSearchGroupId()
        {
            try
            {
                var deleteSearchGroup = new DeleteSearchGroupTransportRequestModel("");
                var result = await PGAccess.DeleteSearchGroup(deleteSearchGroup);
            }
            catch (MissingSearchGroupException) { }
            catch
            {
                Assert.Fail();
            }
        }

        public async Task<string> GetSearchGroupId()
        {
            var userid = PGAccessForTest.GetFirstUserId();
            var model = new CreateSearchGroupTransportRequestModel("Test_", userid.Result);
            var result = await PGAccess.CreateSearchGroup(model);
            return result.SearchGroupId;
        }
    }


}