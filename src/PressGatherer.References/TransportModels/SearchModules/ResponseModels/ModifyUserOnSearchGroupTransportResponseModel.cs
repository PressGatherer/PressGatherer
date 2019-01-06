namespace PressGatherer.References.TransportModels.SearchModules
{
    public class ModifyUserOnSearchGroupTransportResponseModel
    {
        public bool Success { get; set; }

        public ModifyUserOnSearchGroupTransportResponseModel()
        {
            this.Success = false;
        }

        public ModifyUserOnSearchGroupTransportResponseModel(bool success)
        {
            this.Success = success;
        }
    }
}
