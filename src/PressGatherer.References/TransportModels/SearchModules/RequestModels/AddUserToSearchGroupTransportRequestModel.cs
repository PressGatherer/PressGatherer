namespace PressGatherer.References.TransportModels.SearchModules
{
    public class AddUserToSearchGroupTransportRequestModel
    {
        public string GroupName { get; set; }
        public string UserId { get; set; }

        public AddUserToSearchGroupTransportRequestModel()
        {
            GroupName = "";
            UserId = "";
        }

        public AddUserToSearchGroupTransportRequestModel(string groupName, string userId)
        {
            GroupName = groupName;
            UserId = userId;
        }
    }
}
