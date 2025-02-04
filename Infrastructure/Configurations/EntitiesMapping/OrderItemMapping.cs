using Domain.Entities.Catalog.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infrastructure.Configurations.Mappings
{
    public class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems", "order");

            builder.HasKey(o => o.OrderItemId);

            builder.Property(o => o.OrderId).IsRequired();
            builder.Property(o => o.ProductId).IsRequired();
            builder.Property(o => o.Quantity).IsRequired();
            builder.Property(o => o.UnitPrice).IsRequired(false);

            // configure relationships

            builder.HasOne(o => o.Product)
                .WithMany()
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.OrderDetail)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
