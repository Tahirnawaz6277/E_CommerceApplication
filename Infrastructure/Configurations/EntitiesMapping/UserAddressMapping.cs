using Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infrastructure.Configurations.Mappings
{
    public class UserAddressMapping : IEntityTypeConfiguration<User_address>
    {
        public void Configure(EntityTypeBuilder<User_address> builder)
        {
            builder.ToTable("UserAddresses");

            builder.HasKey(t => t.User_addressId);
            builder.Property(t => t.UserId).IsRequired();
            builder.Property(t => t.City).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Address).IsRequired().HasMaxLength(255);
            builder.Property(t => t.PostalCode).IsRequired(false).HasMaxLength(50);
            builder.Property(t => t.Country).IsRequired(false).HasMaxLength(100);
            builder.Property(t => t.PhoneNumber).IsRequired().HasMaxLength(50);


            //builder.HasOne(t => t.User)
            //    .WithMany(t => t.User_Addresses)
            //    .HasForeignKey(t => t.UserId)
            //    .HasPrincipalKey(o => o.Id);
        }
    }
}
