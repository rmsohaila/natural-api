using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starter.Contracts.Services
{
    public interface ILanguageService
    {
        Task<Models.Language> Create(Models.Language intent);
        Task<Models.Language> Update(Models.Language intent);
        void Delete(Models.Language intent);
        Task<List<Models.Language>> GetAllAsync();
        Task<Models.Language> GetById(long id);
    }
}
