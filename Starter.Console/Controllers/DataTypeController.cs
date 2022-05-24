using AutoMapper;
using Starter.Console.DTO.AttributeDataType;
using Starter.Contracts;
using Starter.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starter.Console.Controllers
{
    [Route("api/v1/data-types")]
    [ApiController]
    public class DataTypeController : ControllerBase
    {
        private readonly IAttributeDataTypeService service;
        private readonly IMapper mapper;
        private readonly ILoggerManager logger;

        public DataTypeController(IMapper mapper, ILoggerManager logger, IAttributeDataTypeService attributeDataTypeservice)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.service = attributeDataTypeservice;
        }

        [HttpGet]
        public async Task<ActionResult<List<AttributeDataTypeViewModel>>> Get()
        {
            try
            {
                var _dataTypes = await this.service.GetAllAsync();

                return this.mapper.Map<List<AttributeDataTypeViewModel>>(_dataTypes);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside DataTypeController.Get action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AttributeDataTypeViewModel>> Get(long id)
        {
            try
            {
                if (id <= 0) return BadRequest("Invalid ID");

                var dataType = await this.service.GetByIdAsync(id);

                if (dataType == null) return NotFound("Resource Not Found");
                ;

                return this.mapper.Map<AttributeDataTypeViewModel>(dataType);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside DataTypeController.Get(id) action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<AttributeDataTypeViewModel>> Create([FromBody] AttributeDataTypeCreationModel creationModel)
        {
            try
            {
                var _dataType = await this.service.Create(mapper.Map<Models.AttributeDataType>(creationModel));

                if (_dataType == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, Unable to create");

                var result = mapper.Map<AttributeDataTypeViewModel>(_dataType);

                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside DataTypeController.Create action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<AttributeDataTypeViewModel>> Update(long id,
            [FromBody] AttributeDataTypeModificationModel modificationModel)
        {
            try
            {
                if (id <= 0 || modificationModel == null) return BadRequest("Invalid ID or Data");

                var _dataType = await this.service.GetByIdAsync(id);

                if (_dataType == null) return NotFound("Resource Not Found");

                _dataType.Name = modificationModel.Name;

                _dataType = await this.service.Update(_dataType);

                return mapper.Map<AttributeDataTypeViewModel>(_dataType);
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside DataTypeController.Update action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                if (id <= 0) return BadRequest("Invalid ID");

                var _dataType = await this.service.GetByIdAsync(id);

                if (_dataType == null) return NotFound("Resource Not Found");

                this.service.Delete(_dataType);

                return Ok("Deleted");
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Something went wrong inside DataTypeController.Delete action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
