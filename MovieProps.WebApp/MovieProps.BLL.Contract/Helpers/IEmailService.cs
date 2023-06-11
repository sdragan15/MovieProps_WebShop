using MovieProps.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Contract.Helpers
{
    public interface IEmailService
    {
        void SendEmail(Message message);
    }
}
