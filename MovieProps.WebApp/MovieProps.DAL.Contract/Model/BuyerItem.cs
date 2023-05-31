using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.DAL.Contract.Model
{
    public class BuyerItem : Entity
    {
        public User User { get; set; }
        public int? UserId { get; set; }
        public Item Item { get; set; }
        public int? ItemId { get; set; }
        public decimal? BuyPrice { get; set; }
        public DateTime BuyDate { get; set; }
    }
}
