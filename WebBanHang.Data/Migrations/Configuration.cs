namespace WebBanHang.Data.Migrations
{
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
            CreateCategoryParent(context);
            CreateCategoryChild(context);
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
