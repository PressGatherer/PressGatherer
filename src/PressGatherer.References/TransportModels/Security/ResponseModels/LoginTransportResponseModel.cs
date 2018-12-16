using PressGatherer.References.Enums;

namespace PressGatherer.References.TransportModels.Security
{
    public class LoginTransportResponseModel
    {
        public string UserId { get; set; }

        public string VisibleName { get; set; }

        public UserTypeEnum UserType { get; set; }

        public string AuthenticationToken { get; set; }

        public string RefreshToken { get; set; }

        public LoginTransportResponseModel ()
        {
            this.UserId = "";
            this.VisibleName = "";
            this.AuthenticationToken = "";
            this.RefreshToken = "";
        }

        public LoginTransportResponseModel(string userId, string name, UserTypeEnum userType, string authToken, string refreshToken )
        {
            this.UserId = userId;
            this.VisibleName = name;
            this.UserType = userType;
            this.AuthenticationToken = authToken;
            this.RefreshToken = refreshToken;
        }
    }
}
