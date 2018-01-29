using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Template.Mvc.Startup))]

namespace Template.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
