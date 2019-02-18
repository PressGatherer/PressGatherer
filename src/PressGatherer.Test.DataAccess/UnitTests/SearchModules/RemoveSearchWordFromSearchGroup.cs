using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.Exceptions;
using PressGatherer.References.TransportModels.SearchModules;
using PressGatherer.References.TransportModels.Security;
using System;
using System.Threading.Tasks;

namespace PressGatherer.Test.DataAccess
{
    [TestClass]
    public class RemoveSearchWordFromSearchGroup
    {
        [TestMethod]
        public async Task RemoveSearchWordFromSearchGroup_Successfull()
        {

            string searchGroupId = await GetSearchGroupId();

            var addSearchWrodModel = new AddSearchWordToSearchGroupTransportRequestModel(searchGroupId, "test", 0);
            var searchWordAddedResult = await PGAccess.AddSearchWordToSearchGroup(addSearchWrodModel);

            var removeSearchWord = new RemoveSearchWordFromSearchGroupTransportRequestModel(searchGroupId, addSearchWrodModel.Word);
            bool result = await PGAccess.RemoveSearchWordFromSearchGroup(removeSearchWord);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public async Task RemoveSearchWordFromSearchGroup_MissingSearchGroupId()
        {
            var addSearchWrodModel = new AddSearchWordToSearchGroupTransportRequestModel("", "test", 0);
            var searchWordAddedResult = await PGAccess.AddSearchWordToSearchGroup(addSearchWrodModel);
            try
            {
                var removeSearchWord = new RemoveSearchWordFromSearchGroupTransportRequestModel("", addSearchWrodModel.Word);
                bool result = await PGAccess.RemoveSearchWordFromSearchGroup(removeSearchWord);
            }
            catch (MissingSearchGroupException) { }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task RemoveSearchWordFromSearchGroup_MissingSearchWord()
        {

            string searchGroupId = await GetSearchGroupId();

            try
            {
                var removeSearchWord = new RemoveSearchWordFromSearchGroupTransportRequestModel(searchGroupId, "");
                bool result = await PGAccess.RemoveSearchWordFromSearchGroup(removeSearchWord);
            }
            catch (MissingWordException) { }
            catch
            {
                Assert.Fail();
            }
        }

        public async Task<string> GetSearchGroupId()
        {
            var userid = PGAccessForTest.GetFirstUserId();
            var model = new CreateSearchGroupTransportRequestModel("Test_" + DateTime.UtcNow.ToString(), userid.Result);
            var result = await PGAccess.CreateSearchGroup(model);
            return result.SearchGroupId;
        }


    }
}
