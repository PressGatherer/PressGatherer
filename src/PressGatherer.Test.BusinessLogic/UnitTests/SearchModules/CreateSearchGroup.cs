using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGatherer.BusinessLogic.SearchModules;
using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.TransportModels.SearchModules;
using PressGatherer.References.Exceptions;
using System;

namespace PressGatherer.Test.BusinessLogic
{
    [TestClass]
    public class CreateSearchGroup
    {
        [TestMethod]
        public void CreateSearchGroup_Successful()
        {
            var userid = PGAccessForTest.GetFirstUserId();
            var model = new CreateSearchGroupTransportRequestModel("Test", userid.Result);
            var result = SearchDriver.CreateSearchGroup(model);
            Assert.AreNotEqual("", result.Result.SearchGroupId);
        }

        [TestMethod]
        public void CreateSearchGroup_Failed_NoUser()
        {
            try
            {
                var model = new CreateSearchGroupTransportRequestModel("Test", "");
                var result = SearchDriver.CreateSearchGroup(model);
                Assert.Fail();
            }
            catch (MissingUserAtCreatingSearchGroupException) { }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void CreateSearchGroup_Failed_NoTitle()
        {
            try
            {
                var userid = PGAccessForTest.GetFirstUserId();
                var model = new CreateSearchGroupTransportRequestModel("", userid.Result);
                var result = SearchDriver.CreateSearchGroup(model);
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
