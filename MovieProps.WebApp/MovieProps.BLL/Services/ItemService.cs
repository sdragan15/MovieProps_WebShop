using AutoMapper;
using MovieProps.BLL.Contract.DTOs.Item;
using MovieProps.BLL.Contract.Helpers;
using MovieProps.BLL.Contract.Services;
using MovieProps.DAL.Contract.Model;
using MovieProps.DAL.Contract.Repository;
using MovieProps.DAL.Contract.UnitOfWork;
using MovieProps.DAL.UnitOfWork;
using MovieProps.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Services
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IHttpContextProvider _httpProvider;

        private readonly string _userEmail;

        public ItemService(IUnitOfWork unitofwork, IMapper mapper, IImageService imageService,
            IHttpContextProvider httpContextProvider)
        {
            _uow = unitofwork;
            _mapper = mapper;
            _imageService = imageService;
            _httpProvider = httpContextProvider;
            _userEmail = _httpProvider.GetUserEmail();
        }

        public async Task<ResponsePackage<string>> Add(ItemDataIn dataIn)
        {
            try
            {
                Item item = new Item();
                item = _mapper.Map<Item>(dataIn);
                item.LastUpdateTime = DateTime.Now;

                var responsePath = await _imageService.SaveImage(dataIn.Image);
                if(responsePath.StatusCode == Shared.Constants.StatusCode.OK)
                {
                    item.Image = responsePath.Data;
                }

                var user = await _uow.GetUserRepository().GetByEmail(_userEmail);
                if(user == null)
                {
                    return new ResponsePackage<string>(Shared.Constants.StatusCode.NOT_FOUND, "Not found");
                }

                user.Items.Add(item);
                await _uow.CompleteAsync();
                return new ResponsePackage<string>();
            }
            catch(Exception e)
            {
                return new ResponsePackage<string>(Shared.Constants.StatusCode.INTERNAL_SERVER_ERROR, e.Message);
            }
        }

        public async Task<ResponsePackage<string>> DeleteUser(int id)
        {
            try
            {
                await _uow.GetItemRepository().DeleteUser(id);
                return new ResponsePackage<string>();
            }
            catch(Exception e)
            {
                return new ResponsePackage<string>(Shared.Constants.StatusCode.INTERNAL_SERVER_ERROR, "Internal server error");
            }
        }

        public async Task<ResponsePackage<List<ItemDto>>> GetAll()
        {
            try
            {
                var items = await _uow.GetItemRepository().GetAll();

                var result = new List<ItemDto>();

                foreach (var temp in items)
                {
                    var newItem = _mapper.Map<ItemDto>(temp);
                    result.Add(newItem);
                }

                return new ResponsePackage<List<ItemDto>>()
                {
                    Data = result
                };
            }
            catch(Exception e)
            {
                return new ResponsePackage<List<ItemDto>>(Shared.Constants.StatusCode.INTERNAL_SERVER_ERROR, e.Message);
            }
        }

        public async Task<ResponsePackage<string>> UpdateItem(ItemDataIn dataIn)
        {
            try
            {
                var item = _mapper.Map<Item>(dataIn);

                if(dataIn.Image != null)
                {
                    var imagePackage = await _imageService.SaveImage(dataIn.Image);
                    if (imagePackage.StatusCode == Shared.Constants.StatusCode.OK)
                    {
                        item.Image = imagePackage.Data;
                    }
                }

                await _uow.GetItemRepository().UpdateItem(item);

                return new ResponsePackage<string>();
            }
            catch(Exception e)
            {
                return new ResponsePackage<string>(Shared.Constants.StatusCode.INTERNAL_SERVER_ERROR, "Internal server error");
            }
            
        }
    }
}
