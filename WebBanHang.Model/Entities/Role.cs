using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Model.Entities
{
    public class Role
    {
        [Key]
        [Display(Name = "Tên vai trò")]
        public string RoleName { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        public virtual IEnumerable<Employee> Employee { get; set; }
    }
}