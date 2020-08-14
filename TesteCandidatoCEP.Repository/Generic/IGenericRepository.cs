using System.Collections.Generic;
using System.Threading.Tasks;
using TesteCandidatoCEP.Domain.Base;

namespace TesteCandidatoCEP.Repository.Generic
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> Create(T item);
        Task<T> Update(T item);
        Task<bool> Delete(int id);
        Task<T> FindByIdAsync(int id, bool asNoTracking = false);
        Task<List<T>> FindAllAsync(bool asNoTracking = false);
        Task<bool> Exists(int? id);
    }
}
