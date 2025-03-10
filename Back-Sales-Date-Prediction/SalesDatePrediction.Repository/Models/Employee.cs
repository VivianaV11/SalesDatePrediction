using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePrediction.Repository.Models;
public class Employee
{
    [Key]
    public int EmpId { get; set; }

    [Required, MaxLength(50)]
    public string? LastName { get; set; }

    [Required, MaxLength(50)]
    public string? FirstName { get; set; }

    [MaxLength(100)]
    public string? Title { get; set; }

    [MaxLength(100)]
    public string? TitleOfCourtesy { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? HireDate { get; set; }

    [MaxLength(100)]
    public string? Address { get; set; }

    [MaxLength(50)]
    public string? City { get; set; }

    [MaxLength(50)]
    public string? Region { get; set; }

    [MaxLength(50)]
    public string? Country { get; set; }

    [MaxLength(20)] 
    public string? PostalCode { get; set; }

    [MaxLength(20)]
    public string? Phone { get; set; }

    [ForeignKey("Manager")]
    public int? MgrId { get; set; }
    //public Employee Supervisor { get; set; }

    public ICollection<Order> Orders { get; set; }
}

