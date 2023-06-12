using MovieProps.DAL.Contract.Model;
using MovieProps.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.DAL.Contract.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetOrdersByEmail(string email);
        Task<List<Order>> GetAllOrders();
        Task<List<OrderedItemsTemp>> GetAllOrderedItemsByUserId(int id);
        Task<List<Order>> GetNotDeliveredOrders();
        Task<Order> GetOrderById(int id);
    }
}
