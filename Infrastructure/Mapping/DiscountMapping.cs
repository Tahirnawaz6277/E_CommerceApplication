using Domain.Entities.Catalog.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class DiscountMapping : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.ToTable("Discounts", "inventory");

            builder.HasKey(x => x.DiscountId);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x=>x.Discription).IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.Discount_percent).IsRequired().HasPrecision(6,2);
            builder.Property(x => x.Active).IsRequired();


            builder.HasMany(x => x.Products)
                .WithOne(x=>x.Discount)
                .HasForeignKey(x => x.DiscountId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
