using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPNetArvestus02.Startup))]
namespace ASPNetArvestus02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
