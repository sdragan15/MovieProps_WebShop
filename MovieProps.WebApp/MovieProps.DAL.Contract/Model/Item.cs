﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.DAL.Contract.Model
{
    public class Item : Entity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Image? Image { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
    }
}
