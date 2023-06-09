using AutoMapper;
using MovieProps.BLL.Contract.DTOs.User;
using MovieProps.DAL.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDataIn, User>()
                .ForMember(x => x.Role, opt => opt.Ignore());
            CreateMap<User, UserDto>()
                .ForMember(x => x.Role, opt => opt.MapFrom(x => x.Role.Name))
                .ForMember(x => x.Status, opt => opt.MapFrom(x => x.Status.ToString()));

        }
    }
}
