using Domain.Entities.Catalog.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventories", "inventory");

            builder.HasKey(i => i.InventoryId);

            builder.Property(i => i.StockQuantity).IsRequired();


        }
    }
}
