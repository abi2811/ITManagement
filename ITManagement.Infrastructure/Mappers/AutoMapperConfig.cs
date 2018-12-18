using System;
using AutoMapper;
using ITManagement.Core.Model;
using ITManagement.Infrastructure.DTO;

namespace ITManagement.Infrastructure.Mappers
{
    public static class AutoMapperConfig 
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<DeviceEvent, DeviceEventDTO>();
                cfg.CreateMap<Device, DeviceDTO>();
            })
            .CreateMapper();
    }
}
