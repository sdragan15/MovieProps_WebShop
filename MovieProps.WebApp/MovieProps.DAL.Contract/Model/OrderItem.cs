using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.DAL.Contract.Model
{
    public class OrderItem : Entity
    {
        public Item? Item { get; set; }
        public int? Count { get; set; }
    }
}
