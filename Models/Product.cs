using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePrediction.API.Models
{
    public class Product
    {
        [Key]
        public int productId { get; set; }
        public string productName { get; set; }
        public int supplierId { get; set; }
        public int categoryId { get; set; }
        public decimal unitPrice { get; set; }
        public bool discontinued { get; set; }

        [ForeignKey("supplierId")]
        public Supplier supplier { get; set; }

        [ForeignKey("categoryId")]
        public Category category { get; set; }
    }
}
