using MovieProps.BLL.Contract.DTOs.Order;
using MovieProps.Shared.Helper;
using MovieProps.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Contract.Services
{
    public interface IOrderService
    {
        Task<ResponsePackage<string>> CreateOrder(OrderDataIn dataIn);
        Task<ResponsePackage<List<OrderDto>>> GetMyOrders();
        Task<ResponsePackage<List<OrderDto>>> GetAllOrders();
        Task<ResponsePackage<List<OrderedItemDto>>> GetOrderedItemsByUserEmail();
    }
}
