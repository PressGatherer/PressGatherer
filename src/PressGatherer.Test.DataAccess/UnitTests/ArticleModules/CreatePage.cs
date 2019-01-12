using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.Exceptions;
using PressGatherer.References.TransportModels.ArticleModules;
using System;

namespace PressGatherer.Test.DataAccess
{
    [TestClass]
    public class CreatePage
    {
        [TestMethod]
        public void CreatePage_Successful()
        {
            var model = new CreatePageTransportRequestModel("NewTestPage_" + DateTime.UtcNow.ToString(), "http://test.com", "http://test.com", "http://test.com");
            var result = PGAccess.CreatePage(model);
            Assert.AreNotEqual("", result.Result.PageId);
        }

        [TestMethod]
        public void CreatePage_Failed_EmptyName()
        {
            try
            {
                var model = new CreatePageTransportRequestModel("", "http://test.com", "http://test.com", "http://test.com");
                var result = PGAccess.CreatePage(model);
                Assert.Fail();
            }
            catch (MissingNameAtCreatingPageException) { }
            catch
            {
                Assert.Fail();
            }
        }
    }
}
