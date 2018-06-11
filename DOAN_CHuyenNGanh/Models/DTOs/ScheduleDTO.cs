using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models.DTOs
{
    public class ScheduleDTO
    {
       public string idTeacher { get; set; }
        public string Semester { get; set; }
        public string Year { get; set; }
        public int dayweeks { get; set; }
    }
}