using Domain.Entities.Catalog.Inventory;
using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Catalog.Order
{
    [Table("OrderItems", Schema = "order")]
    public class OrderItem : AuditableEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }

        //Relationship

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public OrderDetail OrderDetail { get; set; } = new OrderDetail();


    }

}
