using PressGatherer.References.Enums;

namespace PressGatherer.References.TransportModels.Security
{
    public class RegisterTransportResponseModel
    {
        public string UserId { get; set; }

        public RegisterTransportResponseModel()
        {
            this.UserId = "";
        }

        public RegisterTransportResponseModel(string userId)
        {
            this.UserId = userId;
        }
    }
}
