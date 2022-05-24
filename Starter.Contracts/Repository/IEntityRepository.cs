using Starter.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starter.Contracts.Repository
{
    public interface IEntityRepository : IRepositoryBase<Entity>
    {
        Task<IEnumerable<Entity>> GetAllAsync();
        Task<IEnumerable<Entity>> GetAllIncludedAsync();
        Task<Entity> GetByIdAsync(long id);
        Task<Entity> GetValuesAsync(long Id);
    }
}
