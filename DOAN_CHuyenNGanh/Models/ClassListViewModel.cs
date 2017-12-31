using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models
{
    public class ClassListViewModel
    {
        public IEnumerable<ClassTeacher> ClassTeacher { get; set; }
        public Teacher Teacher { get; set; }
        public IEnumerable<Semester> Semester { get; set; }
        public Semester SemesterId { get; set; }
        public IEnumerable<Year> Year { get; set; }
        public Year YearId { get; set; }
        public IEnumerable<Class> Class { get; set; }
        public Class ClassId { get; set; }
        public SetColumnContact SetColumnContact { get; set; }

    }
}