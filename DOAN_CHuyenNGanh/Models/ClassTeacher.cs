using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models
{
    public class ClassTeacher
    {
        public Teacher Teacher { get; set; }
        public string TeacherId { get; set; }

        public Class Class { get; set; }
        [Key]
        [Column(Order = 1)]
        public string ClassId { get; set; }

        public Subject Subject { get; set; }
        [Key]
        [Column(Order = 2)]
        public string SubjectId { get; set; }
    }
}