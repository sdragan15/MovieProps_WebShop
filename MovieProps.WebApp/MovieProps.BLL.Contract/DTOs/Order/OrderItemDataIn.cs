using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Contract.DTOs.Order
{
    public class OrderItemDataIn
    {
        public int? Id { get; set; }
        public decimal Price { get; set; }
        public int? Count { get; set; }
    }
}
