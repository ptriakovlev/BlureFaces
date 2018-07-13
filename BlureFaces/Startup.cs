using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlureFaces.Startup))]
namespace BlureFaces
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
