using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Template.Identity
{
    public class AspNetUser : Domain.Interfaces.Repository.IUser
    {
        private readonly HttpContextBase _httpContext;

        public AspNetUser(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        public string Name => _httpContext.User.Identity.Name;

        public bool IsAuthenticated()
        {
            return _httpContext.User.Identity.IsAuthenticated;
        }

        //public IEnumerable<Claim> GetClaimsIdentity()
        //{
        //    return _httpContext.User.Claims;
        //}
    }

    public class ApplicationUser : IdentityUser
    {
        //add your custom properties which have not included in IdentityUser before
        //public string MyExtraProperty { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        static ApplicationDbContext()
        {
            //Database.SetInitializer(new ContextInitializer());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        public ApplicationDbContext(string name)
            : base(name, throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            var context = new ApplicationDbContext("TemplateEntity");
            //context.Database.Create();
            return context;
        }
        // Other part of codes still same 
        // You don't need to add AppUser and AppRole 
        // since automatically added by inheriting form IdentityDbContext<AppUser>
    }

    public class AppRole : IdentityRole
    {
        public AppRole() : base() { }
        public AppRole(string name) : base(name) { }
        // extra properties here 
    }

    public class AppUserManager : UserManager<ApplicationUser>
    {
        public AppUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        // this method is called by Owin therefore best place to configure your User Manager
        public static AppUserManager Create(
            IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var manager = new AppUserManager(
                new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));

            // optionally configure your manager
            // ...

            return manager;
        }
    }
}