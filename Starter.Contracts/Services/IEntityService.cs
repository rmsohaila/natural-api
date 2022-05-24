using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starter.Contracts.Services
{
    public interface IEntityService
    {
        Task<Models.Entity> Create(Models.Entity entity);
        Task<Models.Entity> Update(Models.Entity entity);
        void Delete(Models.Entity entity);
        Task<List<Models.Entity>> GetAllAsync();
        Task<Models.Entity> GetByIdAsync(long id);
    }
}
