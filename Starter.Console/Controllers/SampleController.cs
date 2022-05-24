using AutoMapper;
using Starter.Console.DTO.Sample;
using Starter.Contracts;
using Starter.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starter.Console.Controllers
{
    [Route("api/v1/samples")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILoggerManager logger;
        private readonly ISampleService service;

        public SampleController(IMapper mapper, ILoggerManager logger, ISampleService sampleService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.service = sampleService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SampleListViewModel>>> Get()
        {
            try
            {
                var _samples = await this.service.GetAllAsync();

                if (_samples == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");

                return this.mapper.Map<List<SampleListViewModel>>(_samples);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside EntityController.Get action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<SampleViewModel>> Get(long id)
        {
            try
            {
                if (id <= 0) return BadRequest("Invalid ID");

                var _sample = await this.service.GetByIdAsync(id);

                if (_sample == null) return NotFound("Resource Not Found");

                return this.mapper.Map<SampleViewModel>(_sample);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside EntityController.Get(id) action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] List<SampleCreationModel> creationModel)
        {
            try
            {
                var _sampleRange = this.mapper.Map<List<Models.Sample>>(creationModel);
                var _success = await this.service.Create(_sampleRange);

                if (!_success)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, Unable to Create");

                return Ok("Created");
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside EntityController.Create action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut("id:int")]
        public async Task<ActionResult> Update(int id, [FromBody] SampleModificationModel creationModel)
        {
            await Task.Delay(0);
            return NoContent();
        }

        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            await Task.Delay(0);
            return NoContent();
        }
    }
}
