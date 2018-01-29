using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Template.Identity;
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
            nin.ninjectKernel.Bind<ApplicationDbContext>().ToSelf();


            //nin.ninjectKernel.Bind(typeof(UserManager<>)).ToSelf(); // add scoping as necessary
            //nin.ninjectKernel.Bind(typeof(UserStore<>)).ToSelf(); // add scoping as necessary
            nin.ninjectKernel.Bind(typeof(IUserStore<>)).To(typeof(UserStore<>));

            //var a = HttpContext.Current.GetOwinContext();

            //nin.ninjectKernel.Bind<IAuthenticationManager>().ToMethod(c => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>());

            nin.ninjectKernel.Bind<IAuthenticationManager>().ToMethod(c => HttpContext.Current.GetOwinContext().Authentication);
            nin.ninjectKernel.Bind<ApplicationUserManager>().ToMethod(c =>
                HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>());

            //nin.ninjectKernel.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>();

            //nin.ninjectKernel.Bind<IUserStore<ApplicationUser, string>>().To<UserStore<ApplicationUser>>();
            //nin.ninjectKernel.Bind<UserManager<ApplicationUser>>().ToSelf();
            //nin.ninjectKernel.Bind<SignInManager<ApplicationUser, string>>().ToSelf();


            ControllerBuilder.Current.SetControllerFactory(nin);
        }
    }
}
