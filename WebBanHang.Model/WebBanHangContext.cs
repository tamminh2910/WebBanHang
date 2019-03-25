using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHang.Model.Entities;

namespace WebBanHang.Model
{
    public class WebBanHangContext: DbContext
    {
        public WebBanHangContext() : base("WebBanHang")
        {

        }
        public DbSet<CategoryParent> CategoryParents { get; set; }
        public DbSet<CategoryChild> CategoryChilds { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
