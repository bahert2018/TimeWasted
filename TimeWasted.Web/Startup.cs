using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimeWasted.Web.Startup))]
namespace TimeWasted.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
