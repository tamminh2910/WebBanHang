using System;

namespace WebBanHang.Web.Models
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }

        public int? CategoryChildID { get; set; }

        public int? SupplierID { get; set; }

        public string Name { get; set; }
        public string Alias { set; get; }
        public decimal? UnitPrice { get; set; }

        public string Image { get; set; }

        public string MoreImages { set; get; }

        public DateTime RegisterDate { get; set; }

        public int? Discount { get; set; }

        public string Description { get; set; }

        public bool? State { get; set; }

        public virtual CategoryChildViewModel CategoryChild { get; set; }

        public virtual SupplierViewModel Supplier { get; set; }
    }
}