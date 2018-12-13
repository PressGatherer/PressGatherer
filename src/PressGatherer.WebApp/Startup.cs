using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MongoTraining.WebApp.Startup))]
namespace MongoTraining.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
