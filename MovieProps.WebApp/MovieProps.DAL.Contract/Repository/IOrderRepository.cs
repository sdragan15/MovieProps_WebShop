using MovieProps.DAL.Contract.Model;
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
    }
}
