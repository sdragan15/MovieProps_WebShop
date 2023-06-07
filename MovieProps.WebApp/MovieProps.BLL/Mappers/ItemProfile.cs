using AutoMapper;
using MovieProps.BLL.Contract.DTOs.Item;
using MovieProps.DAL.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Mappers
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<ItemDataIn, Item>();
            //.ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
            //.ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
            //.ForMember(x => x.Image, opt => opt.MapFrom(x => x.Image))
            //.ForMember(x => x.Price, opt => opt.MapFrom(x => x.Price))
            //.ForMember(x => x.Quantity, opt => opt.MapFrom(x => x.Quantity));

            CreateMap<Item, ItemDto>();
        }

    }
}
