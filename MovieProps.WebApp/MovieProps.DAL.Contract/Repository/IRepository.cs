using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.DAL.Contract.Repository
{
    public interface IRepository<T>
    {
        Task Add(T entity);
        Task AddRange(List<T> entities);
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Update(T entity);
        void Remove(T entity);
        Task Save();
    }
}
