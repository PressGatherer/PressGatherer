using PressGatherer.References.Enums;


namespace PressGatherer.References.TransportModels.SearchModules
{
    public class CreateSearchGroupTransportRequestModel
    {
        public string GroupName { get; set; }

        public CreateSearchGroupTransportRequestModel()
        {
            this.GroupName = "";
        }

        public CreateSearchGroupTransportRequestModel(string groupName)
        {
            this.GroupName = groupName;
        }
    }
}
