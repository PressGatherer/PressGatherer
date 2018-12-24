namespace PressGatherer.References.TransportModels.ArticleModules
{
    public class ArticlePage
    {
        public string PageId { get; set; }
        public string Title { get; set; }
        public string BaseLink { get; set; }
        public ArticlePage()
        {
            this.PageId = "";
            this.Title = "";
            this.BaseLink = "";
        }

        public ArticlePage(string pageId, string title, string baseLink)
        {
            this.PageId = pageId;
            this.Title = title;
            this.BaseLink = baseLink;
        }
    }
}