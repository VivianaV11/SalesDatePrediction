using SalesDatePrediction.Repository.Models;
using SalesDatePrediction.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesDatePrediction.Repository.Repositories.Imp
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly SalesDbContext context;

        public CustomerRepository(SalesDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await this.context.Customers.ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await this.context.Customers.FindAsync(id);
        }

        public Task Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
