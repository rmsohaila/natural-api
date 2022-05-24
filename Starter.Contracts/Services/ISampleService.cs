using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starter.Contracts.Services
{
    public interface ISampleService
    {
        Task<bool> Create(IList<Models.Sample> entity);
        Task<Models.Sample> Update(Models.Sample entity);
        void Delete(Models.Sample entity);
        Task<List<Models.Sample>> GetAllAsync();
        Task<Models.Sample> GetByIdAsync(long id);
    }
}
