using System.Collections.Generic;
using System.Threading.Tasks;
namespace SalesDatePrediction.DataProvider.Services
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T customer);
        Task Update(T customer);
        Task Delete(int id);
    }
}
