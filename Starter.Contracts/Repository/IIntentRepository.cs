using Starter.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starter.Contracts.Repository
{
    public interface IIntentRepository : IRepositoryBase<Intent>
    {
        Task<IEnumerable<Intent>> GetAllAsync();
        Task<Intent> GetByIdAsync(long id);
    }
}
