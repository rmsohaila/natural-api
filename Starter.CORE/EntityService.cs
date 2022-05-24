using AutoMapper;
using Starter.Contracts;
using Starter.Contracts.Services;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Starter.CORE
{
    public class EntityService : IEntityService
    {
        private readonly ILoggerManager logger;
        private readonly IUnitOfWork repository;
        private readonly IMapper mapper;

        public EntityService(ILoggerManager logger, IUnitOfWork repository, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Models.Entity> Create(Models.Entity entity)
        {
            try
            {
                var _entity = this.mapper.Map<Entities.Entity>(entity);

                _entity.CreatedBy = 100;
                _entity.LastModifiedBy = 100;
                _entity.CreatedOn = DateTime.UtcNow;
                _entity.LastModifiedOn = DateTime.UtcNow;

                this.repository.Entities.Create(_entity);
                
                await repository.Commit();

                _entity = await this.repository.Entities.GetByIdAsync(_entity.Id);

                return this.mapper.Map<Models.Entity>(_entity);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside EntityService.Create action: {ex.Message}");
                return null;
            }
        }

        public async Task<Models.Entity> Update(Models.Entity entity)
        {
            try
            {
                //var newAttributes = entity.Attributes.Where(p => p.IsNew).ToList();
                //var updateAttributes = entity.Attributes.Where(p => p.IsUpdated).ToString();
                //var deleteAttributes = entity.Attributes.Where(p => p.IsDeleted).ToString();

                //entity.Attributes.Clear();
                
                var _entity = this.mapper.Map<Entities.Entity>(entity);

                repository.Entities.Update(_entity);
                
                await repository.Commit();
                
                return this.mapper.Map<Models.Entity>(_entity);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside EntityService.Update action: {ex.Message}");
                return null;
            }
        }

        public async void Delete(Models.Entity entity)
        {
            try
            {
                var _entity = this.mapper.Map<Entities.Entity>(entity);
                repository.Entities.Delete(_entity);
                await repository.Commit();
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside EntityService.Delete action: {ex.Message}");
            }
        }

        public async Task<List<Models.Entity>> GetAllAsync()
        {
            try
            {
                var _entities = await this.repository.Entities.GetAllIncludedAsync();
                return this.mapper.Map<List<Models.Entity>>(_entities);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside EntityService.GetAll action: {ex.Message}");
                return null;
            }
        }

        public async Task<Models.Entity> GetByIdAsync(long id)
        {
            try
            {
                var _entity = await this.repository.Entities.GetByIdAsync(id);
                return this.mapper.Map<Models.Entity>(_entity);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside EntityService.GetById action: {ex.Message}");
                return null;
            }
        }
    }
}
