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
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserForLoginDto>();
            CreateMap<UserForLoginDto, User>();

            CreateMap<UserForRegistrationDto, User>()
        .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));

            CreateMap<UserForLoginDto, User>()
        .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));

            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, User>();
            
            CreateMap<UserTaskDto, UserTaskDto>();

        //    CreateMap<UserTaskDto, UserTask>()
        //.ForMember(u => u.UserAsigned, opt => opt.MapFrom(x => x.));


            //CreateMap<UserTaskDto, UserTask>();


        }

    }
}
