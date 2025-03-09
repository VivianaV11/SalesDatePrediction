using SalesDatePrediction.API.Helpers;
using System;
using System.Text.Json.Serialization;

namespace SalesDatePrediction.API.Models
{
    public class CustomerOrderPredictionDto
    {
        public string CustomerName { get; set; }

        [JsonConverter(typeof(CustomDateFormatConverter))]
        public DateTime? LastOrderDate { get; set; }

        [JsonConverter(typeof(CustomDateFormatConverter))]
        public DateTime? NextPredictedOrder { get; set; }
    }
}
