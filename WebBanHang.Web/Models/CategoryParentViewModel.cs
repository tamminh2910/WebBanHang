using System;
using System.Collections.Generic;
using WebBanHang.Model.Entities;

namespace WebBanHang.Web.Models
{
    public class CategoryParentViewModel
    {
        public int CategoryParentID { get; set; }

        public string CategoryParentName { get; set; }

        public string Alias { set; get; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool? State { get; set; }

        public virtual IEnumerable<CategoryChildViewModel> CategoryChilds { get; set; }
    }
}