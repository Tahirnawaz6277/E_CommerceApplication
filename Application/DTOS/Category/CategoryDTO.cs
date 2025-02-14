using Domain.Entities.Catalog.Inventory;
using E_Commerce.Application.Common.Marker;

namespace E_Commerce.Application.DTOS.Category
{
    public class CategoryDTO : IDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}