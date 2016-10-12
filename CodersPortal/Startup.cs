using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodersPortal.Startup))]
namespace CodersPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
