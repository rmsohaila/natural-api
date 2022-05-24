using Starter.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Starter.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Starter.Contracts.Repository;

namespace Starter.DAL
{
    public class SampleRepository : RepositoryBase<Sample>, ISampleRepository
    {
        public SampleRepository(SQLDBContext repositoryContext)
            : base(repositoryContext)
        { }

        public async Task<IEnumerable<Sample>> GetAllAsync()
        {
            return await FindAll()
               .OrderBy(p => p.Text)
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task<IEnumerable<Sample>> GetAllIncludedAsync()
        {
            return await FindAll()
                .Include(s => s.Intent)
                .Include(s => s.Labels)
                .OrderBy(p => p.Text)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Sample> GetByIdAsync(long Id)
        {
            return await FindByCondition(p => p.Id.Equals(Id))
                .Include(s => s.Intent)
                .Include(s => s.Labels)
                .OrderBy(p => p.Text)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
