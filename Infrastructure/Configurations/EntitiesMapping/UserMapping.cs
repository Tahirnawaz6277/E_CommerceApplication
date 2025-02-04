using Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infrastructure.Configurations.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("users");


            builder.Property(x => x.FullName).IsRequired().HasMaxLength(100);

            builder.HasMany(x => x.User_Payments)
              .WithOne()
              .HasForeignKey(up => up.UserId)
              .HasPrincipalKey(o => o.Id)
              .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(x => x.User_Addresses)
                   .WithOne()
                   .HasForeignKey(ua => ua.UserId)
                   .HasPrincipalKey(o => o.Id)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
