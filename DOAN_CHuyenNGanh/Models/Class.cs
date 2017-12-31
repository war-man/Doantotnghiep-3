using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models
{
    public class Class
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string name_Class { get; set; }
       
    }
}