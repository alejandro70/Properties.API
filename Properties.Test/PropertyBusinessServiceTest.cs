
using AutoMapper;
using Moq;
using Properties.Model.DataTransferObjects;
using Properties.Model.Entities;
using Properties.Model.Models;
using Properties.Model.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Xunit;

namespace App.WMS.Tests
{
    public class PropertyBusinessServiceTest
    {
        private readonly IPropertyBusinessService _propertyBusinessService;
        private readonly Mock<IPropertyModelService> _mockPropertyModelService = new Mock<IPropertyModelService>();
        public Mock<IMapper> _mockMapper = new Mock<IMapper>();

        private const int testPropertyId = 1;
        private const string testName = "BRICKELL-AVE #PH01";
        private const string testAddress = "1451 BRICKELL-AVE #PH01,MIAMI,FL 33131";
        private const string testCode = "A11108153";
        private const string testProperty = "100001";
        private const int testSkuId = 1;
        private const string testSku = "00001";
        private const int testQuantity = 5;

        public PropertyBusinessServiceTest()
        {
            _propertyBusinessService = new PropertyBusinessService(
                _mockMapper.Object,
                _mockPropertyModelService.Object);

            //_mockPropertyModelService.Setup(model => model.CreateAsync(It.IsAny<PropertyCreateDto>())).Returns(
            //    Task.FromResult(default(PropertyInfoDto)));
        }

        private PropertyCreateDto GetValidPropertyCreateDto()
        {
            return new PropertyCreateDto
            {
                Name = testName,
                Address = testAddress,
                Price = 39500000.0,
                CodeInternal = testCode,
                Year = 2022,
                Image = "https://millionandupprod.blob.core.windows.net/mls/resize/363144808_1-352X336.jpg",
                OwnerName = "www.millionandup.com",
                OwnerAddress = "2000 Ponce de Leon Blvd #513, Coral Gables, FL 33134"
            };
        }

        private PropertyUpdateDto GetValidPropertyUpdateDto()
        {
            return new PropertyUpdateDto
            {
                Name = testName,
                Address = testAddress,
                Price = 39500000.0,
                CodeInternal = testCode,
                Year = 2022,
                Image = "https://millionandupprod.blob.core.windows.net/mls/resize/363144808_1-352X336.jpg",
                OwnerName = "www.millionandup.com",
                OwnerAddress = "2000 Ponce de Leon Blvd #513, Coral Gables, FL 33134"
            };
        }

        [Fact]
        public void CreateProperty_ShouldValidate_WithValidDto()
        {
            var dto = GetValidPropertyCreateDto();

            // Property inexistente
            // Property not duplicated
            _mockPropertyModelService.Setup(model => model.IsPropertyDuplicated(It.IsAny<string>(), It.IsAny<int?>())).Returns(Task.FromResult(
                false
            ));

            _propertyBusinessService.InsertAsync(dto);
        }

        [Fact]
        public async Task CreateProperty_ShouldInvalidate_WithExistingProperty()
        {
            // Property found
            _mockPropertyModelService.Setup(model => model.GetAsync(It.IsAny<int>())).Returns(Task.FromResult(
                new Property { PropertyId = testPropertyId }
                ));

            // Property duplicated
            _mockPropertyModelService.Setup(model => model.IsPropertyDuplicated(It.IsAny<string>(), It.IsAny<int?>())).Returns(Task.FromResult(
                true
            ));

            var dto = GetValidPropertyCreateDto();

            // Num SKU inexistente
            await Assert.ThrowsAsync<BusinessException>(
                () => _propertyBusinessService.InsertAsync(dto));
        }


        // ----------------


        [Fact]
        public void UpdateProperty_ShouldValidate_WithValidDto()
        {
            // Property found
            _mockPropertyModelService.Setup(model => model.GetAsync(It.IsAny<int>())).Returns(Task.FromResult(
                new Property { PropertyId = testPropertyId }
                ));

            // Property not duplicated
            _mockPropertyModelService.Setup(model => model.IsPropertyDuplicated(It.IsAny<string>(), It.IsAny<int?>())).Returns(Task.FromResult(
                false
            ));

            var dto = GetValidPropertyUpdateDto();

            _propertyBusinessService.UpdateAsync(testPropertyId, dto);
        }

        [Fact]
        public async Task UpdateProperty_ShouldInvalidate_WithNonexistingId()
        {
            // Property not found
            _mockPropertyModelService.Setup(model => model.GetAsync(It.IsAny<int>())).Returns(Task.FromResult(
                default(Property)
                ));

            var dto = GetValidPropertyUpdateDto();

            await Assert.ThrowsAsync<BusinessException>(
                () => _propertyBusinessService.UpdateAsync(testPropertyId, dto));
        }

        [Fact]
        public async Task UpdateProperty_ShouldInvalidate_WithDuplicatedProperty()
        {
            // Property found
            _mockPropertyModelService.Setup(model => model.GetAsync(It.IsAny<int>())).Returns(Task.FromResult(
                new Property { PropertyId = testPropertyId }
                ));

            // Property duplicated
            _mockPropertyModelService.Setup(model => model.IsPropertyDuplicated(It.IsAny<string>(), It.IsAny<int?>())).Returns(Task.FromResult(
                true
            ));

            var dto = GetValidPropertyUpdateDto();

            await Assert.ThrowsAsync<BusinessException>(
              () => _propertyBusinessService.UpdateAsync(testPropertyId, dto));
        }
    }
}