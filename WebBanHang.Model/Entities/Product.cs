using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanHang.Model.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Display(Name = "Danh mục")]
        public int? CategoryChildID { get; set; }

        [Display(Name = "Nhà cung cấp")]
        public int? SupplierID { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm!!")]
        public string Name { get; set; }

        [Display(Name = "Giá bán")]
        [Required(ErrorMessage = "Vui lòng nhập giá bán!")]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { set; get; }

        [Display(Name = "Ngày tạo")]
        [DataType(DataType.DateTime)]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "Giảm giá")]
        public int? Discount { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Tình trạng")]
        public bool? State { get; set; }

        public virtual CategoryChild CategoryChild { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}