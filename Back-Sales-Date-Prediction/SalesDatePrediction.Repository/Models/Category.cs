using SalesDatePrediction.Repository.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SalesDatePrediction.Repository.Models
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

