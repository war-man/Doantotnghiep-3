using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models
{
    public class SetColumnContact
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

        public Year Year { get; set; }
        [Key]
        [Column(Order = 1)]
        public string YearId { get; set; }
        
        public Teacher Teacher { get; set; }
        [Key]
        [Column(Order = 2)]
        public string TeacherId { get; set; }
    }
}