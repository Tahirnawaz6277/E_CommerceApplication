using Domain.Entities.Catalog.Inventory;
using Domain.Entities.Common;

namespace Domain.Entities.Catalog.Order
{
    public class OrderItem : AuditableEntity
    {
        public OrderItem()
        {
            OrderDetail = new OrderDetail();
            Product = new Product();
        }
        public Guid OrderItemId { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }

        //Relationship

        public Product Product { get; set; }
        public OrderDetail OrderDetail { get; set; }


    }

}
