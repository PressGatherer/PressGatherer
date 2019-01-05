using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGatherer.BusinessLogic.Security;
using PressGatherer.References.TransportModels.Security;

namespace PressGatherer.Test.BusinessLogic
{
    [TestClass]
    public class RegisterUser
    {
        [TestMethod]
        public void RegisterUser_Successful()
        {
            var model = new RegisterTransportRequestModel("UserName", "Password", "username@username.com", "Full Username");
            var result = SecurityDriver.RegisterUser(model);   
            Assert.AreNotEqual("", result.Result.UserId);
        }

        [TestMethod]
        public void RegisterUser_Failed_Duplicate()
        {
            var model = new RegisterTransportRequestModel("UserName", "Password", "username@username.com", "Full Username");
            var result = SecurityDriver.RegisterUser(model);
            model = new RegisterTransportRequestModel("UserName", "Password", "username@username.com", "Full Username");
            result = SecurityDriver.RegisterUser(model);
            Assert.AreEqual("", result.Result.UserId);
        }

        [TestMethod]
        public void RegisterUser_Failed_MissingName()
        {
            var model = new RegisterTransportRequestModel("", "Password", "username@username.com", "Full Username");
            var result = SecurityDriver.RegisterUser(model);
            Assert.AreEqual("", result.Result.UserId);
        }

        [TestMethod]
        public void RegisterUser_Failed_MissingPassword()
        {
            var model = new RegisterTransportRequestModel("UserName", "", "username@username.com", "Full Username");
            var result = SecurityDriver.RegisterUser(model);
            Assert.AreEqual("", result.Result.UserId);
        }

        [TestMethod]
        public void RegisterUser_Failed_MissingEmail()
        {
            var model = new RegisterTransportRequestModel("UserName", "Password", "", "Full Username");
            var result = SecurityDriver.RegisterUser(model);
            Assert.AreEqual("", result.Result.UserId);
        }
    }
}
