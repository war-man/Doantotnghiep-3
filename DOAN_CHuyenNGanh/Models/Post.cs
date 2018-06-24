using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string LinkImage { get; set; }

        public bool DeleteFlag { get; set; }

        public Category Category { get; set; }

    }
}