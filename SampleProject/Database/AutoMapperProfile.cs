using AutoMapper;
using SampleProject.Dtos;
using SampleProject.Models;

namespace SampleProject.Database
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Data, DataDto>();
            CreateMap<DataDto, Data>();
        }
    }
}