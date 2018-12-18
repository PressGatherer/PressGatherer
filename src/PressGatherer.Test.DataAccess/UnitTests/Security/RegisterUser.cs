using Microsoft.VisualStudio.TestTools.UnitTesting;
using PressGatherer.DataAccess.DataAccessLayer;
using PressGatherer.References.TransportModels.Security;

namespace PressGatherer.Test.DataAccess
{
    [TestClass]
    public class RegisterUser
    {
        [TestMethod]
        public void RegisterUser_Successful()
        {
            var model = new RegisterTransportRequestModel("UserName", "Password", "username@username.com", "Full Username");
            var result = PGAccess.RegisterUser(model);
            Assert.AreNotEqual("", result.Result.UserId);
        }

        [TestMethod]
        public void RegisterUser_Failed_Duplicate()
        {
            var model = new RegisterTransportRequestModel("UserName", "Password", "username@username.com", "Full Username");
            var result = PGAccess.RegisterUser(model);
            model = new RegisterTransportRequestModel("UserName", "Password", "username@username.com", "Full Username");
            result = PGAccess.RegisterUser(model);
            Assert.AreEqual("", result.Result.UserId);
        }

        [TestMethod]
        public void RegisterUser_Failed_MissingName()
        {
            var model = new RegisterTransportRequestModel("", "", "", "");
            var result = PGAccess.RegisterUser(model);
            Assert.AreEqual("", result.Result.UserId);
        }
    }
}
