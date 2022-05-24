using Starter.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Starter.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Starter.Contracts.Repository;

namespace Starter.DAL.Repositories
{
    class AttributeDataTypeRepository : RepositoryBase<AttributeDataType>, IAttributeDataTypeRepository
    {
        public AttributeDataTypeRepository(SQLDBContext repositoryContext)
            : base(repositoryContext)
        { }

        public async Task<IEnumerable<AttributeDataType>> GetAllAsync()
        {
            return await FindAll()
               .OrderBy(p => p.Name)
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task<AttributeDataType> GetByIdAsync(long Id)
        {
            return await FindByCondition(p => p.Id.Equals(Id))
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
