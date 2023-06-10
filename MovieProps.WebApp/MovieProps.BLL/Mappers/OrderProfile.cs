using AutoMapper;
using MovieProps.BLL.Contract.DTOs.Order;
using MovieProps.DAL.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Mappers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>()
            .ForMember(x => x.Total, opt => opt.MapFrom(x => x.Total))
            .ForMember(x => x.Items, opt => opt.MapFrom(x => x.OrderItems))
            .ForMember(x => x.Shipping, opt => opt.MapFrom(x => x.ShippingCost))
            .ForMember(x => x.Ordered, opt => opt.MapFrom(x => x.Ordered))
            .ForMember(x => x.Delivered, opt => opt.MapFrom(x => x.Delivered))
            .ForMember(x => x.OrderType, opt => opt.MapFrom(x => x.OrderType))
            .ForMember(x => x.Products, opt => opt.MapFrom(x => x.Total - x.ShippingCost))
            ;

            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}
