using E_Commerce.Application.Common.Marker;

namespace E_Commerce.Application.DTOS
{
    public class CategoryResponse : IDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
