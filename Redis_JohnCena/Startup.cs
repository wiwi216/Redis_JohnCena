using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Redis_JohnCena.Startup))]
namespace Redis_JohnCena
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
