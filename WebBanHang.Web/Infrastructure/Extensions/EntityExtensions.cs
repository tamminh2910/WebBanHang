using WebBanHang.Model.Entities;
using WebBanHang.Web.Models;

namespace WebBanHang.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateCategoryChild(this CategoryChild categoryChild, CategoryChildViewModel categoryChildVm)
        {
            categoryChild.CategoryChildID = categoryChildVm.CategoryChildID;
            categoryChild.CategoryChildName = categoryChildVm.CategoryChildName;
            categoryChild.Alias = categoryChildVm.Alias;
            categoryChild.CategoryParentID = categoryChildVm.CategoryParentID;
            categoryChild.CreatedDate = categoryChildVm.CreatedDate;
            categoryChild.Description = categoryChildVm.Description;
            categoryChild.State = categoryChildVm.State;
        }

        public static void UpdateCategoryParent(this CategoryParent categoryParent, CategoryParentViewModel categoryParentVm)
        {
            categoryParent.CategoryParentID = categoryParentVm.CategoryParentID;
            categoryParent.CategoryParentName = categoryParentVm.CategoryParentName;
            categoryParent.Alias = categoryParentVm.Alias;
            categoryParent.Description = categoryParentVm.Description;
            categoryParent.CreatedDate = categoryParentVm.CreatedDate;
            categoryParent.State = categoryParentVm.State;
        }

        public static void UpdateProduct(this Product product, ProductViewModel productVm)
        {
            product.ProductID = productVm.ProductID;
            product.CategoryChildID = productVm.CategoryChildID;
            product.SupplierID = productVm.SupplierID;
            product.Name = productVm.Name;
            product.Alias = productVm.Alias;
            product.UnitPrice = productVm.UnitPrice;
            product.Image = productVm.Image;
            product.MoreImages = productVm.MoreImages;
            product.RegisterDate = productVm.RegisterDate;
            product.Discount = productVm.Discount;
            product.Description = productVm.Description;
            product.State = productVm.State;
        }
    }
}