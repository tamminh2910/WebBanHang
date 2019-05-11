namespace WebBanHang.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebBanHang.Model.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<WebBanHang.Data.WebBanHangDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebBanHang.Data.WebBanHangDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //CreateCategoryParent(context);
            //CreateCategoryChild(context);
            //CreateCustomer(context);
            //CreateEmployee(context);

            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new WebBanHangDbContext()));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new WebBanHangDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "nguyenvanbay",
            //    Email = "nguyenvanbay@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "Nguyễn Văn Bảy"

            //};

            //manager.Create(user, "123456");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("nguyenvanbay@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
            //CreateOrder(context);
        }

        private void CreateOrder(WebBanHangDbContext context)
        {
            Order order = new Order()
            {
                CustomerName = "Nguyễn Văn Bảy",
                CustomerEmail = "vanbay@gmail.com",
                CustomerPhone = "0975415479",
                OrderDate = DateTime.Now,
                Status = true,
                ShipAddress= "23 đường Phổ Quang, Phường 15, Quận Phú Nhuận, TP. HCM"
            };
            context.Orders.Add(order);
            context.SaveChanges();
            List<OrderDetail> orderDetails = new List<OrderDetail>()
            {
                new OrderDetail(){ProductID=15,OrderID= order.OrderID,Quantity=2,UnitPrice=499000},
                new OrderDetail(){ProductID=11,OrderID= order.OrderID,Quantity=2,UnitPrice=5290000},
            };
            context.OrderDetails.AddRange(orderDetails);
            context.SaveChanges();
        }

        private void CreateEmployee(WebBanHangDbContext context)
        {
            if (context.Employees.Count() == 0)
            {
                List<Employee> employees = new List<Employee>()
                {
                    new Employee() { EmployeeName="Nguyễn Minh Tâm",UserName="admin1",Password="123456",Phone="0332913127",CreatedDate=DateTime.Now},
                    new Employee() { EmployeeName="Nguyễn Văn Bảy",UserName="admin2",Password="123456",Phone="0974531234",CreatedDate=DateTime.Now}
                };
                context.Employees.AddRange(employees);
                context.SaveChanges();
            }
        }

        private void CreateCustomer(WebBanHangDbContext context)
        {
            if (context.Customers.Count() == 0)
            {
                List<Customer> customers = new List<Customer>()
                {
                    new Customer() { CustomerName="Nguyễn Minh Tâm",UserName="tam",Password="123456",Phone="0332913127",CreatedDate=DateTime.Now},
                    new Customer() { CustomerName="Nguyễn Văn Bảy",UserName="bay",Password="123456",Phone="0974531234",CreatedDate=DateTime.Now}
                };
                context.Customers.AddRange(customers);
                context.SaveChanges();
            }
        }

        private void CreateCategoryParent(WebBanHang.Data.WebBanHangDbContext context)
        {
            if (context.CategoryParents.Count() == 0)
            {
                List<CategoryParent> categoryParents = new List<CategoryParent>()
                {
                    new CategoryParent(){CategoryParentName="Điện thoại",CreatedDate=DateTime.Now,State=true},
                     new CategoryParent(){CategoryParentName="Laptop",CreatedDate=DateTime.Now,State=true},
                      new CategoryParent(){CategoryParentName="Apple",CreatedDate=DateTime.Now,State=true,}
                };
                context.CategoryParents.AddRange(categoryParents);
                context.SaveChanges();
            }
        }
        private void CreateCategoryChild(WebBanHang.Data.WebBanHangDbContext context)
        {
            if (context.CategoryChilds.Count() == 0)
            {
                List<CategoryChild> categoryChilds = new List<CategoryChild>()
                {
                    new CategoryChild(){CategoryParentID = 1,CategoryChildName="Samsung",CreatedDate=DateTime.Now,State=true,Alias="samsung",},
                     new CategoryChild(){CategoryParentID = 1,CategoryChildName="Huawei",CreatedDate=DateTime.Now,State=true,Alias="Huawei",},
                     new CategoryChild(){CategoryParentID = 1,CategoryChildName="Apple",CreatedDate=DateTime.Now,State=true,Alias="Apple",},
                };
                context.CategoryChilds.AddRange(categoryChilds);
                context.SaveChanges();
            }
        }
    }
}
