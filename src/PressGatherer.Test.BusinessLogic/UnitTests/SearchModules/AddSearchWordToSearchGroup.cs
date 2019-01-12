using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGatherer.BusinessLogic.SearchModules;
using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.TransportModels.SearchModules;
using PressGatherer.References.Exceptions;
using System;

namespace PressGatherer.Test.BusinessLogic
{
    [TestClass]
    public class AddSearchWordToSearchGroup
    {
        [TestMethod]
        public void AddSearchWordToSearchGroup_Successful()
        {
            string searchGroupId = GetSearchGroupId();
            var model = new AddSearchWordToSearchGroupTransportRequestModel(searchGroupId, "word",0);
            var result = SearchDriver.AddSearchWordToSearchGroup(model);
            Assert.IsTrue(result.Result.IsSuccesful);
        }

        [TestMethod]
        public void AddSearchWordToSearchGroup_Failed_NoSearchGroup()
        {
            try
            {
                string searchGroupId = "";
                var model = new AddSearchWordToSearchGroupTransportRequestModel(searchGroupId, "word", 0);
                var result = SearchDriver.AddSearchWordToSearchGroup(model);
                Assert.Fail();
            }
            catch (MissingSearchGroupAtAddSearchWordToSearchGroup) { }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void AddSearchWordToSearchGroup_Failed_NoWord()
        {
            try
            {
                string searchGroupId = GetSearchGroupId();
                var model = new AddSearchWordToSearchGroupTransportRequestModel(searchGroupId, "", 0);
                var result = SearchDriver.AddSearchWordToSearchGroup(model);
                Assert.Fail();
            }
            catch (MissingWordAtAddSearchWordToSearchGroup) { }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void AddSearchWordToSearchGroup_Failed_DuplicateWord()
        {
            try
            {
                string searchGroupId = GetSearchGroupId();
                var model = new AddSearchWordToSearchGroupTransportRequestModel(searchGroupId, "word", 0);
                var result = SearchDriver.AddSearchWordToSearchGroup(model);
                var resultAgain = SearchDriver.AddSearchWordToSearchGroup(model);
                Assert.Fail();
            }
            catch (DuplicateWordExcelption) { }
            catch
            {
                Assert.Fail();
            }
        }

        public string GetSearchGroupId()
        {
            var userid = PGAccessForTest.GetFirstUserId();
            var model = new CreateSearchGroupTransportRequestModel("Test_" + DateTime.UtcNow.ToString(), userid.Result);
            var result = SearchDriver.CreateSearchGroup(model);
            return result.Result.SearchGroupId;
        }
    }
}
