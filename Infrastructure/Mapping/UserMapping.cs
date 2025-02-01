using Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
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
