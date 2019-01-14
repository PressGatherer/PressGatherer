using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.Exceptions;
using PressGatherer.References.TransportModels.ArticleModules;
using System;
using System.Threading.Tasks;

namespace PressGatherer.Test.DataAccess
{
    [TestClass]
    public class RemovePage
    {
        [TestMethod]
        public async Task RemovePage_Successful()
        {
            var createPageModel = new CreatePageTransportRequestModel("NewTestPage_" + DateTime.UtcNow.ToString(), "http://test.com", "http://test.com", "http://test.com");
            var createPageResult = await PGAccess.CreatePage(createPageModel);
            var result = await PGAccess.RemovePage(new RemovePageTransportRequestModel(createPageResult.PageId));
            Assert.IsTrue(result.Removed);
        }
        

        [TestMethod]
        public async Task RemovePage_Failed_PageNotExists()
        {
            try
            {
                var result = await PGAccess.RemovePage(new RemovePageTransportRequestModel(""));
                Assert.Fail();
            }
            catch (NoPageExistsAtRemovePageException) { }
            catch
            {
                Assert.Fail();
            }
        }
    }
}
