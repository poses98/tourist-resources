using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EcoTravel.Startup))]
namespace EcoTravel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
