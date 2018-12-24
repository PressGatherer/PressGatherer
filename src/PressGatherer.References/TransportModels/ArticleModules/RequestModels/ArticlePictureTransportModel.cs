namespace PressGatherer.References.TransportModels.ArticleModules
{
    public class ArticlePictureTransportModel
    {
        public string Link { get; set; }

        public ArticlePictureTransportModel()
        {
            this.Link = "";
        }

        public ArticlePictureTransportModel(string link)
        {
            this.Link = link;
        }
    }
}