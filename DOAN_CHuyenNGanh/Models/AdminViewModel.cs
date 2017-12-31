using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IdentitySample.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
    public class EditRoleActionViewModel
    {
        public string Id { get; set; }
        [Display(Name = "NameRole")]
        public string NameRole { get; set; }

        public IEnumerable<SelectListItem> ActionRolesList { get; set; }
    }
    public class RoleActionViewModel
    {
        public IEnumerable<IdentityRole> Role { get; set; }
        public string Id { get; set; }

        public string NameRole { get; set; }
        public IEnumerable<SelectListItem> ActionRolesList { get; set; }
    }
}