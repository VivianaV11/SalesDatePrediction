namespace SalesDatePrediction.API.Models
{
    public class OrderDetailDto
    {
        public int productId { get; set; }
        public decimal unitPrice { get; set; }
        public int qty { get; set; }
        public decimal discount { get; set; }
    }
}
