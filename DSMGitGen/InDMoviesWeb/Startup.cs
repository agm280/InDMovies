using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InDMoviesWeb.Startup))]
namespace InDMoviesWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
