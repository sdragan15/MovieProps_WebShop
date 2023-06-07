using AutoMapper;
using MovieProps.BLL.Contract.DTOs.Item;
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

        public ItemService(IUnitOfWork unitofwork, IMapper mapper, IImageService imageService)
        {
            _uow = unitofwork;
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task<ResponsePackage<string>> Add(ItemDataIn dataIn)
        {
            try
            {
                Item item = new Item();
                item = _mapper.Map<Item>(dataIn);

                var responsePath = await _imageService.SaveImage(dataIn.Image);
                if(responsePath.StatusCode == Shared.Constants.StatusCode.OK)
                {
                    item.Image = responsePath.Data;
                }

                await _uow.GetItemRepository().Add(item);
                await _uow.CompleteAsync();
                return new ResponsePackage<string>();
            }
            catch(Exception e)
            {
                return new ResponsePackage<string>(Shared.Constants.StatusCode.INTERNAL_SERVER_ERROR, e.Message);
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
                    newItem.Image = _imageService.LoadImage(temp.Image);
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
    }
}
