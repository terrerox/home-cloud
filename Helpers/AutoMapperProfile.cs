using AutoMapper;
using HomeCloudApi.Entities;
using HomeCloudApi.Models;

namespace HomeCloudApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Storage, GetStorage>();
        }
    }
}