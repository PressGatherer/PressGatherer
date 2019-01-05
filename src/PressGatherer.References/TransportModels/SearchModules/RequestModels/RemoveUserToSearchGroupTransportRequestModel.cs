namespace PressGatherer.References.TransportModels.SearchModules
{
    public class RemoveUserToSearchGroupTransportRequestModel
    {
        public string GroupName { get; set; }
        public string UserId { get; set; }

        public RemoveUserToSearchGroupTransportRequestModel()
        {
            GroupName = "";
            UserId = "";
        }

        public RemoveUserToSearchGroupTransportRequestModel(string groupName, string userId)
        {
            GroupName = groupName;
            UserId = userId;
        }
    }
}
