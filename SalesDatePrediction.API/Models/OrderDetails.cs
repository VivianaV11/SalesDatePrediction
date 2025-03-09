using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SalesDatePrediction.API.Models
{
    [Table("OrderDetails", Schema = "Sales")]
    public class OrderDetail
    {
        [Key]
        public int orderId { get; set; }
        public int productId { get; set; }
        public decimal unitPrice { get; set; }
        public int qty { get; set; }
        public decimal discount { get; set; }

        [JsonIgnore]
        [ForeignKey("orderId")]
        public Order order { get; set; }

        [ForeignKey("productId")]
        public Product product { get; set; }
    }
}
