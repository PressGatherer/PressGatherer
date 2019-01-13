using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.Exceptions;
using PressGatherer.References.TransportModels.SearchModules;
using System;

namespace PressGatherer.Test.DataAccess
{
    [TestClass]
    public class CreateSearchGroup
    {
        [TestMethod]
        public async void CreateSearchGroup_Successful()
        {
            var userid = await PGAccessForTest.GetFirstUserId();
            var model = new CreateSearchGroupTransportRequestModel("Test", userid);
            var result = await PGAccess.CreateSearchGroup(model);
            Assert.AreNotEqual("", result.SearchGroupId);
        }

        [TestMethod]
        public async void CreateSearchGroup_Failed_NoUser()
        {
            try
            {
                var model = new CreateSearchGroupTransportRequestModel("Test", "");
                var result = await PGAccess.CreateSearchGroup(model);
                Assert.Fail();
            }
            catch (MissingUserAtCreatingSearchGroupException) { }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async void CreateSearchGroup_Failed_NoTitle()
        {
            try
            {
                var userid = PGAccessForTest.GetFirstUserId();
                var model = new CreateSearchGroupTransportRequestModel("", userid.Result);
                var result = await PGAccess.CreateSearchGroup(model);
                Assert.Fail();
            }
            catch (MissingTitleAtCreatingSearchGroupException) { }
            catch
            {
                Assert.Fail();
            }
        }
    }
}
