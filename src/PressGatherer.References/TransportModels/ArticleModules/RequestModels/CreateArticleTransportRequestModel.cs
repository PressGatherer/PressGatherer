using System;
using System.Collections.Generic;
using System.Text;


namespace PressGatherer.References.TransportModels.ArticleModules
{
    public class CreateArticleTransportRequestModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public List<ArticlePictureTransportModel> Pictures { get; set; }
        public string Content { get; set; }
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
            this.Content = "";
            this.Culture = "";
            this.Page = null;
            this.ArticleConnections = null;
            this.ArticleRatings = null;
        }

        public CreateArticleTransportRequestModel(string title, string description, string link, IEnumerable<ArticlePicture> pictures, string content, string culture, ArticlePage page, IEnumerable<ArticleConnection> articleConnections, IEnumerable<ArticleRating> articleRatings)
        {
            this.Title = title;
            this.Description = description;
            this.Link = link;
            this.Pictures = pictures;
            this.Content = content;
            this.Culture = culture;
            this.Page = page;
            this.ArticleConnections = articleConnections;
            this.ArticleRatings = articleRatings;
        }
    }
}
