using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Web.Models
{
    public class SupplierViewModel
    {
        public int SupplierID { get; set; }

        public int? ProductID { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }
        public string ContacTitle { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool? State { get; set; }

        public virtual IEnumerable<ProductViewModel> Products { get; set; }
    }
}