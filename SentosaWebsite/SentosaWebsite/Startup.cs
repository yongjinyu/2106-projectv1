using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SentosaWebsite.Startup))]
namespace SentosaWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
