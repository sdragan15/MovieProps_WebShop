using MovieProps.DAL.Context;
using MovieProps.DAL.Contract.Repository;
using MovieProps.DAL.Contract.UnitOfWork;
using MovieProps.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MoviePropsContext _context;

        public UnitOfWork(MoviePropsContext context)
        {
            _context = context;
        }


        private IItemRepository ItemRepository { get; set; }
        private IUserRepository UserRepository { get; set; }


        public IItemRepository GetItemRepository()
        {
            return ItemRepository ?? (ItemRepository = new ItemRepository(_context));
        }

        public IUserRepository GetUserRepository()
        {
            return UserRepository ?? (UserRepository = new UserRepository(_context));
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
