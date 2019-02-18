namespace PressGatherer.References.TransportModels.SearchModules
{
    public class DeleteSearchGroupTransportRequestModel
    {
        public string SearchGroupId { get; set; }

        public DeleteSearchGroupTransportRequestModel(string searchGroupId)
        {
            this.SearchGroupId = searchGroupId;
        }
    }
}
