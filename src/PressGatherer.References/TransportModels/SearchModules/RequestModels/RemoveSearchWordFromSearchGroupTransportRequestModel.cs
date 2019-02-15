namespace PressGatherer.References.TransportModels.SearchModules
{
    public class RemoveSearchWordFromSearchGroupTransportRequestModel
    {

        public string SearchGroupId { get; set; }
        public string Word { get; set; }
        public RemoveSearchWordFromSearchGroupTransportRequestModel(string searchGroupId, string word)
        {
            this.SearchGroupId = searchGroupId;
            this.Word = word;
        }
    }
}
