using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Repository.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Key]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public float Discount { get; set; }
    }
}
