using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models
{
        public class Contact
        {

            public Class CLass { get; set; }
            [Key]
            [Column(Order = 1)]
            public string CLassId { get; set; }

            public Student Student { get; set; }
            [Key]
            [Column(Order = 2)]
            public string StudentId { get; set; }

            public Subject Subject { get; set; }
            [Key]
            [Column(Order = 3)]
            public string SubjectId { get; set; }

        public Year Year { get; set; }
        [Key]
        [Column(Order = 4)]
        public string YearId { get; set; }

        public Semester Semester { get; set; }
        [Key]
        [Column(Order = 5)]
        public string SemesterId { get; set; }

           
            public string mark_5m1 { get; set; }
            public string mark_5m2 { get; set; }
            public string mark_5m3 { get; set; }
            public string mark_5m4 { get; set; }
            public string mark_5m5 { get; set; }
            public string mark_15m1 { get; set; }
            public string mark_15m2 { get; set; }
            public string mark_15m3 { get; set; }
            public string mark_15m4 { get; set; }
            public string mark_15m5 { get; set; }
            public string mark_45m1 { get; set; }
            public string mark_45m2 { get; set; }
            public string mark_45m3 { get; set; }
            public string mark_45m4 { get; set; }
            public string mark_subjects { get; set ; }
        public string mark_average { get; set; }
        public string comment { get; set; }
            public string comment1 { get; set; }
            public string comment2 { get; set; }
        
        }
}