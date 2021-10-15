using System;
using System.Collections.Generic;
using LabTask.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTask.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class UserAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            var flag =  base.AuthorizeCore(httpContext);
            if (flag) {
                var db = new Database();
                int type = db.Users.GetUserType(httpContext.User.Identity.Name);
                if (type == 1) return true;
            }
            return false;

        }
    }
}