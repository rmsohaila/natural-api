using AutoMapper;
using Starter.Console.DTO.Language;
using Starter.Contracts;
using Starter.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starter.Console.Controllers
{
    [Route("api/v1/languages")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILoggerManager logger;
        private readonly ILanguageService service;

        public LanguageController(IMapper mapper, ILoggerManager logger, ILanguageService languageService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.service = languageService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LanguageViewModel>>> Get()
        {
            try
            {
                var _languages = await this.service.GetAllAsync();

                return this.mapper.Map<List<LanguageViewModel>>(_languages);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside LanguageController.Get action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<LanguageViewModel>> Get(long id)
        {
            try
            {
                if (id <= 0) return BadRequest("Invalid ID");

                var _language = await this.service.GetById(id);

                if (_language == null) return NotFound("Resource Not Found");

                return this.mapper.Map<LanguageViewModel>(_language);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside LanguageController.Get(id) action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<LanguageViewModel>> Create([FromBody] LanguageCreationModel creationModel)
        {
            try
            {
                var _language = await service.Create(mapper.Map<Models.Language>(creationModel));

                if (_language == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, Unable to Create");

                var result = mapper.Map<LanguageViewModel>(_language);

                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside LanguageController.Create action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<LanguageViewModel>> Update(long id, [FromBody] LanguageModificationModel modificationModel)
        {
            try
            {
                if (id <= 0 || modificationModel == null) return BadRequest("Invalid ID or Data");

                var _language = await this.service.GetById(id);

                if (_language == null) return NotFound("Resource Not Found");

                _language.Name = modificationModel.Name;

                _language = await service.Update(_language);

                return mapper.Map<LanguageViewModel>(_language);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside LanguageController.Update action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                if (id <= 0) return BadRequest("Invalid ID");

                var _language = await this.service.GetById(id);

                if (_language == null) return NotFound("Resource Not Found");

                service.Delete(_language);

                return Ok("Deleted");
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside LanguageController.Delete action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
