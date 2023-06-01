using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Contract.DTOs.User
{
    public class LoginDataIn
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
