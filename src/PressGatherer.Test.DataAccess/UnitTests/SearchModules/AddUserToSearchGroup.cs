using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.Exceptions;
using PressGatherer.References.TransportModels.SearchModules;
using System;
using System.Threading.Tasks;

namespace PressGatherer.Test.DataAccess
{
    [TestClass]
    public class AddUserToSearchGroup
    {
        [TestMethod]
        public async Task AddUserToSearchGroup_Successful()
        {
            string searchGroupId = await GetSearchGroupId();
            string userId = await PGAccessForTest.GetFirstUserId();
            var model = new AddUserToSearchGroupTransportRequestModel(searchGroupId,userId);
            var result = await PGAccess.AddUserToSearchGroup(model);
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public async Task AddUserToSearchGroup_Failed_NoSearchGroup()
        {
            try
            {
                string searchGroupId = "";
                string userId = await PGAccessForTest.GetFirstUserId();
                var model = new AddUserToSearchGroupTransportRequestModel(searchGroupId, userId);
                var result = await PGAccess.AddUserToSearchGroup(model);
                Assert.Fail();
            }
            catch (MissingSearchGroupAtAddUserToSearchGroup) { }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task AddUserToSearchGroup_Failed_NoUser()
        {
            try
            {
                string searchGroupId = await GetSearchGroupId();
                string userId = "";
                var model = new AddUserToSearchGroupTransportRequestModel(searchGroupId, userId);
                var result = await PGAccess.AddUserToSearchGroup(model);
                Assert.Fail();
            }
            catch (MissingUserAtAddUserToSearchGroup) { }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task AddUserToSearchGroup_Failed_DuplicateUser()
        {
            try
            {
                string searchGroupId = await GetSearchGroupId();
                string userId = await PGAccessForTest.GetFirstUserId();
                var model = new AddUserToSearchGroupTransportRequestModel(searchGroupId, userId);
                var result = await PGAccess.AddUserToSearchGroup(model);
                var resultAgain = await PGAccess.AddUserToSearchGroup(model);
                Assert.Fail();
            }
            catch (DuplicateUserExceptionAtAddUserToSearchGroup) { }
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
