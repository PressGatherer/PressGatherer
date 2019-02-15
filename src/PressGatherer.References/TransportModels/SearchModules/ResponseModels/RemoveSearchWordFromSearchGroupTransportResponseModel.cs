namespace PressGatherer.References.TransportModels.SearchModules
{
    public class RemoveSearchWordFromSearchGroupTransportResponseModel
    {
        public bool IsSuccesful { get; set; }
        public RemoveSearchWordFromSearchGroupTransportResponseModel(bool isSuccesful)
        {
            this.IsSuccesful = isSuccesful;
        }
    }
}
