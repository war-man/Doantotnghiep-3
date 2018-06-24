using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOAN_CHuyenNGanh.Models
{
    public class DynamicRoleAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var rolesProvider = new RoleProvider();
            var controller = httpContext.Request.RequestContext
                .RouteData.GetRequiredString("controller");
            var action = httpContext.Request.RequestContext
                .RouteData.GetRequiredString("action");
            Roles = string.Join(",", rolesProvider.Get(controller, action));
            return base.AuthorizeCore(httpContext);
        }
    }

}