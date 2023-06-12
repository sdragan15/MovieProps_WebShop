using Microsoft.EntityFrameworkCore;
using MovieProps.DAL.Context;
using MovieProps.DAL.Contract.Model;
using MovieProps.DAL.Contract.Repository;
using MovieProps.Shared.Models;
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
                .OrderByDescending(x => x.Ordered)
                .ToListAsync();
                


        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _context.Set<Order>()
               .Include(x => x.User)
               .Include(x => x.OrderItems)
               .ThenInclude(x => x.Item)
               .Where(x => x.IsDeleted == false)
               .OrderByDescending(x => x.Ordered)
               .ToListAsync();
        }

        public async Task<List<OrderedItemsTemp>> GetAllOrderedItemsByUserId(int id)
        {
            string sql = @"select Items.Id, Items.Name, Orders.Ordered, Orders.Delivered, Orders.Total as Price, OrderItems.Count, Orders.OrderType as Status
                            from OrderItems
                            inner join Items
	                        on Items.Id = OrderItems.ItemId
                        inner join Orders
	                        on Orders.Id = OrderItems.OrderId
                        where Items.UserId = @p0
                        and Items.IsDeleted = 0
                        and Orders.OrderType not in (0, 3)";

            try
            {
                var items = await _context.Set<OrderedItemsTemp>()
                    .FromSqlRaw(sql, id)
                    .ToListAsync();

                return items;
            }
            catch(Exception e)
            {
                throw e;
            }
            

        }

        public async Task<List<Order>> GetNotDeliveredOrders()
        {
            return await _context.Set<Order>()
                .Where(x => x.OrderType == Shared.Constants.OrderType.ORDERED && x.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _context.Set<Order>()
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.Item)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }
    }
}
