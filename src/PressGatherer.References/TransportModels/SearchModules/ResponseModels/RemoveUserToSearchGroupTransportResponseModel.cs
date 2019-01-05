namespace PressGatherer.References.TransportModels.SearchModules
{
    public class RemoveUserToSearchGroupTransportResponseModel
    {
        public bool Success { get; set; }

        public RemoveUserToSearchGroupTransportResponseModel()
        {
            Success = false;
        }

        public RemoveUserToSearchGroupTransportResponseModel(bool success)
        {
            Success = success;
        }
    }
}
