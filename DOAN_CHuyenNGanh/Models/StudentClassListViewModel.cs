using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models
{
    public class StudentClassListViewModel
    {
        public Teacher Teacher { get; set; }
        public Class Class { get; set; }
        public IEnumerable<Student> Student { get; set; }
        public IEnumerable<Semester> Semester { get; set; }
        public IEnumerable<Year> Year { get; set; }
    }
}