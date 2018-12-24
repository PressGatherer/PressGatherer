namespace PressGatherer.References.TransportModels.ArticleModules
{
    public class ArticleConnectionTransportModel
    {
        public string SearchGroupId { get; set; }
        public double Relevance { get; set; }

        public ArticleConnectionTransportModel()
        {
            this.SearchGroupId = "";
            this.Relevance = 0;
        }

        public ArticleConnectionTransportModel(string searchGroupId, double relevance)
        {
            this.SearchGroupId = searchGroupId;
            this.Relevance = relevance;
        }
    }
}