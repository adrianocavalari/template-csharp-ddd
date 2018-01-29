using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Template.Identity;
using Template.IoC;

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

            //var nin = new NinjectControllerFactory();

            //nin.ninjectKernel.Bind<ApplicationDbContext>().ToSelf();
            //nin.ninjectKernel.Bind(typeof(IUserStore<>)).To(typeof(UserStore<>));
            //nin.ninjectKernel.Bind<IAuthenticationManager>().ToMethod(c => HttpContext.Current.GetOwinContext().Authentication);
            //nin.ninjectKernel.Bind<ApplicationUserManager>().ToMethod(c =>
            //    HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>());

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}
