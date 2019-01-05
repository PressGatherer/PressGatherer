namespace PressGatherer.References.TransportModels.SearchModules
{
    public class AddUserToSearchGroupTransportResponseModel
    {
        public bool Success { get; set; }

        public AddUserToSearchGroupTransportResponseModel()
        {
            Success = false;
        }

        public AddUserToSearchGroupTransportResponseModel(bool success)
        {
            Success = success;
        }
    }
}
