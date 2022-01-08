using Properties.Model.Entities;
using Properties.Model.DataTransferObjects;
using AutoMapper;
using System.Linq;

namespace Properties.Model.DataTransferObjects
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Property, PropertyInfoDto>()
                .ForMember(dto => dto.Image, conf => conf.MapFrom(ol => ol.PropertyImages.FirstOrDefault() != null ? ol.PropertyImages.First().File : null))
                .ForMember(dto => dto.OwnerName, conf => conf.MapFrom(ol => ol.Owner.Name))
                .ForMember(dto => dto.OwnerAddress, conf => conf.MapFrom(ol => ol.Owner.Address))
                .ReverseMap();
            CreateMap<Property, PropertyCreateDto>().ReverseMap();
            CreateMap<Property, PropertyUpdateDto>().ReverseMap();
            CreateMap<Owner, OwnerInfoDto>().ReverseMap();
            CreateMap<PropertyImage, PropertyImageInfoDto>().ReverseMap();
        }
    }
}
