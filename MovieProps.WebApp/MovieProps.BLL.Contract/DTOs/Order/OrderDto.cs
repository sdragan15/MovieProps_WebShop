using MovieProps.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Contract.DTOs.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public List<OrderItemDto> Items { get; set; }
        public decimal? Shipping { get; set; }
        public decimal? Products { get; set; }
        public decimal? Total { get; set; }
        public DateTime Ordered { get; set; }
        public DateTime Delivered { get; set; }
        public OrderType OrderType { get; set; }
    }
}
