using PressGatherer.References.Enums;


namespace PressGatherer.References.TransportModels.SearchModules
{
    public class CreateSearchGroupTransportRequestModel
    {
        public string GroupName { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Word { get; set; }

        public int Order { get; set; }

        public RefreshRateEnum RefreshRate { get; set; }

        public SearchGroupAccessibilityEnum Accessibility { get; set; }

        public CreateSearchGroupTransportRequestModel()
        {
            this.GroupName = "";
            this.UserId = "";
            this.UserName = "";
            this.Word = "";
        }

        public CreateSearchGroupTransportRequestModel(string groupName, string userId, string userName, string word, int order, SearchGroupAccessibilityEnum accessibility, RefreshRateEnum refreshRate)
        {
            this.GroupName = groupName;
            this.UserId = userId;
            this.UserName = UserName;
            this.Word = word;
            this.Order = order;
            this.Accessibility = accessibility;
            this.RefreshRate = refreshRate;

        }
    }
}
