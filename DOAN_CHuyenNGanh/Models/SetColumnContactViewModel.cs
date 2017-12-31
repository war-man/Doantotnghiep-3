using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models
{
    public class SetColumnContactViewModel
    {
        [Required]
        [CheckPhoneNumber]
        public int mark_5m { get; set; }

        [Required]
        [CheckPhoneNumber]
        public int mark_15m { get; set; }

        [Required]
        [CheckPhoneNumber]
        public int mark_45m { get; set; }

        public IEnumerable<Year> Year { get; set; }
        public Year YearId { get; set; }

        public string applicationUser { get; set; } 
    }
}