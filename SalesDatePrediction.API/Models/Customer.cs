using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePrediction.API.Models
{
    [Table("Customers", Schema = "Sales")]
    public class Customer
    {
        [Key]
        public int custId { get; set; }
        public string? companyName { get; set; }
        public string? contactName { get; set; }
        public string? contactTitle { get; set; }
        public string? address { get; set; }
        public string? city { get; set; }
        public string? region { get; set; }
        public string? postalCode { get; set; }
        public string? country { get; set; }
        public string? phone { get; set; }

        public ICollection<Order> orders { get; set; }
    }
}
