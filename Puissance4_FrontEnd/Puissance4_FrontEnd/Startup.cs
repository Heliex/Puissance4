using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Puissance4_FrontEnd.Startup))]
namespace Puissance4_FrontEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
