using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(online.Startup))]
namespace online
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
