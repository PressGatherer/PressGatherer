using System.Collections.Generic;

namespace PressGatherer.References.TransportModels.ArticleModules
{
    public class CreateArticleTransportRequestModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public List<ArticlePictureTransportModel> Pictures { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        public string HtmlContent { get; set; }
        public string Culture { get; set; }
        public ArticlePageTransportModel Page { get; set; }
        public IEnumerable<ArticleConnectionTransportModel> ArticleConnections { get; set; }
        public IEnumerable<ArticleRatingTransportModel> ArticleRatings { get; set; }

        public CreateArticleTransportRequestModel()
        {
            this.Title = "";
            this.Description = "";
            this.Link = "";
            this.Pictures = null;
            this.Category = "";
            this.Content = "";
            this.HtmlContent = "";
            this.Culture = "";
            this.Page = null;
            this.ArticleConnections = null;
            this.ArticleRatings = null;
        }

        public CreateArticleTransportRequestModel(string title, string description, string link, string category, string content, string htmlContent, string culture)
        {
            this.Title = title;
            this.Description = description;
            this.Link = link;
            this.Pictures = new List<ArticlePictureTransportModel>();
            this.Category = category;
            this.Content = content;
            this.HtmlContent = htmlContent;
            this.Culture = culture;
            this.Page = new ArticlePageTransportModel();
            this.ArticleConnections = new List<ArticleConnectionTransportModel>();
            this.ArticleRatings = new List<ArticleRatingTransportModel>();
        }

        public CreateArticleTransportRequestModel(string title, string description, string link, string category, string content, string htmlContent, string culture, string imageLink)
        {
            this.Title = title;
            this.Description = description;
            this.Link = link;
            this.Pictures = new List<ArticlePictureTransportModel>
            {
                new ArticlePictureTransportModel(imageLink)
            };
            this.Category = category;
            this.Content = content;
            this.HtmlContent = htmlContent;
            this.Culture = culture;
            this.Page = new ArticlePageTransportModel();
            this.ArticleConnections = new List<ArticleConnectionTransportModel>();
            this.ArticleRatings = new List<ArticleRatingTransportModel>();
        }
    }
}
