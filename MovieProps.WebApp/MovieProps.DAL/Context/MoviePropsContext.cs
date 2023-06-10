using Microsoft.EntityFrameworkCore;
using MovieProps.DAL.Contract.Model;
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

            var sellerItem = modelBuilder.Entity<SellerItem>();
            sellerItem.HasOne(x => x.User).WithOne().HasForeignKey<SellerItem>(y => y.UserId);
            sellerItem.HasOne(x => x.Item).WithOne().HasForeignKey<SellerItem>(y => y.ItemId);
            sellerItem.Property(x => x.Price).HasPrecision(12, 3);

            var buyerItem = modelBuilder.Entity<BuyerItem>();
            buyerItem.HasOne(x => x.User).WithOne().HasForeignKey<BuyerItem>(y => y.UserId);
            buyerItem.HasOne(x => x.Item).WithOne().HasForeignKey<BuyerItem>(y => y.ItemId);

            var item = modelBuilder.Entity<Item>();
            item.Property(x => x.Price).HasPrecision(12, 3);

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<SellerItem> SellerItems { get; set; }
        public DbSet<BuyerItem> BuyerItems { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
