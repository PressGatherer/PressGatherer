using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.Exceptions;
using PressGatherer.References.TransportModels.ArticleModules;
using System;

namespace PressGatherer.Test.DataAccess
{
    [TestClass]
    public class CreateArticle
    {
        [TestMethod]
        public async void CreateArticle_Successful()
        {
            var model = new CreateArticleTransportRequestModel("Title", "Description", "http://test.com/" + DateTime.UtcNow.ToBinary().ToString(), "Content", "hu-HU");
            var result = await PGAccess.CreateArticle(model);
            Assert.AreNotEqual("", result.ArticleId);
        }

        [TestMethod]
        public async void CreateArticle_Failed_EmptyTitle()
        {
            try
            {
                var model = new CreateArticleTransportRequestModel("", "Description", "http://test.com/" + DateTime.UtcNow.ToBinary().ToString(), "Content", "hu-HU");
                var result = await PGAccess.CreateArticle(model);
                Assert.Fail();
            }
            catch (MissingTitleAtCreatingArticleException) { }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async void CreateArticle_Failed_EmptyLink()
        {
            try
            {
                var model = new CreateArticleTransportRequestModel("Title", "Description", "", "Content", "hu-HU");
                var result = await PGAccess.CreateArticle(model);
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
