
namespace PressGatherer.References.TransportModels.Security
{
    public class ValidateTransportRequestModel
    {
        public string UserName { get; set; }

        public string ValidationToken { get; set; }

        public ValidateTransportRequestModel(string userName, string validationToken)
        {
            this.UserName = userName;
            this.ValidationToken = validationToken;
        }
    }
}
