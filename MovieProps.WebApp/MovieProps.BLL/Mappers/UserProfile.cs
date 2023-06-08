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
            CreateMap<UserDataIn, User>();
            CreateMap<User, UserDto>();

        }
    }
}
