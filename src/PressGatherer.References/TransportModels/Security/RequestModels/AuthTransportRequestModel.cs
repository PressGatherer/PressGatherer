
namespace PressGatherer.References.TransportModels.Security
{
    public class AuthTransportRequestModel
    {
        public string UserId { get; set; }

        public string AuthToken { get; set; }

        public AuthTransportRequestModel(string userId, string authToken)
        {
            this.AuthToken = authToken;
            this.UserId = userId;
        }
    }
}
