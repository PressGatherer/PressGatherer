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
    public class DeleteSearchGroup
    {

        [TestMethod]
        public async Task DeleteSearchGroup_Successfull()
        {

            var searchGroupId = await GetSearchGroupId();

            var deleteSearchGroup = new DeleteSearchGroupTransportRequestModel(searchGroupId);
            var result = await SearchDriver.DeleteSearchGroup(deleteSearchGroup);

            Assert.IsTrue(result.IsSuccesful);
        }

        [TestMethod]
        public async Task DeleteSearchGroup_MissingSearchGroupId()
        {
            try
            {
                var deleteSearchGroup = new DeleteSearchGroupTransportRequestModel("");
                var result = await SearchDriver.DeleteSearchGroup(deleteSearchGroup);
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
