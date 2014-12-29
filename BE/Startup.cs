using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BE.Startup))]
namespace BE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
