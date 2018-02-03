using System.Collections.Generic;
using System.Data.Entity;
using Template.Domain.Entities;

namespace Template.Data.Context
{
    public class ContextInitializer : CreateDatabaseIfNotExists<TemplateContext>
    {
        protected override void Seed(TemplateContext context)
        {
            context.User.AddRange(new List<User>
            {
                new User() { Id = 1, Name = "Adriano" }
            });

            context.SaveChanges();

            //base.Seed(context);
        }
    }
}
