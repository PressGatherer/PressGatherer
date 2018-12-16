using PressGatherer.References.Enums;

namespace PressGatherer.References.TransportModels.Security
{
    public class ValidateTransportResponseModel
    {
        public bool IsSuccesful { get; set; }

        public ValidateTransportResponseModel(bool isSuccesful)
        {
            this.IsSuccesful = isSuccesful;
        }
    }
}
