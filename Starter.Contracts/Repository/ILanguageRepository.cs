using Starter.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starter.Contracts.Repository
{
    public interface ILanguageRepository : IRepositoryBase<Language>
    {
        Task<IEnumerable<Language>> GetAllAsync();
        Task<Language> GetByIdAsync(long id);
    }
}
