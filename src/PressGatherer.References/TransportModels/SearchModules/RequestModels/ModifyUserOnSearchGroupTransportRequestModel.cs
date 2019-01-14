using PressGatherer.References.Enums;

namespace PressGatherer.References.TransportModels.SearchModules
{
    public class ModifyUserOnSearchGroupTransportRequestModel
    {
        public string GroupId { get; set; }
        public string UserId { get; set; }
        public UserAccessTypeEnum UserAccessType { get; set; }

        public ModifyUserOnSearchGroupTransportRequestModel()
        {
            this.GroupId = "";
            this.UserId = "";
            this.UserAccessType = UserAccessTypeEnum.View;
        }

        public ModifyUserOnSearchGroupTransportRequestModel(string groupId, string userId, UserAccessTypeEnum userAccessType)
        {
            this.GroupId = groupId;
            this.UserId = userId;
            this.UserAccessType = userAccessType;
        }
    }
}
