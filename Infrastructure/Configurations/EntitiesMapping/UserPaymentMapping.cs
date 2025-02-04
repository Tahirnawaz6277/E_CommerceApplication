using Domain.Entities.Catalog.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infrastructure.Configurations.Mappings
{
    public class UserPaymentMapping : IEntityTypeConfiguration<UserPayment>
    {
        public void Configure(EntityTypeBuilder<UserPayment> builder)
        {
            builder.ToTable("UserPayments", "payment");

            builder.HasKey(p => p.UserPaymentId);
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.Payment_type).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Account_No).IsRequired();
            builder.Property(p => p.Provider).IsRequired(false).HasMaxLength(100);
            builder.Property(p => p.Expiry).IsRequired(false);

        }
    }
}
