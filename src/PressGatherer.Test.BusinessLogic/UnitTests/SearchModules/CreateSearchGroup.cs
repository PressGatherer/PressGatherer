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
    public class CreateSearchGroup
    {
        [TestMethod]
        public async Task CreateSearchGroup_Successful()
        {
            var userid = PGAccessForTest.GetFirstUserId();
            var model = new CreateSearchGroupTransportRequestModel("Test", userid.Result);
            var result = await SearchDriver.CreateSearchGroup(model);
            Assert.AreNotEqual("", result.SearchGroupId);
        }

        [TestMethod]
        public async Task CreateSearchGroup_Failed_NoUser()
        {
            try
            {
                var model = new CreateSearchGroupTransportRequestModel("Test", "");
                var result = await SearchDriver.CreateSearchGroup(model);
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
                var userid = PGAccessForTest.GetFirstUserId();
                var model = new CreateSearchGroupTransportRequestModel("", userid.Result);
                var result = await SearchDriver.CreateSearchGroup(model);
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
