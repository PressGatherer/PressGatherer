using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGatherer.BusinessLogic.ArticleModules;
using PressGatherer.References.TransportModels.ArticleModules;
using PressGatherer.References.Exceptions;
using System;
using System.Threading.Tasks;

namespace PressGatherer.Test.BusinessLogic
{
    [TestClass]
    public class RemovePage
    {
        [TestMethod]
        public async Task RemovePage_Successful()
        {
            var createPageModel = new CreatePageTransportRequestModel("NewTestPage_" + DateTime.UtcNow.ToString(), "http://test.com", "http://test.com", "http://test.com");
            var createPageResult = await ArticleDriver.CreatePage(createPageModel);
            var result = await ArticleDriver.RemovePage(new RemovePageTransportRequestModel(createPageResult.PageId));
            Assert.IsTrue(result.Removed);
        }

        [TestMethod]
        public async Task RemovePage_Failed_PageNotExists()
        {
            try
            {
                var result = await ArticleDriver.RemovePage(new RemovePageTransportRequestModel(""));
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
