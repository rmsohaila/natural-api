using Starter.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starter.Contracts.Repository
{
    public interface ISampleRepository : IRepositoryBase<Sample>
    {
        Task<IEnumerable<Sample>> GetAllAsync();
        Task<IEnumerable<Sample>> GetAllIncludedAsync();
        Task<Sample> GetByIdAsync(long id);
    }
}
