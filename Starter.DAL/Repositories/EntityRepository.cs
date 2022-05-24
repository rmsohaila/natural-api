using Starter.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Starter.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Starter.Contracts.Repository;

namespace Starter.DAL
{
    public class EntityRepository : RepositoryBase<Entity>, IEntityRepository
    {
        public EntityRepository(SQLDBContext repositoryContext)
            : base(repositoryContext)
        { }

        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await FindAll()
               .OrderBy(p => p.Name)
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task<IEnumerable<Entity>> GetAllIncludedAsync()
        {
            return await FindAll()
                .Include(e => e.Template)
                .Include(e => e.Names)
                    .ThenInclude(n => n.Language)
                .Include(e => e.Values)
                    .ThenInclude(v => v.Language)
                .Include(e => e.Values)
                    .ThenInclude(v => v.DataType)
                .OrderBy(p => p.Name)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Entity> GetByIdAsync(long Id)
        {
            return await FindByCondition(p => p.Id.Equals(Id))
                .Include(e => e.Template)
                .Include(e => e.Names)
                    .ThenInclude(n => n.Language)
                .Include(e => e.Values)
                    .ThenInclude(v => v.Language)
                .Include(e => e.Values)
                    .ThenInclude(v => v.DataType)
                .Include(e => e.Values)
                    .ThenInclude(v => v.Attribute)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Entity> GetValuesAsync(long Id)
        {
            return await FindByCondition(p => p.Id.Equals(Id))
                .Include(t => t.Values)
                    .ThenInclude(v => v.Language)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
