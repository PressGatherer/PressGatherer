namespace PressGatherer.References.TransportModels.ArticleModules
{
    public class ArticlePicture
    {
        public string Link { get; set; }

        public ArticlePicture()
        {
            this.Link = "";
        }

        public ArticlePicture(string link)
        {
            this.Link = link;
        }
    }
}