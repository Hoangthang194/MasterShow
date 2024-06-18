using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WPS.Startup))]
namespace WPS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
