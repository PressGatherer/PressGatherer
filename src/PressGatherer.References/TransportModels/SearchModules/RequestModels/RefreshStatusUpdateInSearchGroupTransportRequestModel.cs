using PressGatherer.References.Enums;

namespace PressGatherer.References.TransportModels.SearchModules
{
   public class RefreshStatusUpdateInSearchGroupTransportRequestModel
    {
        public string SearchGroupId { get; set; }

        public int RefreshRateEnum { get; set; }


        public RefreshStatusUpdateInSearchGroupTransportRequestModel(string searchGroupId, int refreshRateEnum)
        {
            this.SearchGroupId = searchGroupId;
            this.RefreshRateEnum = refreshRateEnum;
        }
    }
}
