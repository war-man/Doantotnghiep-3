using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models
{
    public class ContactViewModel
    {
        public IEnumerable<Contact> Contact { get; set; }
        
        public SetColumnContact SetColumnContact { get; set; }
    }
}