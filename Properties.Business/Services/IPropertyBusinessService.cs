using Properties.Model.DataTransferObjects;
using Properties.Model.Entities;
using Properties.Model.Extensions;
using Properties.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Properties.Model.Services
{
    /// <summary>
    /// Property Business service interface
    /// </summary>
    public interface IPropertyBusinessService
    {
        /// <summary>
        /// Fetch property by internal Identifier
        /// </summary>
       Task<Property> GetAsync(int propertyId);

        /// <summary>
        /// Return paginated query of filtered Properties 
        /// </summary>
        Task<IPageResultModel<Property>> GetAsync(PropertyFilterDto filters, List<SortFieldDto> sortFields, int pageIndex, int pageSize);

        /// <summary>
        /// Insert new Property in database
        /// </summary>
        Task<Property> InsertAsync(PropertyCreateDto dto);

        /// <summary>
        /// Update Property with attributes received
        /// </summary>
        Task UpdateAsync(int propertyId, PropertyUpdateDto dto);
    }
}
