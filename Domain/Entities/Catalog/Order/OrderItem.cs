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
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }

        //Relationship

        public Product Product { get; set; }
        public OrderDetail OrderDetail { get; set; }


    }

}
