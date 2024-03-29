﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Contract.DTOs.User
{
    public class UserDataIn
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? Address { get; set; }
        public string? Role { get; set; }
        public IFormFile? Image { get; set; }
    }
}
