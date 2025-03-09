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
    public class OrdersController : ControllerBase
    {
        private readonly SalesDbContext _context;

        public OrdersController(SalesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.orders
                .FromSqlRaw("SELECT * FROM Sales.Orders") 
                .ToListAsync();
        }

        [HttpGet("by-customer/{custId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByCustomer(int custId)
        {
            var orders = await _context.orders
                .Where(o => o.custId == custId)
                .ToListAsync();

            if (orders == null || !orders.Any())
            {
                return NotFound($"No se encontraron órdenes para el cliente con ID {custId}");
            }

            return orders;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var order = await _context.orders
                .Include(o => o.orderDetails)
                .FirstOrDefaultAsync(o => o.orderId == id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }
       
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderCreateDto orderDto)
        {
            if (orderDto == null || orderDto.orderDetails.Count == 0)
            {
                return BadRequest("Debe proporcionar una orden con al menos un detalle.");
            }

            var order = new Order
            {
                custId = orderDto.custId,
                empId = orderDto.empId,
                orderDate = orderDto.orderDate,
                requiredDate = orderDto.requiredDate,
                shippedDate = orderDto.shippedDate,
                shipperId = orderDto.shipperId,
                freight = orderDto.freight,
                shipName = orderDto.shipName,
                shipAddress = orderDto.shipAddress,
                shipCity = orderDto.shipCity,
                shipRegion = orderDto.shipRegion,
                shipPostalCode = orderDto.shipPostalCode,
                shipCountry = orderDto.shipCountry,
                orderDetails = new List<OrderDetail>()
            };

            foreach (var detailDto in orderDto.orderDetails)
            {
                var orderDetail = new OrderDetail
                {
                    productId = detailDto.productId,
                    unitPrice = detailDto.unitPrice,
                    qty = detailDto.qty,
                    discount = detailDto.discount
                };

                order.orderDetails.Add(orderDetail);
            }

            _context.orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderById), new { id = order.orderId }, order);
        }

    }
}
