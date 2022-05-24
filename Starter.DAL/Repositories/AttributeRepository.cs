using Starter.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Starter.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Starter.Contracts.Repository;

namespace Starter.DAL.Repositories
{
    class AttributeRepository : RepositoryBase<Attribute>, IAttributeRepository
    {
        public AttributeRepository(SQLDBContext repositoryContext)
            : base(repositoryContext)
        { }

        public async Task<IEnumerable<Attribute>> GetAllAsync()
        {
            return await FindAll()
               .OrderBy(p => p.Name)
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task<IEnumerable<Attribute>> GetAllIncludedAsync()
        {
            return await FindAll()
                .Include(a => a.DataType)
                .Include(a => a.Values)
                    .ThenInclude(v => v.Language)
               .OrderBy(p => p.Name)
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task<Attribute> GetByIdAsync(long Id)
        {
            return await FindByCondition(p => p.Id.Equals(Id))
                .Include(a => a.Values)
                    .ThenInclude(v => v.Language)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
