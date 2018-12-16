
namespace PressGatherer.References.TransportModels.Security
{
    public class RegisterTransportRequestModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string HashedPassword { get; set; }

        public RegisterTransportRequestModel(string userName, string hashedPassword, string email, string name)
        {
            this.HashedPassword = hashedPassword;
            this.UserName = userName;
            this.Email = email;
            this.Name = name;
        }
    }
}
