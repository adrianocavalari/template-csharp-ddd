using System.Collections.Generic;
using System.Data.Entity;
using Template.Domain.Entities;

namespace Template.Data.Context
{
    public class ContextInitializer : DropCreateDatabaseIfModelChanges<TemplateContext>
    {
        protected override void Seed(TemplateContext context)
        {
            new List<User>
            {
                new User() { Name = "Adriano" }
            };

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
