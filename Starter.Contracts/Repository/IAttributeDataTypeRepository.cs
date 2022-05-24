using Starter.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starter.Contracts.Repository
{
    public interface IAttributeDataTypeRepository : IRepositoryBase<AttributeDataType>
    {
        Task<IEnumerable<AttributeDataType>> GetAllAsync();
        Task<AttributeDataType> GetByIdAsync(long id);
    }
}
