using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models
{
    public class Student
    {
        [Key]
        [Column(Order = 1)]
        public string Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        [Key]
        public Parent Parent { get; set; }
        [Required]
        public string lastname_Student { get; set; }
        [Required]
        public string firstname_Student { get; set; }
        [Required]
        public string birthDay { get; set; }
        [Required]
        public bool sex { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string phonenumber { get; set; }

        [Required]
        public int birth_place { get; set; }

        [Required]
        public string ngayvaodoan { get; set; }

        [Required]
        public string ngayvaodoi { get; set; }

        [Required]
        public string name_birth_place { get; set; }

        [Required]
        public string quequan { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public string urlImage { get; set; }
    }
}