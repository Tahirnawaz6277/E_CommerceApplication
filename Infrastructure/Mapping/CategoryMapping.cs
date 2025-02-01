using Domain.Entities.Catalog.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "inventory");

            builder.HasKey(c => c.CategoryId);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            
            builder.Property(c=>c.Description).IsRequired().HasMaxLength(255);


            //Configure Relationship
            builder.HasMany(p => p.Products)
              .WithOne(p => p.Category)
              .HasForeignKey(p => p.CategoryId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
