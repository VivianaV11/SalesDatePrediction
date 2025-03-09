using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePrediction.API.Models
{
    [Table("Shippers", Schema = "Sales")]
    public class Shipper
    {
        [Key]
        public int shipperId { get; set; }
        public string? companyName { get; set; }
        public string? phone { get; set; }

        public ICollection<Order> orders { get; set; }
    }
}
