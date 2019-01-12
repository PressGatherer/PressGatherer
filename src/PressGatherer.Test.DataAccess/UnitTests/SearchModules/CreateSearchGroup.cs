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
        public void CreateSearchGroup_Successful()
        {
            var userid = PGAccessForTest.GetFirstUserId();
            var model = new CreateSearchGroupTransportRequestModel("Test", userid.Result);
            var result = PGAccess.CreateSearchGroup(model);
            Assert.AreNotEqual("", result.Result.SearchGroupId);
        }

        [TestMethod]
        public void CreateSearchGroup_Failed_NoUser()
        {
            try
            {
                var model = new CreateSearchGroupTransportRequestModel("Test", "");
                var result = PGAccess.CreateSearchGroup(model);
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
                var result = PGAccess.CreateSearchGroup(model);
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
