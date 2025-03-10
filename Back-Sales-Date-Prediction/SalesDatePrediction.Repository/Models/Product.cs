using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Repository.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required, MaxLength(70)]
        public string ProductName { get; set; }

        public int SupplierId { get; set; }
        public int CategoryId { get; set; }

        public decimal UnitPrice { get; set; }
        public bool Discontinued { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
