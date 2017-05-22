using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LanParty.Web.Startup))]
namespace LanParty.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}