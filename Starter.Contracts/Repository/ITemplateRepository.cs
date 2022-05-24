using Starter.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starter.Contracts.Repository
{
    public interface ITemplateRepository : IRepositoryBase<Template>
    {
        Task<IEnumerable<Template>> GetAllAsync();
        Task<IEnumerable<Template>> GetAllIncludedAsync();
        Task<Template> GetByIdAsync(long id);
        Task<Template> GetAttributesAsync(long Id);
    }
}
