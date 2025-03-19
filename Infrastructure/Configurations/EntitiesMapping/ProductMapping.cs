using Domain.Entities.Catalog.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infrastructure.Configurations.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "inventory");

            builder.HasKey(p => p.ProductId);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);

            builder.Property(p => p.Description).IsRequired().HasMaxLength(255);

            builder.Property(p => p.Price).IsRequired();

            builder.Property(p => p.ImageUrl).IsRequired(false);

            builder.Property(p => p.CategoryId).IsRequired();
            builder.Property(p => p.DiscountId).IsRequired(false);
            builder.Property(p => p.InventoryId).IsRequired();

            // configure relationships
            builder.HasOne(p => p.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(p => p.Discount)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.DiscountId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Inventory)
                .WithMany()
                .HasForeignKey(p => p.InventoryId)
                .OnDelete(DeleteBehavior.Cascade);





        }
    }
}
