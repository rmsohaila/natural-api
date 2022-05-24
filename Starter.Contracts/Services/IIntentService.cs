using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starter.Contracts.Services
{
    public interface IIntentService
    {
        Task<Models.Intent> Create(Models.Intent intent);
        Task<Models.Intent> Update(Models.Intent intent);
        void Delete(Models.Intent intent);
        Task<List<Models.Intent>> GetAllAsync();
        Task<Models.Intent> GetById(long id);
    }
}
