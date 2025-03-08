using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePrediction.API.Models
{
    public class Order
    {
        [Key]
        public int orderId { get; set; }
        public int custId { get; set; }
        public int empId { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime requiredDate { get; set; }
        public DateTime? shippedDate { get; set; }
        public int shipperId { get; set; }
        public decimal freight { get; set; }
        public string shipName { get; set; }
        public string shipAddress { get; set; }
        public string shipCity { get; set; }
        public string shipRegion { get; set; }
        public string shipPostalCode { get; set; }
        public string shipCountry { get; set; }

        [ForeignKey("custId")]
        public Customer customer { get; set; }

        [ForeignKey("empId")]
        public Employee employee { get; set; }

        [ForeignKey("shipperId")]
        public Shipper shipper { get; set; }

        public ICollection<OrderDetail> orderDetails { get; set; }
    }
}
