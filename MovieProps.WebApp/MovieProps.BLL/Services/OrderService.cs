﻿using AutoMapper;
using MovieProps.BLL.Contract.DTOs.Order;
using MovieProps.BLL.Contract.Helpers;
using MovieProps.BLL.Contract.Services;
using MovieProps.DAL.Contract.Model;
using MovieProps.DAL.Contract.UnitOfWork;
using MovieProps.Shared.Constants;
using MovieProps.Shared.Helper;
using MovieProps.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _uow;
        private readonly IHttpContextProvider _httpContext;
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        private readonly string _userEmail;

        public OrderService(IUnitOfWork unitOfWork, IHttpContextProvider httpContextProvider, IItemService itemService, IMapper mapper)
        {
            _uow = unitOfWork;
            _httpContext = httpContextProvider;
            _userEmail = _httpContext.GetUserEmail();
            _itemService = itemService;
            _mapper = mapper;
        }

        public async Task<ResponsePackage<string>> CancelOrder(int id)
        {
            try
            {
                var order = await _uow.GetOrderRepository().GetOrderById(id);
                if (order == null)
                {
                    return new ResponsePackage<string>(StatusCode.NOT_FOUND, "Not found");
                }

                foreach(var item in order.OrderItems)
                {
                    item.Item.Quantity += item.Count ?? 0;
                }

                order.OrderType = OrderType.CANCELED;
                order.LastUpdateTime = DateTime.Now;

                await _uow.CompleteAsync();
                return new ResponsePackage<string>();
            }
            catch(Exception e)
            {
                return new ResponsePackage<string>(StatusCode.INTERNAL_SERVER_ERROR, e.Message);
            }
            
        }

        public async Task<ResponsePackage<string>> CreateOrder(OrderDataIn dataIn)
        {
            var order = new Order();
            var items = new List<OrderItem>();

            try
            {
                foreach (var item in dataIn.Items)
                {
                    var tempItem = await _uow.GetItemRepository().GetById(item.Id ?? 0);
                    if(tempItem == null)
                    {
                        return new ResponsePackage<string>(Shared.Constants.StatusCode.NOT_FOUND, "Item from cart not found!");
                    }

                    if(tempItem.Quantity < item.Count)
                    {
                        return new ResponsePackage<string>(Shared.Constants.StatusCode.BAD_REQUEST, "There is not enought items in stock");
                    }

                    if(tempItem.Price != item.Price)
                    {
                        return new ResponsePackage<string>(Shared.Constants.StatusCode.BAD_REQUEST, "Price for item is changed");
                    }

                    items.Add(new OrderItem()
                    {
                        Item = tempItem,
                        Count = item.Count
                    });
                }

                var user = await _uow.GetUserRepository().GetByEmail(_userEmail);
                if(user == null)
                {
                    return new ResponsePackage<string>(Shared.Constants.StatusCode.INTERNAL_SERVER_ERROR, "Internal server error");
                }

                var rand = new Random();

                order.User = user;
                order.OrderItems = items;
                order.Address = dataIn.Address ?? user.Address ?? "";
                order.LastUpdateTime = DateTime.Now;
                order.OrderType = Shared.Constants.OrderType.ORDERED;
                order.Total = ShippingCost.Price;
                order.Delivered = DateTime.Now.AddHours(rand.Next(1, 10));

                foreach(var item in order.OrderItems)
                {
                    var myItem = dataIn.Items.FirstOrDefault(x => x.Id == item.Item.Id);
                    if(myItem != null && myItem.Price == item.Item.Price)
                    {
                        order.Total += item.Item.Price * item.Count;
                        await _itemService.Subtract(item.Item.Id, item.Count ?? 0);
                    }
                }
            
                await _uow.GetOrderRepository().Add(order);
                await _uow.CompleteAsync();

                return new ResponsePackage<string>();
            }
            catch(Exception e)
            {
                return new ResponsePackage<string>(Shared.Constants.StatusCode.INTERNAL_SERVER_ERROR, e.Message);
            }
        }

        public async Task<ResponsePackage<List<OrderDto>>> GetAllOrders()
        {
            try
            {
                var orders = await _uow.GetOrderRepository().GetAllOrders();
                if (orders == null)
                {
                    return new ResponsePackage<List<OrderDto>>()
                    {
                        Data = null
                    };
                }

                var ordersDto = _mapper.Map<List<OrderDto>>(orders);
                return new ResponsePackage<List<OrderDto>>()
                {
                    Data = ordersDto
                };
            }
            catch (Exception e)
            {
                return new ResponsePackage<List<OrderDto>>(Shared.Constants.StatusCode.INTERNAL_SERVER_ERROR, e.Message);
            }
        }

        public async Task<ResponsePackage<List<OrderDto>>> GetMyOrders()
        {
            try
            {
                var orders = await _uow.GetOrderRepository().GetOrdersByEmail(_userEmail);
                if (orders == null)
                {
                    return new ResponsePackage<List<OrderDto>>()
                    {
                        Data = null
                    };
                }

                var ordersDto = _mapper.Map<List<OrderDto>>(orders);
                return new ResponsePackage<List<OrderDto>>()
                {
                    Data = ordersDto
                };
            }
            catch(Exception e)
            {
                return new ResponsePackage<List<OrderDto>>(Shared.Constants.StatusCode.INTERNAL_SERVER_ERROR, e.Message);
            }
            
        }

        public async Task<ResponsePackage<List<OrderedItemDto>>> GetOrderedItemsByUserEmail()
        {
            try
            {
                var user = await _uow.GetUserRepository().GetByEmail(_userEmail);
                if (user == null)
                {
                    return new ResponsePackage<List<OrderedItemDto>>(StatusCode.INTERNAL_SERVER_ERROR, "Internal server error");
                }

                var items = await _uow.GetOrderRepository().GetAllOrderedItemsByUserId(user.Id);
                foreach (var item in items)
                {
                    var tempItem = await _uow.GetItemRepository().GetById(item.Id);
                    item.Price = item.Count * tempItem.Price;
                }

                var resultDto = _mapper.Map<List<OrderedItemDto>>(items);


                return new ResponsePackage<List<OrderedItemDto>>()
                {
                    Data = resultDto
                };
            }
            catch(Exception e)
            {
                return new ResponsePackage<List<OrderedItemDto>>(StatusCode.INTERNAL_SERVER_ERROR, e.Message);
            }
            
        }
    }
}
