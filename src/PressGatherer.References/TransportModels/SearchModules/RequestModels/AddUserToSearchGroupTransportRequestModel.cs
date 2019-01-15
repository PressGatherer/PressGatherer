namespace PressGatherer.References.TransportModels.SearchModules
{
    public class AddUserToSearchGroupTransportRequestModel
    {
        public string GroupId { get; set; }
        public string UserId { get; set; }

        public AddUserToSearchGroupTransportRequestModel()
        {
            GroupId = "";
            UserId = "";
        }

        public AddUserToSearchGroupTransportRequestModel(string groupId, string userId)
        {
            GroupId = groupId;
            UserId = userId;
        }
    }
}
