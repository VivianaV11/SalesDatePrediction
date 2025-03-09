using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesDatePrediction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly SalesDbContext _context;

        public CustomersController(SalesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers
                .FromSqlRaw("SELECT * FROM Sales.Customers") 
                .ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        
        [HttpGet("orders-prediction")]
        public async Task<ActionResult<IEnumerable<CustomerOrderPredictionDto>>> GetCustomerOrderPredictions()
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
                    c.companyname AS CustomerName,
                    cos.LastOrderDate,
                    DATEADD(DAY, cos.AvgDaysBetweenOrders, cos.LastOrderDate) AS NextPredictedOrder
                FROM CustomerOrderStats cos
                JOIN Sales.Customers c ON cos.custid = c.custid
                ORDER BY c.companyname;
            ";

            var results = await _context.CustomerOrderPredictions
                .FromSqlRaw(query)
                .ToListAsync();

            return results;
        }

    }
}
