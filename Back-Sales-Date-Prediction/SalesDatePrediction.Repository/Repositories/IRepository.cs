using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesDatePrediction.Repository.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T customer);
        Task Update(T customer);
        Task Delete(int id);
    }
}
