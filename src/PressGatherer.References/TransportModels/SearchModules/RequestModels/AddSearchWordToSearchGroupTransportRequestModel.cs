namespace PressGatherer.References.TransportModels.SearchModules
{
    public class AddSearchWordToSearchGroupTransportRequestModel
    {
        public string SearchGroupId { get; set; }
        public string Word { get; set; }
        public int Order { get; set; }
        public AddSearchWordToSearchGroupTransportRequestModel(string searchGroupId, string word, int order)
        {
            this.SearchGroupId = searchGroupId;
            this.Word = word;
            this.Order = order;
        }
    }
}
