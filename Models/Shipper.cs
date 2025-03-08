using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesDatePrediction.API.Models
{
    public class Shipper
    {
        [Key]
        public int shipperId { get; set; }
        public string companyName { get; set; }
        public string phone { get; set; }

        public ICollection<Order> orders { get; set; }
    }
}
