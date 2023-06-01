using MovieProps.BLL.Contract.Services;
using MovieProps.DAL.Contract.Model;
using MovieProps.DAL.Contract.Repository;
using MovieProps.DAL.Contract.UnitOfWork;
using MovieProps.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Services
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _uow;

        public ItemService(IUnitOfWork unitofwork)
        {
            _uow = unitofwork;
        }

        public async Task<List<Item>> GetAll()
        {
            return await _uow.GetItemRepository().GetAll();
        }
    }
}
