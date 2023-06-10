using MovieProps.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.DAL.Contract.Model
{
    public class Order : Entity
    {
        public User User { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public decimal? ShippingCost { get; set; }
        public DateTime Ordered { get; set; }
        public DateTime Delivered { get; set; }
        public OrderType OrderType { get; set; }
        public string Address { get; set; }
        public decimal? Total { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
            ShippingCost = 800;
            Ordered = DateTime.Now;
        }
    }
}
