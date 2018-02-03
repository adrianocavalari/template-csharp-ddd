using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Template.Identity.Model;

namespace Template.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        static ApplicationDbContext()
        {
            //Database.SetInitializer(new ContextInitializer());
            Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }

        public ApplicationDbContext()
            : base("TemplateEntity")
        {
            Database.CreateIfNotExists();
        }

        public ApplicationDbContext(string name)
            : base(name, throwIfV1Schema: false)
        {
            Database.CreateIfNotExists();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext("TemplateEntity");
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}