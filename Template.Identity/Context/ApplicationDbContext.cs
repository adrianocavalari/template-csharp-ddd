using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Template.Identity.Model;

namespace Template.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
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
                
            //context.Database.Create();
            return new ApplicationDbContext("TemplateEntity");
        }
        // Other part of codes still same 
        // You don't need to add AppUser and AppRole 
        // since automatically added by inheriting form IdentityDbContext<AppUser>
    }
}