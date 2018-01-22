using System.Data.Entity.ModelConfiguration;
using Template.Domain.Entities;

namespace Template.Data.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Name)
                    .HasMaxLength(50)
                    .IsRequired();
        }
    }
}
