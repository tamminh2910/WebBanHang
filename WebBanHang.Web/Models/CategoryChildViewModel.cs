using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHang.Model.Entities;

namespace WebBanHang.Web.Models
{
    public class CategoryChildViewModel
    {
      
        public int CategoryChildID { get; set; }

        public int? CategoryParentID { get; set; }

        public int? ProductID { get; set; }

      
        public string CategoryChildName { get; set; }

        public string Alias { set; get; }
        public string Description { get; set; }

    
        public DateTime CreatedDate { get; set; }

      
        public bool? State { get; set; }

    
        public virtual CategoryParentViewModel CategoryParent { get; set; }

    
        public virtual IEnumerable<ProductViewModel> Products { get; set; }
    }
}