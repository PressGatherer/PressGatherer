using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGatherer.BusinessLogic.SearchModules;
using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.TransportModels.SearchModules;
using PressGatherer.References.Exceptions;
using System;
using System.Threading.Tasks;

namespace PressGatherer.Test.BusinessLogic
{
    [TestClass]
    public class RefreshStatusUpdateInSearchGroup
    {
        [TestMethod]
        public async Task RefreshStatudUpdate_Successful()
        {
            string searchGroupId = await GetSearchGroupId();

            var model = new RefreshStatusUpdateInSearchGroupTransportRequestModel(searchGroupId, 9);
            var result = await SearchDriver.RefreshStatusUpdateInSearchGroup(model);
            Assert.IsTrue(result.IsSuccesful);
        }


        [TestMethod]
        public async Task RefreshStatudUpdate_MissingSearchGroupId()
        {
            try
            {
                var model = new RefreshStatusUpdateInSearchGroupTransportRequestModel("", 9);
                var result = await SearchDriver.RefreshStatusUpdateInSearchGroup(model);
                Assert.Fail();
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
