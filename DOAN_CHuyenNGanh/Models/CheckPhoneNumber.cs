using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace DOAN_CHuyenNGanh.Models
{
    public class CheckPhoneNumber:ValidationAttribute
    {
        public override bool IsValid(object number)
        {
            double retNum;
            bool isNum = Double.TryParse(Convert.ToString(number), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum&&retNum>0&&retNum <= 5;
        }
    }
}