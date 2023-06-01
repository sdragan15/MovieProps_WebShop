using Microsoft.EntityFrameworkCore;
using MovieProps.DAL.Context;
using MovieProps.DAL.Contract.Model;
using MovieProps.DAL.Contract.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.DAL.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public MoviePropsContext Context
        {
            get { return _context as MoviePropsContext; }
        }

        public UserRepository(MoviePropsContext context) : base(context) { }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(x => x.Email.Equals(email));
        }
    }
}
