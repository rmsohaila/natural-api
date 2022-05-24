using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Starter.Console.DTO.Template;
using Starter.Contracts;
using Starter.Contracts.Services;
using Starter.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Starter.Console.Controllers
{
    [Route("api/v1/templates")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly ITemplateService service;
        private readonly IMapper mapper;
        private readonly ILoggerManager logger;

        public TemplateController(IMapper mapper, ILoggerManager logger, ITemplateService templateService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.service = templateService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TemplateListIndexModel>>> Get()
        {
            try
            {
                var _templates = await this.service.GetAllAsync();

                return this.mapper.Map<List<TemplateListIndexModel>>(_templates);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside TemplateController.Get action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<TemplateViewModel>> Get(long id)
        {
            try
            {
                if (id <= 0) return BadRequest();

                var _template = await this.service.GetByIdAsync(id);

                if (_template == null) return NotFound("Resource Not Found");

                return this.mapper.Map<TemplateViewModel>(_template);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside TemplateController.Get(id) action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("{id:long}/attributes")]
        public async Task<ActionResult<List<AttributeViewModel>>> GetAttributes(long id)
        {
            try
            {
                if (id <= 0) return BadRequest();

                var _attributes = await this.service.GetAllAttributes(id);

                return this.mapper.Map<List<AttributeViewModel>>(_attributes);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside TemplateController.GetAttributes(id) action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<TemplateViewModel>> Create([FromBody] TemplateCreationModel creationModel)
        {
            try
            {
                var _template = await this.service.Create(mapper.Map<Models.Template>(creationModel));

                if (_template == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, Unable to Create");

                var result = mapper.Map<TemplateViewModel>(_template);

                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside TemplateController.Create action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut("id:int")]
        public async Task<IActionResult> Update(long id, [FromBody] TemplateModificationModel modificationModel)
        {
            try
            {
                if (id <= 0 || modificationModel == null) return BadRequest("Invalid ID or Data");

                var _template = await this.service.GetByIdAsync(id);

                if (_template == null) return NotFound("Resource Not Found");

                var result = mapper.Map<TemplateViewModel>(_template);

                return Ok();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside TemplateController.Update action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
