using DOAN_CHuyenNGanh.Models.Valid;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models.DTOs
{
    public class InfoExamsDto
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Mark { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }
        [Required]
        [ValidTime]
        public string Time { set; get; }

 
        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }

        [Required]
        public string Grade { get; set; }

        public Subject Subject { get; set; }

        [Required]
        public string SubjectId { get; set; }

        public Year Year { get; set; }

        [Required]
        public string YearId { get; set; }

        public Semester Semester { get; set; }

        [Required]
        public string SemesterId { get; set; }
    }
}