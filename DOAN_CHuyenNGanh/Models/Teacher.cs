using DOAN_CHuyenNGanh.Models.Valid;
using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models
{
    public class Teacher
    {
        [Key]
        [Column(Order = 1)]
        public string Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
      
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Tên từ 3 ký tự đến 100 kí tự")]
        public string name_Teacher { get; set; }

        [Required]
        public bool sex { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Tên từ 3 ký tự đến 255 kí tự")]
        public string address { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tên biệt danh từ 3 ký tự đến 50 kí tự")]
        public string first_name { get; set; }

        [Required]
        [FutureDate]
        public string birth_day { get; set; }

        [Required]
        public int birth_place { get; set; }

        [Required]
        public string name_birth_place { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Dân tộc từ 3 ký tự đến 10 kí tự")]
        public string people { get; set; }

        [Required]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Số điện thoại từ 9 ký tự đến 12 số")]
        public string phone_number { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string prefecture { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string phuongxa { get; set; }
        [Required]
        public string matrimony { get; set; }

        [Required]
        public long identity_card_number { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Năng khiếu từ 3 ký tự đến 255 kí tự")]
        public string gifted { get; set; }

        [Required]
        public string status_heal { get; set; }
        [Required]
        public string disabilities { get; set; }
        
        [Required]
        [FutureDate]
        public string start_date_social_insurance { get; set; }

        [Required]
        public long number_social_insurance { get; set; }
        [Required]
        public long numberBank { get; set; }
        [Required]
        public string nameBank { get; set; }
        [Required]
        public bool status_deleted { get; set; }

        public Subject Subject { get; set; }

        public string SubjectId { get; set; }
    }
}