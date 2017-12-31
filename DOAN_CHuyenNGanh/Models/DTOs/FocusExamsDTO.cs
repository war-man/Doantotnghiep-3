using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models.DTOs
{
    public class FocusExamsDTO
    {
        public IEnumerable<ClassStudent> ClassStudent { get; set; }
        public IEnumerable<Class> Class { get; set; }
    }
}