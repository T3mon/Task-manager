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
            CreateMap<User, UserForLoginDto>();
            CreateMap<UserForLoginDto, User>();

            CreateMap<UserForRegistrationDto, User>()
        .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));

            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, User>();
            
            CreateMap<Status, StatusDto>();
            CreateMap<StatusDto, Status>();

        }

    }
}
