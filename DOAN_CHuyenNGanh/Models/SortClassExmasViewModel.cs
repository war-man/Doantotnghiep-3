using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models
{
    public class SortClassExmasViewModel
    {
        public IEnumerable<Subject> Subject { get; set; }
        public Subject SubjectId { get; set; }
        public IEnumerable<Semester> Semester { get; set; }
        public Semester SemesterId { get; set; }
        public IEnumerable<Year> Year { get; set; }
        public Year YearId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public SetColumnContact SetColumnContact { get; set; }
        public string TeacherId { get;  set; }
    }
}