namespace PressGatherer.References.TransportModels.SearchModules
{
    public class CreateSearchGroupTransportResponseModel
    {
        public string SearchGroupId { get; set; }

        public CreateSearchGroupTransportResponseModel()
        {
            this.SearchGroupId = "";
        }

        public CreateSearchGroupTransportResponseModel(string searchGroupId)
        {
            this.SearchGroupId = searchGroupId;
        }
    }
}
