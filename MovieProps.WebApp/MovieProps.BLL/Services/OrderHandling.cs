using MovieProps.BLL.Contract.Services;
using MovieProps.DAL.Contract.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Services
{
    public class OrderHandling : IOrderHandling
    {
        private readonly IUnitOfWork _uow;

        public OrderHandling(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task UpdateOrderDelivery()
        {
            var orders = await _uow.GetOrderRepository().GetNotDeliveredOrders();

            foreach(var order in orders)
            {
                if(order.Delivered <= DateTime.Now)
                {
                    order.OrderType = Shared.Constants.OrderType.DELIVERED;
                }
            }

            await _uow.CompleteAsync();
        }
    }
}
