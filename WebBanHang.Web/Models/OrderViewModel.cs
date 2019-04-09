using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Web.Models
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }

        public int? CustomerID { get; set; }

        public int? EmployeeID { get; set; }

        public int? StateID { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public string ShipAddress { get; set; }

        public virtual CustomerViewModel Customer { get; set; }

        public virtual EmployeeViewModel Employee { get; set; }

        public virtual IEnumerable<OrderDetailViewModel> OrderDetails { get; set; }

        public virtual StateViewModel State { set; get; }
    }
}