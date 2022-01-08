using Properties.Model.DataTransferObjects;
using Properties.Model.Entities;
using Properties.Model.Extensions;
using Properties.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Properties.Model.Services
{
    public interface IPropertyModelService
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
        Task<Property> InsertAsync(Property entity);
        
        /// <summary>
        /// Update Property with attributes received
        /// </summary>
        Task UpdateAsync(Property entity);
        Task<bool> IsPropertyDuplicated(string code, int? propertyId);
    }
}
