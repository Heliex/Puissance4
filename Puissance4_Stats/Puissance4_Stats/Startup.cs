using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Puissance4_Stats.Startup))]
namespace Puissance4_Stats
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
