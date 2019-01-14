using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.Exceptions;
using PressGatherer.References.TransportModels.SearchModules;
using System;
using System.Threading.Tasks;

namespace PressGatherer.Test.DataAccess
{
    [TestClass]
    public class CreateSearchGroup
    {
        [TestMethod]
        public async Task CreateSearchGroup_Successful()
        {
            var userId = await PGAccessForTest.GetFirstUserId();
            var model = new CreateSearchGroupTransportRequestModel("Test", userId);
            var result = await PGAccess.CreateSearchGroup(model);
            Assert.AreNotEqual("", result.SearchGroupId);
        }

        [TestMethod]
        public async Task CreateSearchGroup_Failed_NoUser()
        {
            try
            {
                var model = new CreateSearchGroupTransportRequestModel("Test", "");
                var result = await PGAccess.CreateSearchGroup(model);
                Assert.Fail();
            }
            catch (MissingUserException) { }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task CreateSearchGroup_Failed_NoTitle()
        {
            try
            {
                var userId = await PGAccessForTest.GetFirstUserId();
                var model = new CreateSearchGroupTransportRequestModel("", userId);
                var result = await PGAccess.CreateSearchGroup(model);
                Assert.Fail();
            }
            catch (MissingTitleException) { }
            catch
            {
                Assert.Fail();
            }
        }
    }
}
