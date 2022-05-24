using AutoMapper;
using Starter.Contracts;
using Starter.Contracts.Services;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Starter.CORE
{
    public class AttributeDataTypeService : IAttributeDataTypeService
    {
        private readonly ILoggerManager logger;
        private readonly IUnitOfWork repository;
        private readonly IMapper mapper;

        public AttributeDataTypeService(ILoggerManager logger, IUnitOfWork repository, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Models.AttributeDataType> Create(Models.AttributeDataType attributeDataType)
        {
            try
            {
                var _attributeDataType = this.mapper.Map<Entities.AttributeDataType>(attributeDataType);

                _attributeDataType.CreatedBy = 100;
                _attributeDataType.LastModifiedBy = 100;
                _attributeDataType.CreatedOn = DateTime.UtcNow;
                _attributeDataType.LastModifiedOn = DateTime.UtcNow;

                this.repository.AttributeDataTypes.Create(_attributeDataType);

                await repository.Commit();

                return this.mapper.Map<Models.AttributeDataType>(_attributeDataType);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside TemplateService.Create action: {ex.Message}");
                return null;
            }
        }

        public async Task<Models.AttributeDataType> Update(Models.AttributeDataType attributeDataType)
        {
            try
            {
                
                var _attributeDataType = this.mapper.Map<Entities.AttributeDataType>(attributeDataType);

                this.repository.AttributeDataTypes.Update(_attributeDataType);
                
                await repository.Commit();
                
                return this.mapper.Map<Models.AttributeDataType>(_attributeDataType);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside TemplateService.Update action: {ex.Message}");
                return null;
            }
        }

        public async void Delete(Models.AttributeDataType attributeDataType)
        {
            try
            {
                var _attributeDataType = this.mapper.Map<Entities.AttributeDataType>(attributeDataType);
                this.repository.AttributeDataTypes.Delete(_attributeDataType);
                await repository.Commit();
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside TemplateService.Delete action: {ex.Message}");
            }
        }

        public async Task<List<Models.AttributeDataType>> GetAllAsync()
        {
            try
            {
                var _attributeDataTypes = await this.repository.AttributeDataTypes.GetAllAsync();
                return this.mapper.Map<List<Models.AttributeDataType>>(_attributeDataTypes);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside TemplateService.GetAll action: {ex.Message}");
                return null;
            }
        }

        public async Task<Models.AttributeDataType> GetByIdAsync(long id)
        {
            try
            {
                var _attributeDataType = await this.repository.AttributeDataTypes.GetByIdAsync(id);
                return this.mapper.Map<Models.AttributeDataType>(_attributeDataType);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside TemplateService.GetById action: {ex.Message}");
                return null;
            }
        }
    }
}
