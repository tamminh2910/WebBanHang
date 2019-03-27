using System;
using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Model.Entities
{
    public class Error
    {
        [Key]
        public int ID { get; set; }

        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}