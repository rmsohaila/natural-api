using AutoMapper;
using Starter.Contracts;
using Starter.Contracts.Services;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Starter.CORE
{
    public class SampleService : ISampleService
    {
        private readonly ILoggerManager logger;
        private readonly IUnitOfWork repository;
        private readonly IMapper mapper;

        public SampleService(ILoggerManager logger, IUnitOfWork repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.repository = repository;
        }

        public async Task<bool> Create(IList<Models.Sample> samples)
        {
            try
            {
                foreach (var _sample in samples)
                {
                    _sample.CreatedBy = 100;
                    _sample.LastModifiedBy = 100;
                    _sample.CreatedOn = DateTime.UtcNow;
                    _sample.LastModifiedOn = DateTime.UtcNow;

                    this.repository.Samples.Create(
                        this.mapper.Map<Entities.Sample>(_sample)
                    );
                }

                await repository.Commit();
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside EntityService.Create action: {ex.Message}");
                return false;
            }
        }

        public async Task<Models.Sample> Update(Models.Sample sample)
        {
            try
            {
                var _sample = this.mapper.Map<Entities.Sample>(sample);

                repository.Samples.Update(_sample);

                await repository.Commit();

                return this.mapper.Map<Models.Sample>(_sample);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside EntityService.Update action: {ex.Message}");
                return null;
            }
        }

        public async void Delete(Models.Sample sample)
        {
            try
            {
                var _sample = this.mapper.Map<Entities.Sample>(sample);
                repository.Samples.Delete(_sample);
                await repository.Commit();
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside EntityService.Delete action: {ex.Message}");
            }
        }

        public async Task<List<Models.Sample>> GetAllAsync()
        {
            try
            {
                var _samples = await this.repository.Samples.GetAllIncludedAsync();
                return this.mapper.Map<List<Models.Sample>>(_samples);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside EntityService.GetAll action: {ex.Message}");
                return null;
            }
        }

        public async Task<Models.Sample> GetByIdAsync(long id)
        {
            try
            {
                var _sample = await this.repository.Samples.GetByIdAsync(id);
                return this.mapper.Map<Models.Sample>(_sample);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside EntityService.GetById action: {ex.Message}");
                return null;
            }
        }
    }
}
