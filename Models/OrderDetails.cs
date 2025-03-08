using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePrediction.API.Models
{
    public class OrderDetail
    {
        [Key]
        public int orderId { get; set; }
        public int productId { get; set; }
        public decimal unitPrice { get; set; }
        public int quantity { get; set; }
        public decimal discount { get; set; }

        [ForeignKey("orderId")]
        public Order order { get; set; }

        [ForeignKey("productId")]
        public Product product { get; set; }
    }
}
