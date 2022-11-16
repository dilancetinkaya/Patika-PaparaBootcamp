using AutoMapper;
using Product.Data.Dtos;
using Product.Domain.Entities;

namespace Product.Service.Map
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProductEntity, ProductDto>().ReverseMap();
        }
    }
}
