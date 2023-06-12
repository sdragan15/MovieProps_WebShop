using MovieProps.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Contract.DTOs.Order
{
    public class OrderedItemDto
    {
        public string? Buyer { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Ordered { get; set; }
        public string? Delivered { get; set; }
        public decimal? Price { get; set; }
        public int? Count { get; set; }
        public OrderType Status { get; set; }
    }
}
