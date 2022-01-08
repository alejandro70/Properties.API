using Properties.Model.DataTransferObjects;
using Properties.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Properties.Model.Extensions;
using Properties.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Properties.Model.Services
{
    /// <summary>
    /// Property Model service class
    /// </summary>
    public class PropertyModelService : IPropertyModelService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly PropertiesContext dbContext;

        public PropertyModelService(
            PropertiesContext dbContext,
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.dbContext = dbContext;

        }

        /// <summary>
        /// Fetch property by Identifier
        /// </summary>
        /// <param name="propertyId">Property internal identifier</param>
        /// <returns>Property Entity</returns>
        public async Task<Property> GetAsync(int propertyId)
        {
            var entity = await dbContext.Property.AsQueryable()
              .Include(p => p.Owner)
              .Include(p => p.PropertyImages)
              .Where(p => p.PropertyId == propertyId)
              .FirstOrDefaultAsync();

            return entity;
        }


        /// <summary>
        /// Validate if property exists by internal code & ID (optional)
        /// </summary>
        /// <param name="code">Property Internal Code</param>
        /// <param name="propertyId">Property Identifier</param>
        /// <returns>Property Entity</returns>
        public async Task<bool> IsPropertyDuplicated(string code, int? propertyId)
        {
            var query =  dbContext.Property.AsQueryable()
              .Include(p => p.Owner)
              .Include(p => p.PropertyImages)
              .Where(p => p.CodeInternal == code);

            if (propertyId.HasValue)
                query = query.Where(p=>p.PropertyId != propertyId);

            var entity = await query.FirstOrDefaultAsync();

            return entity != null;
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
            var queryable = dbContext.Property.AsQueryable()
                .Include(p => p.Owner)
                .Include(p => p.PropertyImages)
                .AsQueryable();

            if (filters.Name != null)
                queryable = queryable.Where(property => property.Name.Contains(filters.Name));
            if (filters.Address != null)
                queryable = queryable.Where(property => property.Address.Contains(filters.Address));
            if (filters.CodeInternal != null)
                queryable = queryable.Where(property => property.CodeInternal.Contains(filters.CodeInternal));
            if (filters.Year != null)
                queryable = queryable.Where(property => property.Year == filters.Year);

            var pageResult = await queryable.GetPageAsync(pageIndex, pageSize);

            return pageResult;
        }

        /// <summary>
        /// Insert new Property in database
        /// </summary>
        /// <param name="dto">Attributes of new Property to insert</param>
        /// <returns>Created Property</returns>
        public async Task<Property> InsertAsync(Property entity)
        {
            unitOfWork.Properties.Insert(entity);
            await unitOfWork.CommitAsync();
            return entity;
        }

        /// <summary>
        /// Update Property with attributes received
        /// </summary>
        /// <param name="propertyId">Property's Internal identifier</param>
        /// <param name="dto">Object with attributes to update in Property</param>
        /// <returns></returns>
        public async Task UpdateAsync(Property entity)
        {
            unitOfWork.Properties.Update(entity);
            await unitOfWork.CommitAsync();
        }
    }
}