using PressGatherer.References.Enums;

namespace PressGatherer.References.TransportModels.SearchModules
{
    public class ModifyUserOnSearchGroupTransportRequestModel
    {
        public string GroupName { get; set; }
        public string UserId { get; set; }
        public UserAccessTypeEnum UserAccessType { get; set; }

        public ModifyUserOnSearchGroupTransportRequestModel()
        {
            this.GroupName = "";
            this.UserId = "";
            this.UserAccessType = UserAccessTypeEnum.View;
        }

        public ModifyUserOnSearchGroupTransportRequestModel(string groupName, string userId, UserAccessTypeEnum userAccessType)
        {
            this.GroupName = groupName;
            this.UserId = userId;
            this.UserAccessType = userAccessType;
        }
    }
}
