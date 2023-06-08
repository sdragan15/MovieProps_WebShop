using Microsoft.AspNetCore.Http;
using MovieProps.BLL.Contract.Helpers;
using System;
using System.Collections.Generic;
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

        public int GetUserId()
        {
            try
            {
                return int.Parse(_context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "id")?.Value);
            }
            catch (Exception)
            {
                return 0;
            }
            
        }
    }
}
