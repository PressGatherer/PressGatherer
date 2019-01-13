using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGatherer.BusinessLogic.ArticleModules;
using PressGatherer.References.TransportModels.ArticleModules;
using PressGatherer.References.Exceptions;
using System;

namespace PressGatherer.Test.BusinessLogic
{
    [TestClass]
    public class CreatePage
    {
        [TestMethod]
        public async void CreatePage_Successful()
        {
            var model = new CreatePageTransportRequestModel("NewTestPage_" + DateTime.UtcNow.ToString() ,"http://test.com", "http://test.com", "http://test.com");
            var result = await ArticleDriver.CreatePage(model);   
            Assert.AreNotEqual("", result.PageId);
        }

        [TestMethod]
        public async void CreatePage_Failed_EmptyName()
        {
            try
            {
                var model = new CreatePageTransportRequestModel("", "http://test.com", "http://test.com", "http://test.com");
                var result = await ArticleDriver.CreatePage(model);
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
