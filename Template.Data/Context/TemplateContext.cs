using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Template.Data.Mapping;
using Template.Domain.Entities;

namespace Template.Data.Context
{
    public class TemplateContext : DbContext
    {
        public TemplateContext() :
            base("TemplateEntity")
        {

        }

        static TemplateContext()
        {
            Database.SetInitializer(new ContextInitializer());
        }


        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserMap());

        }
    }
}
