using SalesDatePrediction.Repository.Models;
using SalesDatePrediction.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SalesDatePrediction.Repository.Repositories.Imp
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly SalesDbContext context;

        public OrderRepository(SalesDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await context.Orders.ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await context.Orders.FindAsync(id);
        }

        public async Task Add(Order order)
        {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }

        public async Task Update(Order order)
        {
            context.Orders.Update(order);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var order = await context.Orders.FindAsync(id);
            if (order != null)
            {
                context.Orders.Remove(order);
                await context.SaveChangesAsync();
            }
        }
    }
}
