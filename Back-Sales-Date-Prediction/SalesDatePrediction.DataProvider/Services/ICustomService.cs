using SalesDatePrediction.DataProvider.Dtos;
using SalesDatePrediction.DataProvider.Dtos;
using SalesDatePrediction.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesDatePrediction.DataProvider.Services
{
    public interface ICustomService
    {
        Task<IEnumerable<CustomerOrderPredictionDto>> GetSalesDatePrediction();
        Task<IEnumerable<OrderDto>> GetOrdersByCustomerId(int id);
        Task<bool> CustomerExists(int customerId);

        Task CreateOrderAsync(CreateOrderDto createOrderDto);
    }
}
