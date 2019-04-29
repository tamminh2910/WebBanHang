using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanHang.Model.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerName { set; get; }

      
        [Required]
        [MaxLength(256)]
        public string CustomerEmail { set; get; }

        [Required]
        [MaxLength(50)]
        public string CustomerPhone { set; get; }

        [Display(Name = "Tình trạng giao hàng")]
        public bool Status { get; set; }

        [Display(Name = "Ngày đặt hàng")]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Ngày đã giao")]
        [DataType(DataType.DateTime)]
        public DateTime? ShippedDate { get; set; }

        [Display(Name = "Địa chỉ giao hàng")]
        public string ShipAddress { get; set; }

        [Display(Name = "Khách hàng")]
        public int? CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

   
        [ForeignKey("OrderID")]
        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}