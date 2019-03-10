using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.Exceptions;
using PressGatherer.References.TransportModels.SearchModules;
using System;
using System.Threading.Tasks;

namespace PressGatherer.Test.DataAccess
{
    [TestClass]
    public class RefreshStatusUpdateInSearchGroup
    {
        [TestMethod]
        public async Task RefreshStatudUpdate_Successful()
        {
            string searchGroupId = await GetSearchGroupId();

            var model = new RefreshStatusUpdateInSearchGroupTransportRequestModel(searchGroupId, 9);
            var result = await PGAccess.RefreshStatusUpdateInSearchGroup(model);
            Assert.IsTrue(result);
        }


        [TestMethod]
        public async Task RefreshStatudUpdate_MissingSearchGroupId()
        {
            try
            {
                var model = new RefreshStatusUpdateInSearchGroupTransportRequestModel("", 9);
                bool result = await PGAccess.RefreshStatusUpdateInSearchGroup(model);
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
            var model = new CreateSearchGroupTransportRequestModel("Test_" + DateTime.UtcNow.ToString(), userid.Result);
            var result = await PGAccess.CreateSearchGroup(model);

            return result.SearchGroupId;
        }
    }
}
