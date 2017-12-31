using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models
{
    public class Parent
    {
        [Key]
        [Column(Order = 1)]
        public string Id { get; set; }
       
        public ApplicationUser ApplicationUser { get; set; }
        [Required]
        public string name_Parent { get; set; }
        [Required]
        public string birthDay { get; set; }
        [Required]
        public string phonenumber { get; set; }
        [Required]
        public string job { get; set; }


    }
}