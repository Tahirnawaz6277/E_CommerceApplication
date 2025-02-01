using Domain.Entities.Catalog.Order;
using Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class OrderDetailMapping : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails", "order");

            builder.HasKey(o => o.OrderDetailId);

            builder.Property(o => o.UserId).IsRequired();
            builder.Property(o=>o.PaymentId).IsRequired();
            builder.Property(o=>o.OrderDate).IsRequired();
            builder.Property(o=>o.TotalAmount).IsRequired();
            builder.Property(o => o.ShippingAddress).IsRequired().HasMaxLength(100);
            builder.Property(i => i.Status)
                           .IsRequired()
                           .HasConversion(e => e.ToString(), e => (OrderStatus)Enum.Parse(typeof(OrderStatus), e.ToString()));

            // configure relationships

            builder.HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .HasPrincipalKey(o => o.Id)
                  .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(o => o.Payment)
                .WithMany()
                .HasForeignKey(o => o.PaymentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.OrderItems)
                .WithOne(o => o.OrderDetail)
                .HasForeignKey(o => o.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
