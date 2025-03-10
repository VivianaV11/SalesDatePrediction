using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Repository.Data;
using SalesDatePrediction.Repository.Models;

namespace SalesDatePrediction.Repository.Repositories.Imp
{
    public class ShipperRepository : IRepository<Shipper>
    {
        private readonly SalesDbContext context;

        public ShipperRepository(SalesDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Shipper>> GetAll()
        {
            return await this.context.Shippers.ToListAsync();
        }

        public async Task<Shipper> GetById(int id)
        {
            return await this.context.Shippers.FindAsync(id);
        }

        public async Task Add(Shipper shipper)
        {
            await this.context.Shippers.AddAsync(shipper);
            await this.context.SaveChangesAsync();
        }

        public async Task Update(Shipper shipper)
        {
            this.context.Shippers.Update(shipper);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var shipper = await this.context.Shippers.FindAsync(id);
            if (shipper != null)
            {
                this.context.Shippers.Remove(shipper);
                await this.context.SaveChangesAsync();
            }
        }
    }
}
