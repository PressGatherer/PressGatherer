using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGatherer.BusinessLogic.ArticleModules;
using PressGatherer.References.TransportModels.ArticleModules;
using PressGatherer.References.Exceptions;
using System;

namespace PressGatherer.Test.BusinessLogic
{
    [TestClass]
    public class CreateArticle
    {
        [TestMethod]
        public void CreateArticle_Successful()
        {
            var model = new CreateArticleTransportRequestModel("Title","Description","http://test.com/" + DateTime.UtcNow.ToBinary().ToString(),"Content", "hu-HU");
            var result = ArticleDriver.CreateArticle(model);   
            Assert.AreNotEqual("", result.Result.ArticleId);
        }

        [TestMethod]
        public void CreateArticle_Failed_EmptyTitle()
        {
            try
            {
                var model = new CreateArticleTransportRequestModel("", "Description", "http://test.com/" + DateTime.UtcNow.ToBinary().ToString(), "Content", "hu-HU");
                var result = ArticleDriver.CreateArticle(model);
                Assert.Fail();
            }
            catch (MissingTitleAtCreatingArticleException) { }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void CreateArticle_Failed_EmptyLink()
        {
            try
            {
                var model = new CreateArticleTransportRequestModel("Title", "Description", "", "Content", "hu-HU");
                var result = ArticleDriver.CreateArticle(model);
                Assert.Fail();
            }
            catch (MissingTitleAtCreatingArticleException) { }
            catch
            {
                Assert.Fail();
            }
        }
    }
}
