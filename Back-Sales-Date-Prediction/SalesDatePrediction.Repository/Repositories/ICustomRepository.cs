using SalesDatePrediction.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesDatePrediction.Repository.Repositories
{
    public interface ICustomRepository
    {
        Task<IEnumerable<CustomerOrderPrediction>> GetSalesDatePrediction();
        Task<IEnumerable<Order>> GetOrdersByCustomerId(int id);
        Task CreateOrderAsync(Order order, OrderDetail orderDetails);
        Task<bool> CustomerExists(int customerId);
    }
}
