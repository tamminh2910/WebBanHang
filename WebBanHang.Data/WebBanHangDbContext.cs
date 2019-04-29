using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanHang.Model.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebBanHang.Data
{
    public class WebBanHangDbContext : IdentityDbContext<ApplicationUser>
    {
        public WebBanHangDbContext() : base("WebBanHang")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<CategoryParent> CategoryParents { get; set; }
        public DbSet<CategoryChild> CategoryChilds { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Error> Errors { get; set; }

        public static WebBanHangDbContext Create()
        {
            return new WebBanHangDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
        }
    }
}
