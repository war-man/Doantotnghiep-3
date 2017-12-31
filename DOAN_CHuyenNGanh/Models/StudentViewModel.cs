using DOAN_CHuyenNGanh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models
{
    public class StudentViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email{ get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string name_Student { get; set; }
        [Required]
        public bool sex { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        [FutureDate]
        public string birthDay_student { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string phonenumber_student { get; set; }

        [Required]
        public IEnumerable<Class> Class { get; set; }
        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email_parent { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password_parent { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword_parent { get; set; }

        //[Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[Display(Name = "Tên Học Sinh")]
        //public string name_Student { get; set; }
        //[Required]
        //public bool sex { get; set; }
        //[Required]
        //public string address { get; set; }

       /// <summary>
       /// Create info Parent
       /// </summary>
        [Required]
        [Display(Name = "Tên và Tên")]
        public string name_Parent { get; set; }

        [Required]
        [Display(Name = "Số Điện Thoại")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string phonenumber_parent { get; set; }
        [Required]
        [Display(Name = "Nghề Nghiệp")]
        public string job { get; set; }
        [Required]
        [FutureDate]
        public string birthDay_parent { get; set; }


    }

}