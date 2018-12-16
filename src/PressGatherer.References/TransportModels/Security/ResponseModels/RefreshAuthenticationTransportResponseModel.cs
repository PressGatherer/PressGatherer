
namespace PressGatherer.References.TransportModels.Security
{
    public class RefreshAuthenticationTransportResponseModel
    {
        public string AuthToken { get; set; }

        public RefreshAuthenticationTransportResponseModel(string authToken)
        {
            this.AuthToken = authToken;
        }
    }
}
