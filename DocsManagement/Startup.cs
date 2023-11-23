using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DocsManagement.Startup))]
namespace DocsManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
