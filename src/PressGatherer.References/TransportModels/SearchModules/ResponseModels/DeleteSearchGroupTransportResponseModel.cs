namespace PressGatherer.References.TransportModels.SearchModules
{
    public class DeleteSearchGroupTransportResponseModel
    {
        public bool IsSuccesful { get; set; }

        public DeleteSearchGroupTransportResponseModel(bool isSuccesful)
        {
            this.IsSuccesful = isSuccesful;
        }
    }
}
