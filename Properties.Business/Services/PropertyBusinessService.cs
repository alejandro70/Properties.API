using AutoMapper;
using Properties.Model.DataTransferObjects;
using Properties.Model.Entities;
using Properties.Model.Extensions;
using Properties.Model.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Properties.Model.Services
{
    /// <summary>
    /// Property Business service class
    /// </summary>
    public class PropertyBusinessService : IPropertyBusinessService
    {
        private readonly IMapper _mapper;
        private readonly IPropertyModelService propertyModelService;

        public PropertyBusinessService(
            IMapper mapper,
            IPropertyModelService propertyModelService
            )
        {
            this._mapper = mapper;
            this.propertyModelService = propertyModelService;
        }

        /// <summary>
        /// Fetch property by internal Identifier
        /// </summary>
        /// <param name="propertyId">Property internal identifier</param>
        /// <returns>Property Entity</returns>
        public async Task<Property> GetAsync(int propertyId)
        {
            var entity = await propertyModelService.GetAsync(propertyId);
            return entity;
        }

        /// <summary>
        /// Return paginated query of filtered Properties 
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <param name="sortFields">Sort fields</param>
        /// <param name="pageIndex">Index of page to return in the query</param>
        /// <param name="pageSize">Size of query pages</param>
        /// <returns>Set of Properties</returns>
        public async Task<IPageResultModel<Property>> GetAsync(PropertyFilterDto filters, List<SortFieldDto> sortFields, int pageIndex, int pageSize)
        {
            return await propertyModelService.GetAsync(filters, sortFields, pageIndex, pageSize);
        }

        /// <summary>
        /// Insert new Property in database
        /// </summary>
        /// <param name="dto">Attributes of new Property to insert</param>
        /// <returns>Created Property</returns>
        public async Task<Property> InsertAsync(PropertyCreateDto dto)
        {
            var exists = await propertyModelService.IsPropertyDuplicated(dto.CodeInternal, null);
            if (exists)
                throw new BusinessException("Property Internal Code duplicated");

            var entity = _mapper.Map<Property>(dto);
            entity.Owner = new Owner { Name = dto.OwnerName, Address = dto.OwnerAddress };
            entity.PropertyImages = new List<PropertyImage> { new PropertyImage { File = dto.Image, Enabled = true } };
            return await propertyModelService.InsertAsync(entity);
        }

        /// <summary>
        /// Update Property with attributes received
        /// </summary>
        /// <param name="propertyId">Property's Internal identifier</param>
        /// <param name="dto">Object with attributes to update in Property</param>
        /// <returns></returns>
        public async Task UpdateAsync(int propertyId, PropertyUpdateDto dto)
        {
            var entity = await propertyModelService.GetAsync(propertyId);
            if (entity == null)
                throw new BusinessException("Property to update not found");

            var exists = await propertyModelService.IsPropertyDuplicated(dto.CodeInternal, propertyId);
            if (exists)
                throw new BusinessException("Property Internal Code duplicated");

            _mapper.Map(dto, entity);
            await propertyModelService.UpdateAsync(entity);
        }

        /// <summary>
        /// Delete Property by ID
        /// </summary>
        /// <param name="propertyId">Property's Internal identifier</param>
        /// <returns></returns>
        public async Task DeleteAsync(int propertyId)
        {
            var entity = await propertyModelService.GetAsync(propertyId);
            if (entity == null)
                throw new BusinessException("Property to update not found");

            await propertyModelService.DeleteAsync(propertyId);
        }
    }
}
