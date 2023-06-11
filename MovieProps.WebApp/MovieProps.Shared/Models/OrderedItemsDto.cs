using MovieProps.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.Shared.Models
{
    public class OrderedItemsTemp
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Ordered { get; set; }
        public DateTime Delivered { get; set; }
        public decimal? Price { get; set; }
        public int? Count { get; set; }
        public OrderType Status { get; set; }
    }
}
