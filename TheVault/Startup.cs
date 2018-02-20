using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheVault.Startup))]
namespace TheVault
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
