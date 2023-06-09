using MovieProps.DAL.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.DAL.Contract.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<List<Item>> GetAllItemsByUserId(int userId);
        Task<User?> GetUserById(int userId);
        Task<List<User>?> GetAllSellers();
    }
}
