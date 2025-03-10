using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Repository.Data;
using SalesDatePrediction.Repository.Models;

namespace SalesDatePrediction.Repository.Repositories.Imp
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly SalesDbContext context;

        public EmployeeRepository(SalesDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await context.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await context.Employees.FindAsync(id);
        }

        public async Task Add(Employee employee)
        {
            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
        }

        public async Task Update(Employee employee)
        {
            context.Employees.Update(employee);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                await context.SaveChangesAsync();
            }
        }
    }
}
