using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Contract.DTOs.Item
{
    public class ItemBallanceDto
    {
        public List<ItemDto> Items { get; set; }
        public decimal? ProductsCost { get; set; }
        public decimal? Shipping { get; set; }
        public decimal? Total { get; set; }
    }
}
