using Domain.Entities.Catalog.Inventory;
using E_Commerce.Application.Common.Marker;
using E_Commerce.Application.DTOS.Inventory;

namespace E_Commerce.Application.DTOS.Product
{
    public class ProductDTO : IDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? DiscountId { get; set; }
        public Discount? Discount { get; set; }
        public Guid InventoryId { get; set; }
        public InventoryDTO Inventory { get; set; }
        public Discount Discountt { get; set; }

    }
}
