using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.Exceptions;
using PressGatherer.References.TransportModels.ArticleModules;
using System;
using System.Threading.Tasks;

namespace PressGatherer.Test.DataAccess
{
    [TestClass]
    public class CreatePage
    {
        [TestMethod]
        public async Task CreatePage_Successful()
        {
            var model = new CreatePageTransportRequestModel("NewTestPage_" + DateTime.UtcNow.ToString(), "http://test.com", "http://test.com", "http://test.com");
            var result = await PGAccess.CreatePage(model);
            Assert.AreNotEqual("", result.PageId);
        }

        [TestMethod]
        public async Task CreatePage_Failed_EmptyName()
        {
            try
            {
                var model = new CreatePageTransportRequestModel("", "http://test.com", "http://test.com", "http://test.com");
                var result = await PGAccess.CreatePage(model);
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
