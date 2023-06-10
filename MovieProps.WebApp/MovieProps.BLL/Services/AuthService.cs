using Microsoft.AspNetCore.Http;
using MovieProps.BLL.Contract.DTOs.User;
using MovieProps.BLL.Contract.Services;
using MovieProps.DAL.Contract.Model;
using MovieProps.DAL.Contract.UnitOfWork;
using MovieProps.Shared.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _uow;
        private readonly IHttpContextAccessor _httpContext;

        public AuthService(HttpClient httpClient, IUserService userService, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _userService = userService;
            _uow = unitOfWork;
            _httpContext = httpContextAccessor;
        }

        public async Task<ResponsePackage<User>> LoginWithFacebook(string token)
        {
            var response = await _httpClient.GetAsync($"https://graph.facebook.com/v13.0/me?fields=id,name,email,picture.width(200).height(200)&access_token={token}");

            if (!response.IsSuccessStatusCode)
            {
                return new ResponsePackage<User>(Shared.Constants.StatusCode.INTERNAL_SERVER_ERROR, "Internal server error");
            }

            var content = await response.Content.ReadAsStringAsync();
            var userData = JsonConvert.DeserializeObject<FacebookUser>(content);

            var user = await _uow.GetUserRepository().GetByEmail(userData.Email);
            if(user != null)
            {
                return new ResponsePackage<User>()
                {
                    Data = user
                };
            }

            var newUser = new User();
            newUser.FirstName = userData.Name.Split(' ')[0];
            newUser.LastName = userData.Name.Split(' ')[1];
            newUser.Email = userData.Email;
            newUser.Image = userData.Picture.Data.Url;
            newUser.Role = await _uow.GetRoleRepository().GetByValue(Shared.Constants.RoleTypes.BUYER);
            newUser.Status = Shared.Constants.UserStatus.APPROVED;

            try
            {
                await _uow.GetUserRepository().Add(newUser);
                await _uow.CompleteAsync();
            }
            catch(Exception e)
            {
                return new ResponsePackage<User>(Shared.Constants.StatusCode.INTERNAL_SERVER_ERROR, e.Message);
            }
            

            return new ResponsePackage<User>()
            {
                Data = newUser
            };
        }
    }
}
