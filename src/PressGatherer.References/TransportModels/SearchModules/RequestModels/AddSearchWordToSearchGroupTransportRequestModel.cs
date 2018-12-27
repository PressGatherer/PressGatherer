namespace PressGatherer.References.TransportModels.SearchModules
{
    public class AddSearchWordToSearchGroupTransportRequestModel
    {
        public string Word { get; set; }
        public int Order { get; set; }
        public AddSearchWordToSearchGroupTransportRequestModel(string word, int order, string groupName)
        {
            this.Word = word;
            this.Order = order;
        }
    }
}
