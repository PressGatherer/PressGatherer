namespace PressGatherer.References.TransportModels.ArticleModules
{
    public class ArticlePageTransportModel
    {
        public string PageId { get; set; }
        public string Title { get; set; }
        public string BaseLink { get; set; }
        public ArticlePageTransportModel()
        {
            this.PageId = "";
            this.Title = "";
            this.BaseLink = "";
        }

        public ArticlePageTransportModel(string pageId, string title, string baseLink)
        {
            this.PageId = pageId;
            this.Title = title;
            this.BaseLink = baseLink;
        }
    }
}