using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBanHang.Model.Entities
{
    public class State
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StateID { get; set; }

        [StringLength(100)]
        [Display(Name = "Mô tả")]
        public string Description { set; get; }

        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
