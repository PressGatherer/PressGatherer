using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGatherer.BusinessLogic.SearchModules;
using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.TransportModels.SearchModules;
using PressGatherer.References.Exceptions;
using System;
using System.Threading.Tasks;

namespace PressGatherer.Test.BusinessLogic
{
    [TestClass]
    public class AddSearchWordToSearchGroup
    {
        [TestMethod]
        public async void AddSearchWordToSearchGroup_Successful()
        {
            string searchGroupId = await GetSearchGroupId();
            var model = new AddSearchWordToSearchGroupTransportRequestModel(searchGroupId, "word",0);
            var result = await SearchDriver.AddSearchWordToSearchGroup(model);
            Assert.IsTrue(result.IsSuccesful);
        }

        [TestMethod]
        public async void AddSearchWordToSearchGroup_Failed_NoSearchGroup()
        {
            try
            {
                string searchGroupId = "";
                var model = new AddSearchWordToSearchGroupTransportRequestModel(searchGroupId, "word", 0);
                var result = await SearchDriver.AddSearchWordToSearchGroup(model);
                Assert.Fail();
            }
            catch (MissingSearchGroupAtAddSearchWordToSearchGroup) { }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async void AddSearchWordToSearchGroup_Failed_NoWord()
        {
            try
            {
                string searchGroupId = await GetSearchGroupId();
                var model = new AddSearchWordToSearchGroupTransportRequestModel(searchGroupId, "", 0);
                var result = await SearchDriver.AddSearchWordToSearchGroup(model);
                Assert.Fail();
            }
            catch (MissingWordAtAddSearchWordToSearchGroup) { }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async void AddSearchWordToSearchGroup_Failed_DuplicateWord()
        {
            try
            {
                string searchGroupId = await GetSearchGroupId();
                var model = new AddSearchWordToSearchGroupTransportRequestModel(searchGroupId, "word", 0);
                var result = await SearchDriver.AddSearchWordToSearchGroup(model);
                var resultAgain = await SearchDriver.AddSearchWordToSearchGroup(model);
                Assert.Fail();
            }
            catch (DuplicateWordExcelption) { }
            catch
            {
                Assert.Fail();
            }
        }

        public async Task<string> GetSearchGroupId()
        {
            var userid = PGAccessForTest.GetFirstUserId();
            var model = new CreateSearchGroupTransportRequestModel("Test_" + DateTime.UtcNow.ToString(), userid.Result);
            var result = await SearchDriver.CreateSearchGroup(model);
            return result.SearchGroupId;
        }
    }
}
