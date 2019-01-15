using PressGatherer.References.Enums;

namespace PressGatherer.References.TransportModels.ArticleModules
{
    public class ArticleRatingTransportModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public RatingTypeEnum RatingType { get; set; }
        public int Value { get; set; }

        public ArticleRatingTransportModel()
        {
            this.UserId = "";
            this.UserName = "";
            this.RatingType = 0;
            this.Value = 0;
        }
        public ArticleRatingTransportModel(string userId, string userName, RatingTypeEnum ratingType, int value)
        {
            this.UserId = userId;
            this.UserName = userName;
            this.RatingType = ratingType;
            this.Value = value;
        }
    }
}