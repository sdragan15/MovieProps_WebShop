using Microsoft.EntityFrameworkCore;
using MovieProps.DAL.Context;
using MovieProps.DAL.Contract.Model;
using MovieProps.DAL.Contract.Repository;
using MovieProps.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.DAL.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public MoviePropsContext Context
        {
            get { return _context as MoviePropsContext; }
        }

        public RoleRepository(MoviePropsContext moviePropsContext) : base(moviePropsContext) { }

        public async Task<Role> GetByValue(RoleTypes roleValue)
        {
            return await _context.Set<Role>()
                .FirstOrDefaultAsync(x => x.Value == roleValue && x.IsDeleted == false);
        }
    }
}
