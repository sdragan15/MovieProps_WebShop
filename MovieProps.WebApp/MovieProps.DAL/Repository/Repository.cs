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
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {

        protected readonly MoviePropsContext _context;

        public Repository(MoviePropsContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task AddRange(List<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefaultAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            var temp = await _context.Set<T>().Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
            if(temp != null)
            {
                temp = entity;
            }
        }
    }
}
