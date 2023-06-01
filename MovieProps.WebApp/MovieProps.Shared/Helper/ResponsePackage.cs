using MovieProps.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.Shared.Helper
{
    public class ResponsePackage<T>
    {
        public string Message { get; set; }
        public StatusCode StatusCode { get; set; }
        public T Data { get; set; }

        public ResponsePackage()
        {
            StatusCode = StatusCode.OK;
        }

        public ResponsePackage(StatusCode code, string message)
        {
            StatusCode = code;
            Message = message;
        }
    }
}
