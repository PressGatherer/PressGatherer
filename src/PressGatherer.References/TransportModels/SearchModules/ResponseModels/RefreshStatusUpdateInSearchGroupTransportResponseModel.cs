namespace PressGatherer.References.TransportModels.SearchModules
{
    public class RefreshStatusUpdateInSearchGroupTransportResponseModel
    {
        public bool IsSuccesful { get; set; }

        public RefreshStatusUpdateInSearchGroupTransportResponseModel(bool isSuccesful)
        {
            this.IsSuccesful = isSuccesful;
        }
    }
}
