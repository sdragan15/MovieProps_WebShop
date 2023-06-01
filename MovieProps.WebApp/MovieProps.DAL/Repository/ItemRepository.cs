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
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public MoviePropsContext Context
        {
            get { return _context as MoviePropsContext; }
        }

        public ItemRepository(MoviePropsContext moviePropsContext) : base(moviePropsContext) { }
    }
}
