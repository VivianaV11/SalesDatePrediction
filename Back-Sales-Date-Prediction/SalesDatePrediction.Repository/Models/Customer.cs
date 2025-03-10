using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SalesDatePrediction.Repository.Models
{

    public class Customer
    {
        [Key]
        public int CustId { get; set; }

        [Required, MaxLength(100)]
        public string CompanyName { get; set; }

        [MaxLength(50)]
        public string ContactName { get; set; }

        [MaxLength(100)]
        public string ContactTitle { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string Region { get; set; }

        [MaxLength(20)]
        public string PostalCode { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(20)]
        public string Fax { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
