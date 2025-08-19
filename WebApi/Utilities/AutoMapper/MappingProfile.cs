using AutoMapper;
using Entities.DataTransferObject;
using Entities.Models;
using WebApi.Controllers;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Products, ProductDto>().ReverseMap();
            CreateMap<ProductDtoForInsert, Products>();
            CreateMap<ProductDtoForUpdate, Products>();

        }
    }
}
