using E_Commerce.Application.Common.Marker;

namespace E_Commerce.Application.DTOS.Product
{
    public class UpdateProductRequest : IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
    }
}
