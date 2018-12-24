namespace PressGatherer.References.TransportModels.ArticleModules
{
    public class ArticleConnection
    {
        public string SearchGroupId { get; set; }
        public double Relevance { get; set; }

        public ArticleConnection()
        {
            this.SearchGroupId = "";
            this.Relevance = 0;
        }

        public ArticleConnection(string searchGroupId, double relevance)
        {
            this.SearchGroupId = searchGroupId;
            this.Relevance = relevance;
        }
    }
}