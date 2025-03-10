using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Repository.Models
{
    public class Shipper
    {
        [Key]
        public int ShipperId { get; set; }

        [Required, MaxLength(100)]
        public string CompanyName { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
