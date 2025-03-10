
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Repository.Data;
using SalesDatePrediction.Repository.Models;

namespace SalesDatePrediction.Repository.Repositories.Imp
{
    public class CustomRepository : ICustomRepository
    {
        private readonly SalesDbContext context;

        public CustomRepository(SalesDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerId(int id)
        {
            return await this.context.Orders
                         .Where(o => o.CustId == id)
                         .ToListAsync();
        }

        public async Task<IEnumerable<CustomerOrderPrediction>> GetSalesDatePrediction()
        {
            var query = @"
                WITH OrderIntervals AS (
                    SELECT 
                        o.custid,
                        o.orderdate,
                        LAG(o.orderdate) OVER (PARTITION BY o.custid ORDER BY o.orderdate) AS prev_order_date
                    FROM Sales.Orders o
                ),
                CustomerOrderStats AS (
                    SELECT 
                        o.custid,
                        MAX(o.orderdate) AS LastOrderDate,
                        ROUND(SUM(DATEDIFF(DAY, oi.prev_order_date, oi.orderdate)) / COUNT(o.orderdate), 0) AS AvgDaysBetweenOrders
                    FROM Sales.Orders o
                    LEFT JOIN OrderIntervals oi ON o.custid = oi.custid AND o.orderdate = oi.orderdate
                    GROUP BY o.custid
                )
                SELECT 
                    c.custid As CustId, 
                    c.companyname AS CustomerName,
                    cos.LastOrderDate,
                    DATEADD(DAY, cos.AvgDaysBetweenOrders, cos.LastOrderDate) AS NextPredictedOrder
                FROM CustomerOrderStats cos
                JOIN Sales.Customers c ON cos.custid = c.custid
                ORDER BY c.companyname;
            ";

            var result = await this.context.CustomerOrderPredictions
                                    .FromSqlRaw(query)
                                    .ToListAsync();

            return result;
        }

        public async Task CreateOrderAsync(Order order, OrderDetail orderDetails)
        {
            var transaction = await this.context.Database.BeginTransactionAsync();

            try
            {
                this.context.Orders.Add(order);
                await this.context.SaveChangesAsync();

                var orderId = order.OrderId;

                orderDetails.OrderId = orderId;
                this.context.OrderDetails.Add(orderDetails);

                await this.context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> CustomerExists(int customerId)
        {
            return await this.context.Customers.AnyAsync(c => c.CustId == customerId);
        }

    }
}
