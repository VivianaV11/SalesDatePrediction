namespace SalesDatePrediction.API.Models
{
    public class OrderCreateDto
    {
        public int? custId { get; set; }
        public int? empId { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime requiredDate { get; set; }
        public DateTime? shippedDate { get; set; }
        public int? shipperId { get; set; }
        public decimal? freight { get; set; }
        public string? shipName { get; set; }
        public string? shipAddress { get; set; }
        public string? shipCity { get; set; }
        public string? shipRegion { get; set; }
        public string? shipPostalCode { get; set; }
        public string? shipCountry { get; set; }
        public List<OrderDetailDto> orderDetails { get; set; } = new List<OrderDetailDto>();
    }
}
