using MovieProps.BLL.Contract.DTOs.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Contract.DTOs.Order
{
    public class OrderItemDto
    {
        public ItemDto Item { get; set; }
        public int Count { get; set; }
    }
}
