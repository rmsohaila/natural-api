using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starter.Contracts.Services
{
    public interface IAttributeDataTypeService
    {
        Task<Models.AttributeDataType> Create(Models.AttributeDataType attributeDataType);
        Task<Models.AttributeDataType> Update(Models.AttributeDataType attributeDataType);
        void Delete(Models.AttributeDataType attributeDataType);
        Task<List<Models.AttributeDataType>> GetAllAsync();
        Task<Models.AttributeDataType> GetByIdAsync(long id);
    }
}
