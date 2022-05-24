using Starter.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starter.Contracts.Repository
{
    public interface IAttributeRepository : IRepositoryBase<Attribute>
    {
        Task<IEnumerable<Attribute>> GetAllAsync();
        Task<IEnumerable<Attribute>> GetAllIncludedAsync();
        Task<Attribute> GetByIdAsync(long id);
    }
}
