using AutoMapper;
using Starter.Console.DTO.Intent;
using Starter.Contracts;
using Starter.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starter.Console.Controllers
{
    [Route("api/v1/intents")]
    [ApiController]
    public class IntentController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILoggerManager logger;
        private readonly IIntentService service;

        public IntentController(IMapper mapper, ILoggerManager logger, IIntentService intentService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.service = intentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<IntentViewModel>>> Get()
        {
            try
            {
                var _intents = await this.service.GetAllAsync();

                return this.mapper.Map<List<IntentViewModel>>(_intents);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside LanguageController.Get action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IntentViewModel>> Get(long id)
        {
            try
            {
                if (id <= 0) return BadRequest("Invalid ID");

                var _intent = await this.service.GetById(id);

                if (_intent == null) return NotFound("Resource Not Found");

                return this.mapper.Map<IntentViewModel>(_intent);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside LanguageController.Get action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<IntentViewModel>> Create([FromBody] IntentCreationModel creationModel)
        {
            try
            {
                var _intent = await service.Create(mapper.Map<Models.Intent>(creationModel));

                if (_intent == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, Unable to Create");

                var result = mapper.Map<IntentViewModel>(_intent);

                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside LanguageController.Create action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<IntentViewModel>> Update(long id, [FromBody] IntentModificationModel modificationModel)
        {
            try
            {
                if (id <= 0  || modificationModel == null) return BadRequest("Invalid ID or Data");

                var _intent = await this.service.GetById(id);

                if (_intent == null) return NotFound("Resource Not Found");

                _intent.Name = modificationModel.Name;

                _intent = await service.Update(_intent);

                return mapper.Map<IntentViewModel>(_intent);
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

                var _intent = await this.service.GetById(id);

                if (_intent == null) return NotFound("Resource Not Found");

                service.Delete(_intent);

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
