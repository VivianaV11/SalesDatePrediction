using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesDatePrediction.API.Models
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

