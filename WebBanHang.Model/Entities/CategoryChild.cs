using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanHang.Model.Entities
{
    public class CategoryChild
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryChildID { get; set; }

        [StringLength(255)]
        [Required]
        [Display(Name = "Tên danh mục con")]
        public string CategoryChildName { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }


        public virtual IEnumerable<Product> Products { get; set; }
    }
}