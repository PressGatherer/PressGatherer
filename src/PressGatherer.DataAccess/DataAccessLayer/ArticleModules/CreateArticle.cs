using MongoDB.Bson;
using MongoDB.Driver;
using PressGatherer.References.Enums;
using PressGatherer.References.Logics;
using PressGatherer.References.TransportModels.ArticleModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressGatherer.DataAccess.DataAccessLayer
{
    public partial class PGAccess
    {
        public static async Task<CreateArticleTransportResponseModel> CreateArticle (CreateArticleTransportRequestModel model)
        {
            try
            {                
                DbContext db = new DbContext();

                Article article = new Article
                {
                    Title = model.Title,
                    Description = model.Description,
                    Link = model.Link,
                    Pictures = new List<ArticlePicture>(),
                    Category = model.Category,
                    Content = model.Content,
                    HtmlContent = model.HtmlContent,
                    Culture = model.Culture,
                    Page = new ArticlePage(model.Page),
                    ArticleConnections = new List<ArticleConnection>(),
                    ArticleRatings = new List<ArticleRating>(),
                    AddedDate = DateTime.UtcNow,
                };

                await db.Articles.InsertOneAsync(article);

                return new CreateArticleTransportResponseModel(article.Id.ToString());
            }
            catch
            {
                return new CreateArticleTransportResponseModel();
            }
        }
    }
}
