using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOAN_CHuyenNGanh.Models
{
    public class RoleProvider
    {
        private ApplicationDbContext _dbContext = null;
        public string[] Get(string controller, string action)
        {
            _dbContext = new ApplicationDbContext();
            // get your roles based on the controller and the action name 
            // wherever you want such as db
            // I hardcoded for the sake of simplicity 
            var temp = controller + action;
            string url = "/" + controller + "/" + action;
            var role= _dbContext.RoleActions.Where(a => a.ActionId == temp).Select(a => a.Role.Name).ToList();
            var roles = _dbContext.Actions.Any(a => a.Id == temp);
            if (roles)
            {
                string[] arr = new string[role.Count()];
                for (int i = 0; i < role.Count(); i++)
                {
                    arr[i] = role[i];
                }
                return arr;
            }
            else
            {
                var actions = new Action
                {
                    Id = temp,
                    Name=temp,
                    Url= url
                };
                var roleaction = new RoleAction
                {
                    ActionId = temp,
                    RoleId = "fde60f1d-31f8-467b-919f-2913a4882064",
                };
                _dbContext.Actions.Add(actions);
                _dbContext.RoleActions.Add(roleaction);
                _dbContext.SaveChanges();
                return new string[] { "Admin" };
            }
          
        }
    }

}