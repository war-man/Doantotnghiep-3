using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models.DTOs
{
    public class ListTeacherDTO
    {
        public string Id { get; set; }

        public string name_Teacher { get; set; }

        public bool sex { get; set; }
        public bool status_deleted { get; set; }
        public string birth_day { get; set; }

        public string native_land { get; set; }

        public string phone_number { get; set; }

        public string address { get; set; }

        public string email { get; set; }
    }
}