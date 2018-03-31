using DOAN_CHuyenNGanh.Models;
using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Service
{
    public class RoleActionsService
    {
        private ApplicationDbContext _dbContext = null;
        public RoleActionsService()
        {
            _dbContext = new ApplicationDbContext();
        }
        public IEnumerable<RoleAction> GetRoleAction(string id)
        {
            var listAction = _dbContext.RoleActions.Include("Action").Include("Role").Where(a => a.RoleId == id).ToList();
            return listAction;
        }
    }
}