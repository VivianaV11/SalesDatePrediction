using SalesDatePrediction.DataProvider.Helpers;
using System;
using System.Text.Json.Serialization;

namespace SalesDatePrediction.DataProvider.Dtos
{
    public class CustomerOrderPredictionDto
    {
        public int? CustId { get; set; }
        public string CustomerName { get; set; }

        [JsonConverter(typeof(CustomDateFormatConverter))]
        public DateTime? LastOrderDate { get; set; }

        [JsonConverter(typeof(CustomDateFormatConverter))]
        public DateTime? NextPredictedOrder { get; set; }
    }
}
