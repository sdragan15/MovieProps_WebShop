using MovieProps.BLL.Contract.DTOs.User;
using MovieProps.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Contract.Services
{
    public interface IUserService
    {
        Task<ResponsePackage<string>> RegisterUser(UserDataIn dataIn);
    }
}
