using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.Shared.Constants
{
    public enum StatusCode
    {
        OK = 20,
        BAD_REQUEST = 400,
        NOT_FOUND = 404,
        UNAUTHORIZED = 401,
        INTERNAL_SERVER_ERROR = 501
    }
}
