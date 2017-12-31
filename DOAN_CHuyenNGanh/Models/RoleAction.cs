using IdentitySample.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models
{
    public class RoleAction
    {

        //public IdentityUserRole Id { get; set; }
        //[Key]
        //[Column(Order = 1)]
        //public string Id_Role { get; set; }

        public Action Action { get; set; }
        [Key]
        [Column(Order = 1)]
        public string ActionId { get; set; }

        public IdentityRole Role { get; set; }
        [Key]
        [Column(Order = 2)]
        public string RoleId { get; set; }


    }
}