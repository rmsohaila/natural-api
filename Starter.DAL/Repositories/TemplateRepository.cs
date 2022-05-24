using Starter.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Starter.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Starter.Contracts.Repository;

namespace Starter.DAL
{
    public class TemplateRepository : RepositoryBase<Template>, ITemplateRepository
    {
        public TemplateRepository(SQLDBContext repositoryContext)
            : base(repositoryContext)
        { }

        public async Task<IEnumerable<Template>> GetAllAsync()
        {
            return await FindAll()
               .OrderBy(p => p.Name)
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task<IEnumerable<Template>> GetAllIncludedAsync()
        {
            return await FindAll()
                .Include(t => t.CulturalNames)
                .Include(t => t.Attributes)
                    .ThenInclude(a => a.Values)
               .OrderBy(p => p.Name)
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task<Template> GetByIdAsync(long Id)
        {
            return await FindByCondition(p => p.Id.Equals(Id))
                .Include(t => t.CulturalNames)
                    .ThenInclude(n => n.Language)
                .Include(t => t.Attributes)
                    .ThenInclude(a => a.Values)
                        .ThenInclude(v => v.Language)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Template> GetAttributesAsync(long Id)
        {
            return await FindByCondition(p => p.Id.Equals(Id))
                .Include(t => t.Attributes)
                    .ThenInclude(a => a.Values)
                        .ThenInclude(v => v.Language)
                .Include(t => t.Attributes)
                    .ThenInclude(a => a.DataType)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
