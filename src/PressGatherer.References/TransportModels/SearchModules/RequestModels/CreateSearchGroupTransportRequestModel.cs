using PressGatherer.References.Enums;


namespace PressGatherer.References.TransportModels.SearchModules
{
    public class CreateSearchGroupTransportRequestModel
    {
        public string GroupName { get; set; }
        public string UserId { get; set; }

        public CreateSearchGroupTransportRequestModel()
        {
            this.GroupName = "";
            this.UserId = "";
        }

        public CreateSearchGroupTransportRequestModel(string groupName, string userId)
        {
            this.GroupName = groupName;
            this.UserId = userId;
        }
    }
}
