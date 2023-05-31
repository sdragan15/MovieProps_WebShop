﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.DAL.Contract.Model
{
    public class User : Entity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public string? Token { get; set; }
        public Role? Role { get; set; }
        public int? RoleId { get; set; }

    }
}
