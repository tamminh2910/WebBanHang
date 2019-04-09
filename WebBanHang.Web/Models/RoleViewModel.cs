using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Web.Models
{
    public class RoleViewModel
    {
        public string RoleName { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<EmployeeViewModel> Employees { get; set; }

    }
}