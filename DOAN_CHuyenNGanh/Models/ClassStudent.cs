using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models
{
    public class ClassStudent
    {
        public Student Student { get; set; }
        [Key]
        [Column(Order = 1)]
        public string StudentId { get; set; }

        public Class Class { get; set; }
        [Key]
        [Column(Order = 2)]
        public string ClassId { get; set; }

        public Year Year { get; set; }
        [Key]
        [Column(Order = 3)]
        public string YearId { get; set; }
    }
    public class ClassStudentViewModel
    {

        public string StudentId { get; set; }

        public string ClassId { get; set; }

        public string YearId { get; set; }
    }
}