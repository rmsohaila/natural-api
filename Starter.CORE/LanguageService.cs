using AutoMapper;
using Starter.Contracts;
using Starter.Contracts.Services;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Starter.CORE
{
    public class LanguageService : ILanguageService
    {
        private readonly ILoggerManager logger;
        private readonly IUnitOfWork repository;
        private readonly IMapper mapper;

        public LanguageService(ILoggerManager logger, IUnitOfWork repository, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Models.Language> Create(Models.Language intent)
        {
            try
            {
                var _intent = this.mapper.Map<Entities.Language>(intent);
                repository.Languages.Create(_intent);
                await repository.Commit();
                return this.mapper.Map<Models.Language>(_intent);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside LanguageService.Create action: {ex.Message}");
                return null;
            }
        }

        public async Task<Models.Language> Update(Models.Language intent)
        {
            try
            {
                var _intent = this.mapper.Map<Entities.Language>(intent);
                repository.Languages.Update(_intent);
                await repository.Commit();
                return this.mapper.Map<Models.Language>(_intent);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside LanguageService.Update action: {ex.Message}");
                return null;
            }
        }

        public async void Delete(Models.Language intent)
        {
            try
            {
                var _intent = this.mapper.Map<Entities.Language>(intent);
                repository.Languages.Delete(_intent);
                await repository.Commit();
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside LanguageService.Update action: {ex.Message}");
            }
        }

        public async Task<List<Models.Language>> GetAllAsync()
        {
            try
            {
                var _intents = await this.repository.Languages.GetAllAsync();
                return this.mapper.Map<List<Models.Language>>(_intents);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside LanguageService.Update action: {ex.Message}");
                return null;
            }
        }

        public async Task<Models.Language> GetById(long id)
        {
            try
            {
                var _intent = await this.repository.Languages.GetByIdAsync(id);
                return this.mapper.Map<Models.Language>(_intent);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside LanguageService.Update action: {ex.Message}");
                return null;
            }
        }
    }
}
