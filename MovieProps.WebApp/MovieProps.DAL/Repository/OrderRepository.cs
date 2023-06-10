using Microsoft.EntityFrameworkCore;
using MovieProps.DAL.Context;
using MovieProps.DAL.Contract.Model;
using MovieProps.DAL.Contract.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.DAL.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public MoviePropsContext Context
        {
            get { return _context as MoviePropsContext; }
        }

        public OrderRepository(MoviePropsContext moviePropsContext) : base(moviePropsContext) { }

        public async Task<List<Order>> GetOrdersByEmail(string email)
        {
            return await _context.Set<Order>()
                .Include(x => x.User)
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.Item)
                .Where(x => x.User.Email == email && x.IsDeleted == false)
                .ToListAsync();
                


        }
    }
}
