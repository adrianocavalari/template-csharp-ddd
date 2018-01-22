using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Template.Mvc.AutoMapper;
using static Template.IoC.NativeInjectorBootStrapper;

namespace Template.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.RegisterMapping();

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}
