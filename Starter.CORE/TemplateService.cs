using AutoMapper;
using Starter.Contracts;
using Starter.Contracts.Services;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Starter.CORE
{
    public class TemplateService : ITemplateService
    {
        private readonly ILoggerManager logger;
        private readonly IUnitOfWork repository;
        private readonly IMapper mapper;

        public TemplateService(ILoggerManager logger, IUnitOfWork repository, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Models.Template> Create(Models.Template template)
        {
            try
            {
                var _template = this.mapper.Map<Entities.Template>(template);

                _template.CreatedBy = 100;
                _template.LastModifiedBy = 100;
                _template.CreatedOn = DateTime.UtcNow;
                _template.LastModifiedOn = DateTime.UtcNow;

                this.repository.Templates.Create(_template);

                await repository.Commit();

                return this.mapper.Map<Models.Template>(_template);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside TemplateService.Create action: {ex.Message}");
                return null;
            }
        }

        public async Task<Models.Template> Update(Models.Template template)
        {
            try
            {
                var newAttributes = template.Attributes.Where(p => p.IsNew).ToList();
                var updateAttributes = template.Attributes.Where(p => p.IsUpdated).ToString();
                var deleteAttributes = template.Attributes.Where(p => p.IsDeleted).ToString();

                template.Attributes.Clear();
                
                var _template = this.mapper.Map<Entities.Template>(template);

                repository.Templates.Update(_template);
                
                await repository.Commit();
                
                return this.mapper.Map<Models.Template>(_template);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside TemplateService.Update action: {ex.Message}");
                return null;
            }
        }

        public async void Delete(Models.Template template)
        {
            try
            {
                var _template= this.mapper.Map<Entities.Template>(template);
                repository.Templates.Delete(_template);
                await repository.Commit();
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside TemplateService.Delete action: {ex.Message}");
            }
        }

        public async Task<List<Models.Template>> GetAllAsync()
        {
            try
            {
                var _templates = await this.repository.Templates.GetAllIncludedAsync();
                return this.mapper.Map<List<Models.Template>>(_templates);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside TemplateService.GetAll action: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Models.Attribute>> GetAllAttributes(long Id)
        {
            try
            {
                var _templates = await this.repository.Templates.GetAttributesAsync(Id);
                return this.mapper.Map<List<Models.Attribute>>(_templates.Attributes);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside TemplateService.GetAll action: {ex.Message}");
                return null;
            }
        }

        public async Task<Models.Template> GetByIdAsync(long id)
        {
            try
            {
                var _template = await this.repository.Templates.GetByIdAsync(id);
                return this.mapper.Map<Models.Template>(_template);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside TemplateService.GetById action: {ex.Message}");
                return null;
            }
        }
    }
}
