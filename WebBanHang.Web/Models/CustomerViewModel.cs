using System;
using System.Collections.Generic;

namespace WebBanHang.Web.Models
{
    public class CustomerViewModel
    {
        public int CustomerID { get; set; }

        public int? OrderID { get; set; }

        public string CustomerName { get; set; }

        public DateTime? Birthday { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual IEnumerable<OrderViewModel> Orders { get; set; }
    }
}