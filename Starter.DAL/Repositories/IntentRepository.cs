using Starter.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Starter.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Starter.Contracts.Repository;

namespace Starter.DAL
{
    public class IntentRepository : RepositoryBase<Intent>, IIntentRepository
    {
        public IntentRepository(SQLDBContext repositoryContext)
            : base(repositoryContext)
        { }

        public async Task<IEnumerable<Intent>> GetAllAsync()
        {
            return await FindAll()
               .OrderBy(p => p.Name)
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task<Intent> GetByIdAsync(long id)
        {
            return await FindByCondition(p => p.Id.Equals(id))
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
