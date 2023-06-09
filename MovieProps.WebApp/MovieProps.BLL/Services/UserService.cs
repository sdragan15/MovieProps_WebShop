using AutoMapper;
using MovieProps.BLL.Contract.DTOs.Item;
using MovieProps.BLL.Contract.DTOs.User;
using MovieProps.BLL.Contract.Helpers;
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
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;
        private readonly IHttpContextProvider _httpContextProvider;

        private readonly int _userId;

        public UserService(IUnitOfWork unitOfWork, IImageService imageService, IMapper mapper,
            IHttpContextProvider provider)
        {
            _uow = unitOfWork;
            _imageService = imageService;
            _mapper = mapper;
            _httpContextProvider = provider;
            _userId = _httpContextProvider.GetUserId();
        }

        public async Task<ResponsePackage<User>> GetByEmail(string email)
        {
            return new ResponsePackage<User>()
            {
                Data = await _uow.GetUserRepository().GetByEmail(email)
            };  
        }

        public async Task<ResponsePackage<UserDto>> GetCurrentUser()
        {
            try
            {
                var user = await _uow.GetUserRepository().GetUserById(_userId);
                if(user == null)
                {
                    return new ResponsePackage<UserDto>(StatusCode.NOT_FOUND, "User not found");
                }

                user.Image = _imageService.LoadImage(user.Image);
                var result = _mapper.Map<UserDto>(user);

                return new ResponsePackage<UserDto>()
                {
                    Data = result
                };
            }
            catch(Exception e)
            {
                return new ResponsePackage<UserDto>(StatusCode.INTERNAL_SERVER_ERROR, e.Message); 
            }
        }

        public async Task<ResponsePackage<string>> RegisterUser(UserDataIn dataIn)
        {
            if(String.IsNullOrWhiteSpace(dataIn.Email))
            {
                return new ResponsePackage<string>(StatusCode.BAD_REQUEST, "Email is required");
            }

            if (String.IsNullOrWhiteSpace(dataIn.Password))
            {
                return new ResponsePackage<string>(StatusCode.BAD_REQUEST, "Password is required");
            }

            var oldUser = await _uow.GetUserRepository().GetByEmail(dataIn.Email);
            if(oldUser != null)
            {
                return new ResponsePackage<string>(StatusCode.BAD_REQUEST, "User already registered!");
            }

            var user = _mapper.Map<User>(dataIn);
            user.LastUpdateTime = DateTime.Now;
            var imagePackage = await _imageService.SaveImage(dataIn.Image);
            switch (dataIn.Role)
            {
                case "Buyer":
                    user.Role = await _uow.GetRoleRepository().GetByValue(RoleTypes.BUYER);
                    user.Status = UserStatus.APPROVED;
                    break;
                case "Seller":
                    user.Role = await _uow.GetRoleRepository().GetByValue(RoleTypes.SELLER);
                    user.Status = UserStatus.PENDING;
                    break;
                default:
                    user.Role = await _uow.GetRoleRepository().GetByValue(RoleTypes.BUYER);
                    user.Status = UserStatus.APPROVED;
                    break;
            }

            if(imagePackage.StatusCode == StatusCode.OK)
            {
                user.Image = imagePackage.Data;
            }

            await _uow.GetUserRepository().Add(user);
            await _uow.CompleteAsync();

            return new ResponsePackage<string>();
        }

        public async Task<ResponsePackage<List<ItemDto>>> GetAllItemsForCurrentUser()
        {
            try
            {
                var items = await _uow.GetUserRepository().GetAllItemsByUserId(_userId);

                var result = new List<ItemDto>();

                foreach (var temp in items)
                {
                    var newItem = _mapper.Map<ItemDto>(temp);
                    newItem.Image = _imageService.LoadImage(temp.Image);
                    result.Add(newItem);
                }

                return new ResponsePackage<List<ItemDto>>()
                {
                    Data = result
                };
            }
            catch (Exception e)
            {
                return new ResponsePackage<List<ItemDto>>(Shared.Constants.StatusCode.INTERNAL_SERVER_ERROR, e.Message);
            }
        }

        public async Task<ResponsePackage<List<UserDto>>> GetAllSellers()
        {
            var users = await _uow.GetUserRepository().GetAllSellers();
            if (users == null)
                return new ResponsePackage<List<UserDto>>();

            var result = _mapper.Map<List<UserDto>>(users);
            foreach(var user in result)
            {
                user.Image = _imageService.LoadImage(user.Image);
            }

            return new ResponsePackage<List<UserDto>>()
            {
                Data = result
            };
        }

        public async Task<ResponsePackage<string>> ApproveSeller(string email)
        {
            var user = await _uow.GetUserRepository().GetByEmail(email);
            if(user == null)
            {
                return new ResponsePackage<string>(StatusCode.NOT_FOUND, "Not found");
            }

            user.Status = UserStatus.APPROVED;
            user.LastUpdateTime = DateTime.Now;

            await _uow.CompleteAsync();
            return new ResponsePackage<string>();
        }

        public async Task<ResponsePackage<string>> RejectSeller(string email)
        {
            var user = await _uow.GetUserRepository().GetByEmail(email);
            if (user == null)
            {
                return new ResponsePackage<string>(StatusCode.NOT_FOUND, "Not found");
            }

            user.Status = UserStatus.REJECTED;
            user.LastUpdateTime = DateTime.Now;

            await _uow.CompleteAsync();
            return new ResponsePackage<string>();
        }

        public async Task<ResponsePackage<string>> Update(UserDataIn dataIn)
        {
            if (String.IsNullOrWhiteSpace(dataIn.Email))
            {
                return new ResponsePackage<string>(StatusCode.BAD_REQUEST, "Email is required!");
            }

            var user = await _uow.GetUserRepository().GetUserById(_userId);
            if(user == null)
            {
                return new ResponsePackage<string>(StatusCode.INTERNAL_SERVER_ERROR, "Internal Server Error");
            }

            if(user.Email != dataIn.Email)
            {
                var otherUser = await _uow.GetUserRepository().GetByEmail(dataIn.Email);
                if(otherUser != null)
                {
                    return new ResponsePackage<string>(StatusCode.BAD_REQUEST, "User with same email already exists");
                }
            }

            user.FirstName = dataIn.FirstName;
            user.LastName = dataIn.LastName;
            user.Address = dataIn.Address;
            user.BirthDay = dataIn.BirthDay;
            user.LastUpdateTime = DateTime.Now;

            if(dataIn.Image != null)
            {
                var response = await _imageService.SaveImage(dataIn.Image);
                if(response.StatusCode == StatusCode.OK)
                {
                    user.Image = response.Data;
                }
            }

            await _uow.CompleteAsync();

            return new ResponsePackage<string>();
        }
    }
}
