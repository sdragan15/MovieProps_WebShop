using Microsoft.EntityFrameworkCore;
using MovieProps.DAL.Contract.Model;
using MovieProps.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.DAL.Context
{
    public class MoviePropsContext : DbContext
    {
        public MoviePropsContext() : base()
        {

        }

        public MoviePropsContext(DbContextOptions<MoviePropsContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = modelBuilder.Entity<User>();
            user.Property(x => x.Email).IsRequired();
            user.HasOne(x => x.Role).WithMany().HasForeignKey(x => x.RoleId);

            var item = modelBuilder.Entity<Item>();
            item.Property(x => x.Price).HasPrecision(12, 3);

            modelBuilder.Entity<OrderedItemsTemp>().HasNoKey();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
