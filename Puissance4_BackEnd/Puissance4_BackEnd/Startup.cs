using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Puissance4_BackEnd.Startup))]
namespace Puissance4_BackEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
