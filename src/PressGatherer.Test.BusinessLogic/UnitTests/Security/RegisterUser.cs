using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGatherer.BusinessLogic.Security;
using PressGatherer.References.TransportModels.Security;
using PressGatherer.References.Exceptions;
using System;
using System.Threading.Tasks;

namespace PressGatherer.Test.BusinessLogic
{
    [TestClass]
    public class RegisterUser
    {
        [TestMethod]
        public async Task RegisterUser_Successful()
        {
            var model = new RegisterTransportRequestModel("UserName_" + DateTime.UtcNow.ToString(), "Password", "username@username.com", "Full Username");
            var result = await SecurityDriver.RegisterUser(model);   
            Assert.AreNotEqual("", result.UserId);
        }

        [TestMethod]
        public async Task RegisterUser_Failed_Duplicate()
        {
            try
            {
                var username = "UserName_" + DateTime.UtcNow.ToString();
                var model = new RegisterTransportRequestModel(username, "Password", "username@username.com", "Full Username");
                var result = await SecurityDriver.RegisterUser(model);
                model = new RegisterTransportRequestModel(username, "Password", "username@username.com", "Full Username");
                result = await SecurityDriver.RegisterUser(model);
                Assert.Fail();
            }
            catch (DuplicateUserException) { }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task RegisterUser_Failed_MissingName()
        {
            var model = new RegisterTransportRequestModel("", "Password", "username@username.com", "Full Username");
            var result = await SecurityDriver.RegisterUser(model);
            Assert.AreEqual("", result.UserId);
        }

        [TestMethod]
        public async Task RegisterUser_Failed_MissingPassword()
        {
            var model = new RegisterTransportRequestModel("UserName_" + DateTime.UtcNow.ToString(), "", "username@username.com", "Full Username");
            var result = await SecurityDriver.RegisterUser(model);
            Assert.AreEqual("", result.UserId);
        }

        [TestMethod]
        public async Task RegisterUser_Failed_MissingEmail()
        {
            var model = new RegisterTransportRequestModel("UserName_" + DateTime.UtcNow.ToString(), "Password", "", "Full Username");
            var result = await SecurityDriver.RegisterUser(model);
            Assert.AreEqual("", result.UserId);
        }
    }
}
