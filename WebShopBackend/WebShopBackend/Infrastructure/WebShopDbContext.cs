using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopBackend.Model;

namespace WebShopBackend.Infrastructure
{
    public class WebShopDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Salesman> Salesmen{ get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<ItemOrder> ItemOrders { get; set; }


        public WebShopDbContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebShopDbContext).Assembly);
        }
    }
}
