using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Properties.Model.DataTransferObjects;
using Properties.Model.Entities;
using Properties.Model.Extensions;
using Properties.Model.Models;
using Properties.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Properties.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly ILogger<PropertiesController> _logger;
        private readonly IMapper _mapper;
        private readonly IPropertyBusinessService propertyBusinessService;

        public PropertiesController(
            ILogger<PropertiesController> logger,
            IMapper mapper,
        IPropertyBusinessService propertyBusinessService)
        {
            this._logger = logger;
            this._mapper = mapper;
            this.propertyBusinessService = propertyBusinessService;
        }

        [HttpGet("{id}")]
        public async Task<PropertyInfoDto> GetById(int id)
        {
            var entity = await propertyBusinessService.GetAsync(id);
            return _mapper.Map<PropertyInfoDto>(entity);
        }


        [HttpGet]
        public async Task<IPageResultModel<PropertyInfoDto>> Get(
                    [FromQuery] PropertyFilterDto filters,
                    [FromQuery] string[] sorters,
                    int pageIndex,
                    int pageSize = 10)
        {
            var page = await propertyBusinessService.GetAsync(filters, SortFieldDto.MapDto(sorters), pageIndex, pageSize);
            return _mapper.Map<Property, PropertyInfoDto>(page);
        }

        [HttpPost]
        public async Task<ActionResult<PropertyInfoDto>> Post([FromBody] PropertyCreateDto dto)
        {
            var entity = await propertyBusinessService.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = entity.PropertyId }, _mapper.Map<PropertyInfoDto>(entity));
        }

        [HttpPut("{propertyId}")]
        public async Task<ActionResult<PropertyInfoDto>> Put(int propertyId, [FromBody] PropertyUpdateDto dto)
        {
            await propertyBusinessService.UpdateAsync(propertyId, dto);
            return NoContent();
        }

        [HttpDelete("{propertyId}")]
        public async Task<ActionResult<PropertyInfoDto>> Delete(int propertyId)
        {
            await propertyBusinessService.DeleteAsync(propertyId);
            return NoContent();
        }
    }
}

