using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models
{
    public class Teacher
    {
        [Key]
        [Column(Order = 1)]
        public string Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
      
        [Required]
        public string name_Teacher { get; set; }

        [Required]
        public bool sex { get; set; }
        [Required]
        public string address { get; set; }


        public Subject Subject { get; set; }

        public string SubjectId { get; set; }



    }
}