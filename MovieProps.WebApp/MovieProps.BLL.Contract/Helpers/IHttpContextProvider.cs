﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Contract.Helpers
{
    public interface IHttpContextProvider
    {
        string GetUserEmail();
    }
}
