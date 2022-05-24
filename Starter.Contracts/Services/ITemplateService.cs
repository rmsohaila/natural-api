using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starter.Contracts.Services
{
    public interface ITemplateService
    {
        Task<Models.Template> Create(Models.Template template);
        Task<Models.Template> Update(Models.Template template);
        void Delete(Models.Template template);
        Task<List<Models.Template>> GetAllAsync();
        Task<Models.Template> GetByIdAsync(long id);
        Task<List<Models.Attribute>> GetAllAttributes(long Id);
    }
}
