using MovieProps.DAL.Contract.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.DAL.Contract.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IItemRepository GetItemRepository();
        IUserRepository GetUserRepository();
        Task<int> CompleteAsync();
    }
}
