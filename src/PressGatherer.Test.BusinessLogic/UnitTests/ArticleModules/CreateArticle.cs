using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGatherer.BusinessLogic.ArticleModules;
using PressGatherer.References.TransportModels.ArticleModules;
using PressGatherer.References.Exceptions;
using System;
using System.Threading.Tasks;

namespace PressGatherer.Test.BusinessLogic
{
    [TestClass]
    public class CreateArticle
    {
        [TestMethod]
        public async Task CreateArticle_Successful()
        {
            var model = new CreateArticleTransportRequestModel("Title","Description","http://test.com/" + DateTime.UtcNow.ToBinary().ToString(),"","Content", "HtmlContent", "hu-HU");
            var result = await ArticleDriver.CreateArticle(model);   
            Assert.AreNotEqual("", result.ArticleId);
        }

        [TestMethod]
        public async Task CreateArticle_Failed_EmptyTitle()
        {
            try
            {
                var model = new CreateArticleTransportRequestModel("", "Description", "http://test.com/" + DateTime.UtcNow.ToBinary().ToString(), "", "Content", "HtmlContent", "hu-HU");
                var result = await ArticleDriver.CreateArticle(model);
                Assert.Fail();
            }
            catch (MissingTitleException) { }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task CreateArticle_Failed_EmptyLink()
        {
            try
            {
                var model = new CreateArticleTransportRequestModel("Title", "Description", "", "", "Content", "HtmlContent", "hu-HU");
                var result = await ArticleDriver.CreateArticle(model);
                Assert.Fail();
            }
            catch (MissingLinkException) { }
            catch
            {
                Assert.Fail();
            }
        }
    }
}
