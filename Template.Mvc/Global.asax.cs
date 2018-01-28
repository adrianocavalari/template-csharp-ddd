using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using static Template.IoC.NinjectInjectorBootStrapper;

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

            var nin = new NinjectControllerFactory();
            //nin.ninjectKernel.Bind<ApplicationUserManager>().To<ApplicationUserManager>();
            //nin.ninjectKernel.Bind<ApplicationSignInManager>().To<ApplicationSignInManager>();
            //nin.ninjectKernel.Bind<ApplicationDbContext>().ToSelf();


            nin.ninjectKernel.Bind(typeof(UserManager<>)).ToSelf(); // add scoping as necessary
            nin.ninjectKernel.Bind(typeof(UserStore<>)).ToSelf(); // add scoping as necessary
            nin.ninjectKernel.Bind(typeof(IUserStore<>)).To(typeof(UserStore<>));
            nin.ninjectKernel.Bind<IAuthenticationManager>().ToMethod( c => HttpContext.Current.GetOwinContext().Authentication);

            ControllerBuilder.Current.SetControllerFactory(nin);
        }
    }
}
