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
    public class ModifyUserOnSearchGroup
    {
        [TestMethod]
        public async Task ModifyUserOnSearchGroup_Successful()
        {
            string searchGroupId = await GetSearchGroupId();
            string userId = await PGAccessForTest.GetFirstUserId();
            var addUserModel = new AddUserToSearchGroupTransportRequestModel(searchGroupId, userId);
            await SearchDriver.AddUserToSearchGroup(addUserModel);
            var model = new ModifyUserOnSearchGroupTransportRequestModel(searchGroupId, userId, References.Enums.UserAccessTypeEnum.Admin);
            var result = await SearchDriver.ModifyUserOnSearchGroup(model);
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public async Task ModifyUserOnSearchGroup_Failed_NoSearchGroup()
        {
            try
            {
                string searchGroupId = "";
                string userId = await PGAccessForTest.GetFirstUserId();
                var addUserModel = new AddUserToSearchGroupTransportRequestModel(searchGroupId, userId);
                await SearchDriver.AddUserToSearchGroup(addUserModel);
                var model = new ModifyUserOnSearchGroupTransportRequestModel(searchGroupId, userId, References.Enums.UserAccessTypeEnum.Admin);
                var result = await SearchDriver.ModifyUserOnSearchGroup(model);
                Assert.Fail();
            }
            catch (MissingSearchGroupException) { }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task ModifyUserOnSearchGroup_Failed_MissingUser()
        {
            try
            {
                string searchGroupId = await GetSearchGroupId();
                string userId = "";
                var model = new ModifyUserOnSearchGroupTransportRequestModel(searchGroupId, userId, References.Enums.UserAccessTypeEnum.Admin);
                var result = await SearchDriver.ModifyUserOnSearchGroup(model);
                Assert.Fail();
            }
            catch (MissingUserException) { }
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
