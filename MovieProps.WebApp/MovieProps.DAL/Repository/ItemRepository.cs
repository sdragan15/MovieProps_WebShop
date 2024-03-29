﻿using Microsoft.EntityFrameworkCore;
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

        public async Task DeleteUser(int id)
        {
            var item = await _context.Set<Item>().FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (item != null)
            {
                item.IsDeleted = true;
            }
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItem(Item item)
        {
            var oldItem = await _context.Set<Item>()
                .FirstOrDefaultAsync(x => x.Id == item.Id && x.IsDeleted == false);
            if(oldItem != null && oldItem.LastUpdateTime == item.LastUpdateTime)
            {
                oldItem.Name = item.Name;
                oldItem.Description = item.Description;
                oldItem.Price = item.Price;
                oldItem.Quantity = item.Quantity;
                oldItem.LastUpdateTime = DateTime.Now;

                if(item.Image != null)
                {
                    oldItem.Image = item.Image;
                }
                
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Item>> GetItemsByIds(List<int> ids)
        {
            return await _context.Set<Item>()
                .Where(x => ids.Contains(x.Id) && x.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await _context.Set<Item>()
                .Where(x => x.IsDeleted == false && x.Quantity > 0)
                .OrderByDescending(x => x.LastUpdateTime)
                .ToListAsync();
        }

        public async Task Subtract(int id, int count)
        {
            var item = await _context.Set<Item>()
                .FirstOrDefaultAsync(x => x.Id == id);
            if (item == null) return;

            item.Quantity -= count;

            await _context.SaveChangesAsync();
        }
    }
}
