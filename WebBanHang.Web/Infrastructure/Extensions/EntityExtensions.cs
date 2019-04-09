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
        public static void UpdateCustomer(this Customer customer, CustomerViewModel customerViewModel)
        {
            customer.CustomerID = customerViewModel.CustomerID;
            customer.OrderID = customerViewModel.OrderID;
            customer.CustomerName = customerViewModel.CustomerName;
            customer.Birthday = customerViewModel.Birthday;
            customer.Address = customerViewModel.Address;
            customer.Phone = customerViewModel.Phone;
            customer.Email = customerViewModel.Email;
            customer.UserName = customerViewModel.UserName;
            customer.Password = customerViewModel.Password;
            customer.CreatedDate = customerViewModel.CreatedDate;
        }
        public static void UpdateEmployee(this Employee employee, EmployeeViewModel employeeViewModel)
        {

            employee.EmployeeID = employeeViewModel.EmployeeID;
            employee.EmployeeName = employeeViewModel.EmployeeName;
            employee.Birthday = employeeViewModel.Birthday;
            employee.Address = employeeViewModel.Address;
            employee.Phone = employeeViewModel.Phone;
            employee.Email = employeeViewModel.Email;
            employee.Image = employeeViewModel.Image;
            employee.UserName = employeeViewModel.UserName;
            employee.Password = employeeViewModel.Password;
            employee.RoleName = employeeViewModel.RoleName;
            employee.CreatedDate = employeeViewModel.CreatedDate;
        }
    }
}