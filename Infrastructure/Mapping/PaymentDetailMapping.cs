using Domain.Entities.Catalog.Payment;
using Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class PaymentDetailMapping : IEntityTypeConfiguration<PaymentDetail>
    {
        public void Configure(EntityTypeBuilder<PaymentDetail> builder)
        {
            builder.ToTable("PaymentDetails", "payment");

            builder.HasKey(p => p.PaymentDetailId);

            builder.Property(p => p.OrderId)
                .IsRequired();

            builder.Property(p => p.Amount)
                .IsRequired();

            builder.Property(p => p.Provider).IsRequired(false)
                .HasMaxLength(100);

            builder.Property(p => p.Status)
                .IsRequired()
                .HasConversion(e=>e.ToString(),e=>(Payment_Status)Enum.Parse(typeof(Payment_Status),e.ToString()));

            builder.HasOne(p => p.Order)
                .WithMany()
                .HasForeignKey(p => p.OrderId)
                                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
