using AutoMapper;
using RepositoryPattern.Data.Dtos;
using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.Services.Map
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();

        }

    }
}
