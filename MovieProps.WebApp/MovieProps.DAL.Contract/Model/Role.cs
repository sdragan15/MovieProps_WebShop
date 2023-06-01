using MovieProps.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.DAL.Contract.Model
{
    public class Role : Entity
    {
        public string Name { get; set; }
        public RoleTypes Value { get; set; }
    }
}
