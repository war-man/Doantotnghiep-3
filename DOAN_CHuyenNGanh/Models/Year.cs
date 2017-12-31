using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models
{
    public class Year
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}