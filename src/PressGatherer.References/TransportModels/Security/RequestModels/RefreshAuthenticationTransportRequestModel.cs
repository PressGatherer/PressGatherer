
namespace PressGatherer.References.TransportModels.Security
{
    public class RefreshAuthenticationTransportRequestModel
    {
        public string UserId { get; set; }

        public string RefreshToken { get; set; }

        public RefreshAuthenticationTransportRequestModel(string userId, string refreshToken)
        {
            this.RefreshToken = refreshToken;
            this.UserId = userId;
        }
    }
}
