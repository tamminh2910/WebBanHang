using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Web.Models
{
    public class StateViewModel
    {
        public int StateID { get; set; }

        public string Description { set; get; }

        public virtual IEnumerable<OrderViewModel> Orders { get; set; }

    }
}