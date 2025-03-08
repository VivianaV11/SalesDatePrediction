using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesDatePrediction.API.Models
{
    public class Employee
    {
        [Key]
        public int empId { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string title { get; set; }
        public string titleOfCourtesy { get; set; }
        public DateTime birthDate { get; set; }
        public DateTime hireDate { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public int? mgrId { get; set; } // ID del manager

        // Relaciones
        public ICollection<Order> orders { get; set; }
    }
}
