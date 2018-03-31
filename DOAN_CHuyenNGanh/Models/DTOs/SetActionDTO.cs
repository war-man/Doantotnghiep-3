using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace DOAN_CHuyenNGanh.Models.DTOs
{
    public class SetActionDTO
    {

        public IEnumerable<RoleAction> GetRoleAction { get; set; }
        public IEnumerable<string> ListRole ;

        private string IdRoleAdmin = "60d50d48-66a9-4899-bf93-0a1b60838da8";
        private string IdRoleTeacher = "2";
        private string IdRoleParent = "3";
        private string IdRoleStudent = "4";
        //public IEnumerable<Roles> GetListRole()
        //{
        //    return listRole;
        //}
        public SetActionDTO()
        {
            GetRoleAction = null;
            ListRole = null;
        }
        public void SetListRole()
        {
            string[] scores = new string[] { IdRoleAdmin, IdRoleTeacher, IdRoleParent, IdRoleStudent };
            ListRole = scores;
        }
    }
}