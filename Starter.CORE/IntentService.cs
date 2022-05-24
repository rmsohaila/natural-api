using AutoMapper;
using Starter.Contracts;
using Starter.Contracts.Services;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Starter.CORE
{
    public class IntentService : IIntentService
    {
        private readonly ILoggerManager logger;
        private readonly IUnitOfWork repository;
        private readonly IMapper mapper;

        public IntentService(ILoggerManager logger, IUnitOfWork repository, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Models.Intent> Create(Models.Intent intent)
        {
            try
            {
                var _intent = this.mapper.Map<Entities.Intent>(intent);
                repository.Intents.Create(_intent);
                await repository.Commit();
                return this.mapper.Map<Models.Intent>(_intent);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside IntentService.Create action: {ex.Message}");
                return null;
            }
        }

        public async Task<Models.Intent> Update(Models.Intent intent)
        {
            try
            {
                var _intent = this.mapper.Map<Entities.Intent>(intent);
                repository.Intents.Update(_intent);
                await repository.Commit();
                return this.mapper.Map<Models.Intent>(_intent);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside IntentService.Update action: {ex.Message}");
                return null;
            }
        }

        public async void Delete(Models.Intent intent)
        {
            try
            {
                var _intent = this.mapper.Map<Entities.Intent>(intent);
                repository.Intents.Delete(_intent);
                await repository.Commit();
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside IntentService.Update action: {ex.Message}");
            }
        }

        public async Task<List<Models.Intent>> GetAllAsync()
        {
            try
            {
                var _intents = await this.repository.Intents.GetAllAsync();
                return this.mapper.Map<List<Models.Intent>>(_intents);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside IntentService.Update action: {ex.Message}");
                return null;
            }
        }

        public async Task<Models.Intent> GetById(long id)
        {
            try
            {
                var _intent = await this.repository.Intents.GetByIdAsync(id);
                return this.mapper.Map<Models.Intent>(_intent);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside IntentService.Update action: {ex.Message}");
                return null;
            }
        }
    }
}
