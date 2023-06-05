using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.DAL.Contract.Model
{
    public class Image : Entity
    {
        public string? Name { get; set; }
        public byte[] Bytes { get; set; } 
    }
}
