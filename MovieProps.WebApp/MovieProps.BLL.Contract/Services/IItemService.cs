using MovieProps.BLL.Contract.DTOs.Item;
using MovieProps.DAL.Contract.Model;
using MovieProps.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Contract.Services
{
    public interface IItemService
    {
        Task<ResponsePackage<List<ItemDto>>> GetAll();
        Task<ResponsePackage<string>> Add(ItemDataIn dataIn);
        Task<ResponsePackage<string>> UpdateItem(ItemDataIn dataIn);
        Task<ResponsePackage<string>> DeleteUser(int id);
    }
}
