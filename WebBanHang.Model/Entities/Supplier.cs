using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanHang.Model.Entities
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierID { get; set; }

        public int? ProductID { get; set; }

        [StringLength(100)]
        [Display(Name = "Tên nhà cung cấp")]
        public string CompanyName { get; set; }

        [StringLength(100)]
        [Display(Name = "Tên người đại diện")]
        public string ContactName { get; set; }

        [StringLength(100)]
        [Display(Name = "Tiêu đề")]
        public string ContacTitle { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [StringLength(20)]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? State { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}