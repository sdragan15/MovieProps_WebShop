using MovieProps.BLL.Contract.DTOs.User;
using MovieProps.BLL.Contract.Services;
using MovieProps.DAL.Contract.Model;
using MovieProps.DAL.Contract.UnitOfWork;
using MovieProps.Shared.Constants;
using MovieProps.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        public UserService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task<ResponsePackage<string>> RegisterUser(UserDataIn dataIn)
        {
            User user = new User();

            if(String.IsNullOrWhiteSpace(dataIn.Email) || String.IsNullOrWhiteSpace(dataIn.Password))
            {
                return new ResponsePackage<string>(StatusCode.BAD_REQUEST, "Bad request!");
            }
                
            var oldUser = await _uow.GetUserRepository().GetByEmail(dataIn.Email);
            if(oldUser != null)
            {
                return new ResponsePackage<string>(StatusCode.BAD_REQUEST, "User already registered!");
            }

            await _uow.GetUserRepository().Add(user);
            return new ResponsePackage<string>();
        }
    }
}
