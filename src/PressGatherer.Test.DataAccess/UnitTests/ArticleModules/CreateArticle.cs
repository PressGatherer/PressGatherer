using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.Exceptions;
using PressGatherer.References.TransportModels.ArticleModules;
using System;
using System.Threading.Tasks;

namespace PressGatherer.Test.DataAccess
{
    [TestClass]
    public class CreateArticle
    {
        [TestMethod]
        public async Task CreateArticle_Successful()
        {
            var model = new CreateArticleTransportRequestModel("Title", "Description", "http://test.com/" + DateTime.UtcNow.ToBinary().ToString(), "", "Content", "HtmlContent", "hu-HU");
            var result = await PGAccess.CreateArticle(model);
            Assert.AreNotEqual("", result.ArticleId);
        }

        [TestMethod]
        public async Task CreateArticle_Failed_EmptyTitle()
        {
            try
            {
                var model = new CreateArticleTransportRequestModel("", "Description", "http://test.com/" + DateTime.UtcNow.ToBinary().ToString(), "", "Content", "HtmlContent", "hu-HU");
                var result = await PGAccess.CreateArticle(model);
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
                var result = await PGAccess.CreateArticle(model);
                Assert.Fail();
            }
            catch (MissingTitleException) { }
            catch
            {
                Assert.Fail();
            }
        }
    }
}
