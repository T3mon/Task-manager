using AutoMapper;
using BLL.ModelsDto;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure.MapperConfig
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, User>();
            
            CreateMap<Status, StatusDto>();
            CreateMap<StatusDto, Status>();

        }

    }
}
