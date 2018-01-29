using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Template.Identity.Startup))]

namespace Template.Identity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
