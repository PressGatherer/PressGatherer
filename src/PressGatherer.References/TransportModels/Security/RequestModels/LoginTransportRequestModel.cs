
namespace PressGatherer.References.TransportModels.Security
{
    public class LoginTransportRequestModel
    {
        public string UserName { get; set; }

        public string HashedPassword { get; set; }

        public LoginTransportRequestModel(string userName, string hashedPassword)
        {
            this.HashedPassword = hashedPassword;
            this.UserName = userName;
        }
    }
}
