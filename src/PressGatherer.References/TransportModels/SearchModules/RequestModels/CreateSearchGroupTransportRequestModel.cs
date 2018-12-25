using PressGatherer.References.Enums;


namespace PressGatherer.References.TransportModels.SearchModules
{
    public class CreateSearchGroupTransportRequestModel
    {
        public string GroupName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }

        public CreateSearchGroupTransportRequestModel()
        {
            this.GroupName = "";
            this.UserId = "";
            this.UserName = "";
        }

        public CreateSearchGroupTransportRequestModel(string groupName, string userId, string userName)
        {
            this.GroupName = groupName;
            this.UserId = userId;
            this.UserName = userName;
        }
    }
}
