using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Contract.DTOs.Order
{
    public class OrderDataIn
    {
        public List<OrderItemDataIn> Items { get; set; }
        public string? Address { get; set; }
    }
}
