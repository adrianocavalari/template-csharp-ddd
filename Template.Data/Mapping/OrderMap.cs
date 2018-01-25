using System.Data.Entity.ModelConfiguration;
using Template.Domain.Entities;

namespace Template.Data.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Total)
                    .IsRequired();

            HasRequired(c => c.User)
                    .WithMany(s => s.Orders)
                    .HasForeignKey(c => c.UserId);
        }
    }
}
