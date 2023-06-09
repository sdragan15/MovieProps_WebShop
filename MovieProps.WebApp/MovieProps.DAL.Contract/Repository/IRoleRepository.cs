using MovieProps.DAL.Contract.Model;
using MovieProps.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.DAL.Contract.Repository
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> GetByValue(RoleTypes roleValue);
    }
}
