using MovieProps.DAL.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Contract.Services
{
    public interface IItemService
    {
        Task<List<Item>> GetAll();
    }
}
