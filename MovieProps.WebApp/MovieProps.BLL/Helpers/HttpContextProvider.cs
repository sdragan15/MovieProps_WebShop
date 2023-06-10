using Microsoft.AspNetCore.Http;
using MovieProps.BLL.Contract.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Helpers
{
    public class HttpContextProvider : IHttpContextProvider
    {
        private readonly IHttpContextAccessor _context;

        public HttpContextProvider(IHttpContextAccessor contextAccessor)
        {
            _context = contextAccessor;
        }

        public string GetUserEmail()
        {
            try
            {
                var email = _context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
                return email?.Value;
            }
            catch (Exception)
            {
                return "";
            }
            
        }
    }
}
