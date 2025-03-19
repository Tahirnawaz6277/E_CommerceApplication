using E_Commerce.Application.Common.Marker;

namespace E_Commerce.Application.DTOS.Inventory
{
    public class InventoryDTO : IDto
    {
        public Guid InventoryId { get; set; }
        public int stockQuantity { get; set; }
    }
}
