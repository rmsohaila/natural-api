using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Starter.Console.DTO.Entity;
using Starter.Contracts;
using Starter.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starter.Console.Controllers
{
    [Route("api/v1/entities")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILoggerManager logger;
        private readonly IEntityService service;

        public EntityController(IMapper mapper, ILoggerManager logger, IEntityService entityService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.service = entityService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EntityListViewModel>>> Get()
        {
            try
            {
                var _entities = await this.service.GetAllAsync();

                if (_entities == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");

                return this.mapper.Map<List<EntityListViewModel>>(_entities);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside EntityController.Get action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<EntityViewModel>> Get(long id)
        {
            try
            {
                if (id <= 0) return BadRequest("Invalid ID");

                var _entity = await this.service.GetByIdAsync(id);

                if (_entity == null)  return NotFound("Resource Not Found");

                return this.mapper.Map<EntityViewModel>(_entity);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside EntityController.Get(id) action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<EntityViewModel>> Create([FromBody] EntityCreationModel creationModel)
        {
            try
            {
                var _entity = await this.service.Create(this.mapper.Map<Models.Entity>(creationModel));

                if (_entity == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, Unable to Create");

                var result = this.mapper.Map<EntityViewModel>(_entity);

                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside EntityController.Create action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut("id:int")]
        public async Task<IActionResult> Update(int id, [FromBody] EntityUpdationModel updationModel)
        {
            await Task.Delay(0);
            return Ok();
        }
    }
}
