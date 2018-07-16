using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Extentions
{
    public static class Extention
    {
        public static string FormatWith(this string value, params object[] args)
        {
            return String.Format(value, args);
        }
    }
}