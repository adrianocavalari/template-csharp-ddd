using System.Collections.Generic;
using System.Data.Entity;
using Template.Domain.Entities;

namespace Template.Data.Context
{
    public class ContextInitializer : CreateDatabaseIfNotExists<SteamSkinContext>
    {
        protected override void Seed(SteamSkinContext context)
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
